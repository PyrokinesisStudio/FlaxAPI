////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using FlaxEditor.States;
using FlaxEngine;
using FlaxEngine.GUI;

namespace FlaxEditor.Windows
{
    /// <summary>
    /// Windows used to present loaded scenes collection and whole scene graph.
    /// </summary>
    /// <seealso cref="FlaxEditor.Windows.SceneEditorWindow" />
    public class SceneTreeWindow : SceneEditorWindow
    {
        private Tree _tree;
        private bool _isUpdatingSelection;

        /// <summary>
        /// The root tree node for the whole scene graph.
        /// </summary>
        public readonly RootTreeNode Root;

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneTreeWindow"/> class.
        /// </summary>
        /// <param name="editor">The editor.</param>
        public SceneTreeWindow(Editor editor)
            : base(editor, true, ScrollBars.Both)
        {
            Title = "Scene";
            
            // Create scene structure tree
            Root = new RootTreeNode();
            Root.Expand();
            _tree = new Tree(true);
            _tree.AddChild(Root);
            _tree.OnSelectedChanged += Tree_OnOnSelectedChanged;
            _tree.OnRightClick += Tree_OnOnRightClick;
            _tree.Parent = this;

            // TODO: create context menu

            // TODO: disable node action if scene editing is not allowed
        }

        private void Tree_OnOnSelectedChanged(List<TreeNode> before, List<TreeNode> after)
        {
            // Check if lock events
            if (_isUpdatingSelection)
                return;

            if (after.Count > 0)
            {
                // Get actors from nodes
                var actors = new List<ISceneTreeNode>(after.Count);
                for (int i = 0; i < after.Count; i++)
                {
                    if (after[i] is ActorTreeNode node && node.Actor)
                        actors.Add(node);
                }

                // Select
                Editor.SceneEditing.Select(actors);
            }
            else
            {
                // Deselect
                Editor.SceneEditing.Deselect();
            }
        }

        private void Tree_OnOnRightClick(TreeNode node, Vector2 location)
        {
            // TODO: show context menu
        }

        /// <inheritdoc />
        public override void OnInit()
        {
            Editor.SceneEditing.OnSelectionChanged += SceneEditingOnOnSelectionChanged;
        }

        private void selectNodesHelper(List<TreeNode> nodes, List<ISceneTreeNode> selection, TreeNode node)
        {
            for (int i = 0; i < node.ChildrenCount; i++)
            {
                if (node.GetChild(i) is ActorTreeNode actorNode)
                {
                    if (selection.Contains(actorNode))
                        nodes.Add(actorNode);

                    selectNodesHelper(nodes, selection, actorNode);
                }
            }
        }

        private void SceneEditingOnOnSelectionChanged()
        {
            _isUpdatingSelection = true;

            var selection = Editor.SceneEditing.Selection;
            if (selection.Count == 0)
            {
                _tree.Deselect();
            }
            else if (selection.Count == 1)
            {
                var node = selection[0] as ActorTreeNode;

                _tree.Select(node);
            }
            else
            {
                // Find nodes to select
                // TODO: if it takes too long let's cache hash set: (key: Actor.ID, value: SceneTreeNode) and use faster lookup
                var nodes = new List<TreeNode>(selection.Count);
                selectNodesHelper(nodes, selection, Root);

                // Select nodes
                _tree.Select(nodes);
            }

            _isUpdatingSelection = false;
        }

        /// <inheritdoc />
        public override void OnExit()
        {
            // Cleanup tree
            Root.DisposeChildren();
        }

        private void BuildSceneTree(ActorTreeNode node)
        {
            var children = node.Actor.GetChildren();
            for (int i = 0; i < children.Length; i++)
            {
                BuildSceneTree(node.AddChild(new ActorTreeNode(children[i])));
            }
        }

        /// <inheritdoc />
        public override void OnSceneLoaded(Scene scene, Guid sceneId)
        {
            var startTime = DateTime.UtcNow;

            // Build scene tree
            // TODO: make it faster by calling engine internaly only once to gather optimzied scene tree
            var sceneNode = new SceneTreeNode(scene);
            BuildSceneTree(sceneNode);
            sceneNode.Expand();

            // TODO: cache expanded/colapsed nodes per scene tree

            // Add to the tree
            bool wasLayoutLocked = Root.IsLayoutLocked;
            Root.IsLayoutLocked = true;
            Root.AddChild(sceneNode);
            Root.SortChildren();
            Root.IsLayoutLocked = wasLayoutLocked;
            Root.PerformLayout();

            var endTime = DateTime.UtcNow;
            var milliseconds = (int)(endTime - startTime).TotalMilliseconds;
            Debug.Log($"Created UI tree for scene \'{scene.Name}\' in {milliseconds} ms");
        }

        /// <inheritdoc />
        public override void OnSceneUnloading(Scene scene, Guid sceneId)
        {
            // Find scene tree node
            var node = Root.FindChild(scene);
            if (node != null)
            {
                Debug.Log($"Cleanup UI tree for scene \'{scene.Name}\'");

                // Cleanup
                node.Dispose();
            }
        }

        /// <inheritdoc />
        public override void Draw()
        {
            // Draw overlay
            string overlayText = null;
            var state = Editor.StateMachine.CurrentState;
            if (state is LoadingState)
            {
                overlayText = "Loading...";
            }
            else if (state is ChangingScenesState)
            {
                overlayText = "Loading scene...";
            }
            else if (Root.ChildrenCount == 0)
            {
                overlayText = "No scene";
            }
            if (overlayText != null)
            {
                Render2D.DrawText(Style.Current.FontLarge, overlayText, GetClientArea(), new Color(0.8f), TextAlignment.Center, TextAlignment.Center);
            }

            base.Draw();
        }
    }
}
