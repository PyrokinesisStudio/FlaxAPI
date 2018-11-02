// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using System;
using System.Collections.Generic;
using FlaxEngine;

namespace FlaxEditor.Surface
{
    /// <summary>
    /// Visject Surface visual representation context. Contains context and deserialized graph data.
    /// </summary>
    public partial class VisjectSurfaceContext
    {
        private bool _isModified;
        private VisjectSurface _surface;
        private SurfaceMeta _meta = new SurfaceMeta();

        /// <summary>
        /// The parent context. Defines the higher key surface graph context. May be null for the top-level context.
        /// </summary>
        public readonly VisjectSurfaceContext Parent;

        /// <summary>
        /// The children of this context (loaded and opened in editor only).
        /// </summary>
        public readonly List<VisjectSurfaceContext> Children = new List<VisjectSurfaceContext>();

        /// <summary>
        /// The context.
        /// </summary>
        public readonly ISurfaceContext Context;

        /// <summary>
        /// The root control for the GUI. Used to navigate around the view (scale and move it). Contains all surface controls including nodes and comments.
        /// </summary>
        public readonly SurfaceRootControl RootControl;

        /// <summary>
        /// The nodes collection. Read-only.
        /// </summary>
        public readonly List<SurfaceNode> Nodes = new List<SurfaceNode>(64);

        /// <summary>
        /// The collection of the surface parameters.
        /// </summary>
        public readonly List<SurfaceParameter> Parameters = new List<SurfaceParameter>();

