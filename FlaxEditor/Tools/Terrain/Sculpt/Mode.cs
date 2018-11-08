// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using System;
using FlaxEditor.Tools.Terrain.Brushes;
using FlaxEngine;

namespace FlaxEditor.Tools.Terrain.Sculpt
{
    /// <summary>
    /// The base class for terran sculpt tool modes.
    /// </summary>
    public abstract class Mode
    {
        /// <summary>
        /// The options container for the terrain editing apply.
        /// </summary>
        public struct Options
        {
            /// <summary>
            /// If checked, modification apply method should be inverted.
            /// </summary>
            public bool Invert;

            /// <summary>
            /// The master strength parameter to apply when editing the terrain.
            /// </summary>
            public float Strength;

            /// <summary>
            /// The delta time (in seconds) for the terrain modification apply. Used to scale the strength. Adjusted to handle low-FPS.
            /// </summary>
            public float DeltaTime;
        }

        /// <summary>
        /// The tool strength (normalized to range 0-1). Defines the intensity of the sculpt operation to make it stronger or mre subtle.
        /// </summary>
        [EditorOrder(0), Limit(0, 5, 0.01f), Tooltip("The tool strength (normalized to range 0-1). Defines the intensity of the sculpt operation to make it stronger or mre subtle.")]
        public float Strength = 1.2f;

        /// <summary>
        /// Gets a value indicating whether this mode supports negative apply for terrain modification.
        /// </summary>
        public virtual bool SupportsNegativeApply => false;

        /// <summary>
        /// Applies the modification to the terrain.
        /// </summary>
        /// <param name="brush">The brush.</param>
        /// <param name="options">The options.</param>
        /// <param name="gizmo">The gizmo.</param>
        /// <param name="terrain">The terrain.</param>
        /// <exception cref="FlaxException">Cannot modify terrain. Loading heightmap failed. See log for more info.</exception>
        public unsafe void Apply(Brush brush, ref Options options, SculptTerrainGizmoMode gizmo, FlaxEngine.Terrain terrain)
        {
            // Combine final apply strength
            float strength = Strength * options.Strength * options.DeltaTime;
            if (strength <= 0.0f)
                return;
            if (options.Invert && SupportsNegativeApply)
                strength *= -1;

            // Prepare
            var chunkSize = terrain.ChunkSize;
            var heightmapSize = chunkSize * FlaxEngine.Terrain.PatchEdgeChunksCount + 1;
            var heightmapLength = heightmapSize * heightmapSize;
            var patchSize = chunkSize * FlaxEngine.Terrain.UnitsPerVertex * FlaxEngine.Terrain.PatchEdgeChunksCount;
            float* tempBuffer = (float*)gizmo.GetHeightmapTempBuffer(heightmapLength * sizeof(float)).ToPointer();
            var brushPosition = gizmo.CursorPosition;
            var unitsPerVertexInv = 1.0f / FlaxEngine.Terrain.UnitsPerVertex;
            ApplyParams p = new ApplyParams
            {
                Terrain = terrain,
                Brush = brush,
                Gizmo = gizmo,
                Options = options,
                Strength = strength,
                HeightmapSize = heightmapSize,
                TempBuffer = tempBuffer,
            };

            // Get brush bounds in terrain local space
            var brushBounds = gizmo.CursorBrushBounds;
            terrain.GetLocalToWorldMatrix(out p.TerrainWorld);
            terrain.GetWorldToLocalMatrix(out var terrainInvWorld);
            BoundingBox.Transform(ref brushBounds, ref terrainInvWorld, out var brushBoundsLocal);

            // Process all the patches under the cursor
            for (int patchIndex = 0; patchIndex < gizmo.PatchesUnderCursor.Count; patchIndex++)
            {
                var patch = gizmo.PatchesUnderCursor[patchIndex];
                var patchPositionLocal = new Vector3(patch.PatchCoord.X * patchSize, 0, patch.PatchCoord.Y * patchSize);

                // Get the patch data (cached internally by the c++ core in editor)
                var sourceDataPtr = TerrainTools.GetHeightmapData(terrain, ref patch.PatchCoord);
                if (sourceDataPtr == IntPtr.Zero)
                {
                    throw new FlaxException("Cannot modify terrain. Loading heightmap failed. See log for more info.");
                }
                var sourceData = (float*)sourceDataPtr.ToPointer();
                // TODO: record patch data if gizmo has just started editing this chunk (for undo)

                // Transform brush bounds from local terrain space into local patch vertex space
                brushBoundsLocal.Minimum = (brushBoundsLocal.Minimum - patchPositionLocal) * unitsPerVertexInv;
                brushBoundsLocal.Maximum = (brushBoundsLocal.Maximum - patchPositionLocal) * unitsPerVertexInv;

                // Calculate patch heightmap area to modify by brush
                var brushPatchMin = new Int2(Mathf.FloorToInt(brushBoundsLocal.Minimum.X), Mathf.FloorToInt(brushBoundsLocal.Minimum.Z));
                var brushPatchMax = new Int2(Mathf.CeilToInt(brushBoundsLocal.Maximum.X), Mathf.FloorToInt(brushBoundsLocal.Maximum.Z));
                var modifiedOffset = brushPatchMin;
                var modifiedSize = brushPatchMax - brushPatchMin;

                // Expand the modification area by one vertex in each direction to ensure normal vectors are updated for edge cases
                modifiedOffset.X = Mathf.Max(modifiedOffset.X - 1, 0);
                modifiedOffset.Y = Mathf.Max(modifiedOffset.Y - 1, 0);
                modifiedSize.X = Mathf.Min(modifiedSize.X + 2, heightmapSize - modifiedOffset.X);
                modifiedSize.Y = Mathf.Min(modifiedSize.Y + 2, heightmapSize - modifiedOffset.Y);

                // Apply modification
                p.ModifiedOffset = modifiedOffset;
                p.ModifiedSize = modifiedSize;
                p.PatchCoord = patch.PatchCoord;
                p.PatchPositionLocal = patchPositionLocal;
                p.SourceData = sourceData;
                Apply(ref p);
            }
        }

