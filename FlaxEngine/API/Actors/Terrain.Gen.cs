// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// Represents a single terrain object.
    /// </summary>
    [Serializable]
    public sealed partial class Terrain : Actor
    {
        /// <summary>
        /// Creates new <see cref="Terrain"/> object.
        /// </summary>
        private Terrain() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="Terrain"/> object.
        /// </summary>
        /// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static Terrain New()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_Create(typeof(Terrain)) as Terrain;
#endif
        }

        /// <summary>
        /// Gets or sets the terrain Level Of Detail bias value. Allows to increase or decrease rendered terrain quality.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(50), Limit(-100, 100, 0.1f), EditorDisplay("Terrain", "LOD Bias"), Tooltip("Terrain Level Of Detail bias value. Allows to increase or decrease rendered terrain quality.")]
        public int LODBias
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetLODBias(unmanagedPtr); }
            set { Internal_SetLODBias(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the terrain forced Level Of Detail index. Allows to bind the given terrain LOD to show. Value -1 disables this feature.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(60), Limit(-1, 100, 0.1f), EditorDisplay("Terrain", "Forced LOD"), Tooltip("Terrain forced Level Of Detail index. Allows to bind the given chunk LOD to show. Value -1 disables this feature.")]
        public int ForcedLOD
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetForcedLOD(unmanagedPtr); }
            set { Internal_SetForcedLOD(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Creates the terrain.
        /// </summary>
        /// <param name="lodCount">The LODs count.</param>
        /// <param name="chunkSize">The size of the chunk (amount of vertices per edge for the highest LOD).</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void Setup(int lodCount = 6, int chunkSize = 64)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_Setup(unmanagedPtr, lodCount, chunkSize);
#endif
        }

        /// <summary>
        /// Adds the patch.
        /// </summary>
        /// <param name="x">The patch location x.</param>
        /// <param name="y">The patch location y</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void AddPatch(int x, int y)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_AddPatch(unmanagedPtr, x, y);
#endif
        }

        /// <summary>
        /// Removes the patch.
        /// </summary>
        /// <param name="x">The patch location x.</param>
        /// <param name="y">The patch location y</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void RemovePatch(int x, int y)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_RemovePatch(unmanagedPtr, x, y);
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetLODBias(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetLODBias(IntPtr obj, int val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetForcedLOD(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetForcedLOD(IntPtr obj, int val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_Setup(IntPtr obj, int lodCount, int chunkSize);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_AddPatch(IntPtr obj, int x, int y);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_RemovePatch(IntPtr obj, int x, int y);
#endif

        #endregion
    }
}