        /// <summary>
        /// Gets the list of the surface comments.
        /// </summary>
        /// <remarks>
        /// Don't call it too often. It does memory allocation and iterates over the surface controls to find comments in the graph.
        /// </remarks>
        public List<SurfaceComment> Comments
        {
            get
            {
                var result = new List<SurfaceComment>();
                for (int i = 0; i < RootControl.Children.Count; i++)
                {
                    if (RootControl.Children[i] is SurfaceComment comment)
                        result.Add(comment);
                }
                return result;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this context is modified (needs saving and flushing with surface data context source).
        /// </summary>
        public bool IsModified => _isModified;

        /// <summary>
        /// Gets the parent Visject surface.
        /// </summary>
        public VisjectSurface Surface => _surface;

        /// <summary>
        /// The surface meta (cached after opening the context, used to store it back into the data container).
        /// </summary>
        internal VisjectSurface.Meta10 CachedSurfaceMeta;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisjectSurfaceContext"/> class.
        /// </summary>
        /// <param name="surface">The Visject surface using this context.</param>
        /// <param name="parent">The parent context. Defines the higher key surface graph context. May be null for the top-level context.</param>
        /// <param name="context">The context.</param>
        public VisjectSurfaceContext(VisjectSurface surface, VisjectSurfaceContext parent, ISurfaceContext context)
        : this(surface, parent, context, new SurfaceRootControl())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisjectSurfaceContext"/> class.
        /// </summary>
        /// <param name="surface">The Visject surface using this context.</param>
        /// <param name="parent">The parent context. Defines the higher key surface graph context. May be null for the top-level context.</param>
        /// <param name="context">The context.</param>
        /// <param name="rootControl">The surface root control.</param>
        public VisjectSurfaceContext(VisjectSurface surface, VisjectSurfaceContext parent, ISurfaceContext context, SurfaceRootControl rootControl)
        {
            _surface = surface;
            Parent = parent;
            Context = context ?? throw new ArgumentNullException(nameof(context));
            RootControl = rootControl ?? throw new ArgumentNullException(nameof(rootControl));

            // Set initial scale to provide nice zoom in effect on startup
            RootControl.Scale = new Vector2(0.5f);
        }

        /// <summary>
        /// Finds the node of the given type.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>Found node or null if cannot.</returns>
        public SurfaceNode FindNode(ushort groupId, ushort typeId)
        {
            SurfaceNode result = null;
            uint type = ((uint)groupId << 16) | typeId;
            for (int i = 0; i < Nodes.Count; i++)
            {
                var node = Nodes[i];
                if (node.Type == type)
                {
                    result = node;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Finds the node with the given ID.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Found node or null if cannot.</returns>
        public SurfaceNode FindNode(uint id)
        {
            SurfaceNode result = null;
            for (int i = 0; i < Nodes.Count; i++)
            {
                var node = Nodes[i];
                if (node.ID == id)
                {
                    result = node;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the parameter by the given ID.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Found parameter instance or null if missing.</returns>
        public SurfaceParameter GetParameter(Guid id)
        {
            SurfaceParameter result = null;
            for (int i = 0; i < Parameters.Count; i++)
            {
                var parameter = Parameters[i];
                if (parameter.ID == id)
                {
                    result = parameter;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the parameter by the given name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Found parameter instance or null if missing.</returns>
        public SurfaceParameter GetParameter(string name)
        {
            SurfaceParameter result = null;
            for (int i = 0; i < Parameters.Count; i++)
            {
                var parameter = Parameters[i];
                if (parameter.Name == name)
                {
                    result = parameter;
                    break;
                }
            }
            return result;
        }
        
        private uint GetFreeNodeID()
        {
            uint result = 1;
            while (true)
            {
                bool valid = true;
                for (int i = 0; i < Nodes.Count; i++)
                {
                    if (Nodes[i].ID == result)
                    {
                        result++;
                        valid = false;
                        break;
                    }
                }
                if (valid)
                    break;
            }
            return result;
        }
        
        /// <summary>
        /// Spawns the comment object. Used by the <see cref="CreateComment"/> and loading method. Can be overriden to provide custom comment object implementations.
        /// </summary>
        /// <param name="surfaceArea">The surface area.</param>
        /// <returns>The comment object</returns>
        public virtual SurfaceComment SpawnComment(ref Rectangle surfaceArea)
        {
            return new SurfaceComment(_surface, ref surfaceArea);
        }

        /// <summary>
        /// Creates the comment.
        /// </summary>
        /// <param name="surfaceArea">The surface area to create comment.</param>
        /// <returns>The comment object</returns>
        public SurfaceComment CreateComment(ref Rectangle surfaceArea)
        {
            // Create comment
            var comment = SpawnComment(ref surfaceArea);
            if (comment == null)
            {
                Editor.LogWarning("Failed to create comment.");
                return null;
            }

            // Initialize
            OnControlLoaded(comment);
            comment.OnSurfaceLoaded();

            MarkAsModified();

            return comment;
        }
        
        /// <summary>
        /// Spawns the node.
        /// </summary>
        /// <param name="groupID">The group archetype ID.</param>
        /// <param name="typeID">The node archetype ID.</param>
        /// <param name="location">The location.</param>
        /// <param name="customValues">The custom values array. Must match node archetype <see cref="NodeArchetype.DefaultValues"/> size. Pass null to use default values.</param>
        /// <returns>Created node.</returns>
        public SurfaceNode SpawnNode(ushort groupID, ushort typeID, Vector2 location, object[] customValues = null)
        {
            GroupArchetype groupArchetype;
            NodeArchetype nodeArchetype;
            if (NodeFactory.GetArchetype(_surface.NodeArchetypes, groupID, typeID, out groupArchetype, out nodeArchetype))
            {
                return SpawnNode(groupArchetype, nodeArchetype, location, customValues);
            }

            return null;
        }

        /// <summary>
        /// Spawns the node.
        /// </summary>
        /// <param name="groupArchetype">The group archetype.</param>
        /// <param name="nodeArchetype">The node archetype.</param>
        /// <param name="location">The location.</param>
        /// <param name="customValues">The custom values array. Must match node archetype <see cref="NodeArchetype.DefaultValues"/> size. Pass null to use default values.</param>
        /// <returns>Created node.</returns>
        public SurfaceNode SpawnNode(GroupArchetype groupArchetype, NodeArchetype nodeArchetype, Vector2 location, object[] customValues = null)
        {
            if (groupArchetype == null || nodeArchetype == null)
                throw new ArgumentNullException();
            
            if (!_surface.CanSpawnNodeType(nodeArchetype))
            {
                Editor.LogWarning("Cannot spawn given node type.");
                return null;
            }

            var id = GetFreeNodeID();

            // Create node
            var node = NodeFactory.CreateNode(id, _surface, groupArchetype, nodeArchetype);
            if (node == null)
            {
                Editor.LogWarning("Failed to create node.");
                return null;
            }
            Nodes.Add(node);

            // Initialize
            if (customValues != null)
            {
                if (node.Values != null && node.Values.Length == customValues.Length)
                    Array.Copy(customValues, node.Values, customValues.Length);
                else
                    throw new InvalidOperationException("Invalid node custom values.");
            }
            OnControlLoaded(node);
            node.OnSurfaceLoaded();
            node.Location = location;

            MarkAsModified();

            return node;
        }

        /// <summary>
        /// Marks the context as modified and sends the event to the parent context.
        /// </summary>
        public void MarkAsModified()
        {
            if (!_isModified)
            {
                _isModified = true;
                Parent?.MarkAsModified();
            }
        }

        /// <summary>
        /// Clears the surface data. Disposed all surface nodes, comments, parameters and more.
        /// </summary>
        public void Clear()
        {
            Parameters.Clear();
            Nodes.Clear();
            RootControl.DisposeChildren();
        }
    }
}