        /// <summary>
        /// The mode apply parameters.
        /// </summary>
        public unsafe struct ApplyParams
        {
            /// <summary>
            /// The brush.
            /// </summary>
            public Brush Brush;

            /// <summary>
            /// The options.
            /// </summary>
            public Options Options;

            /// <summary>
            /// The gizmo.
            /// </summary>
            public SculptTerrainGizmoMode Gizmo;

            /// <summary>
            /// The terrain.
            /// </summary>
            public FlaxEngine.Terrain Terrain;

            /// <summary>
            /// The patch coordinates.
            /// </summary>
            public Int2 PatchCoord;

            /// <summary>
            /// The modified offset.
            /// </summary>
            public Int2 ModifiedOffset;

            /// <summary>
            /// The modified size.
            /// </summary>
            public Int2 ModifiedSize;

            /// <summary>
            /// The final calculated strength of the effect to apply (can be negative for inverted terrain modification if <see cref="SupportsNegativeApply"/> is set).
            /// </summary>
            public float Strength;

            /// <summary>
            /// The temporary data buffer (for modified data).
            /// </summary>
            public float* TempBuffer;

            /// <summary>
            /// The source data buffer.
            /// </summary>
            public float* SourceData;

            /// <summary>
            /// The heightmap size (edge).
            /// </summary>
            public int HeightmapSize;

            /// <summary>
            /// The patch position in terrain local-space.
            /// </summary>
            public Vector3 PatchPositionLocal;

            /// <summary>
            /// The terrain local-to-world matrix.
            /// </summary>
            public Matrix TerrainWorld;
        }

        /// <summary>
        /// Applies the modification to the terrain.
        /// </summary>
        /// <param name="p">The parameters to use.</param>
        public abstract unsafe void Apply(ref ApplyParams p);
    }
}