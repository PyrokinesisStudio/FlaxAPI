////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2018 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using FlaxEditor.Content.Settings;
using FlaxEditor.CustomEditors.Elements;
using FlaxEngine;
using FlaxEngine.GUI;

namespace FlaxEditor.CustomEditors.Editors
{
    /// <summary>
    /// Custom editor for picking actor layer. Instead of choosing bit mask or layer index it shows a combo box with simple layer picking by name.
    /// </summary>
    public sealed class ActorLayerEditor : CustomEditor
    {
        private ComboBoxElement element;

        /// <inheritdoc />
        public override DisplayStyle Style => DisplayStyle.Inline;

        /// <inheritdoc />
        public override void Initialize(LayoutElementsContainer layout)
        {
            element = layout.ComboBox();
            element.ComboBox.SelectedIndexChanged += OnSelectedIndexChanged;

            // Set layer names
            element.ComboBox.SetItems(LayersAndTagsSettings.GetCurrentLayers());
        }

	    private void GetActorsTree(List<Actor> list, Actor a)
	    {
			list.Add(a);
		    int cnt = a.ChildCount;
		    for (int i = 0; i < cnt; i++)
		    {
				GetActorsTree(list, a.GetChild(i));
		    }
	    }

	    private void OnSelectedIndexChanged(ComboBox comboBox)
	    {
		    int value = comboBox.SelectedIndex;
		    if (value == -1)
			    value = 0;

		    // If selected is single actor that has children, ask if apply flags to the sub objects as well
		    if (Values.IsSingleObject && (int)Values[0] != value && ParentEditor.Values[0] is Actor actor && actor.HasChildren)
		    {
			    var valueText = comboBox.SelectedItem;

				// Ask user
			    var result = MessageBox.Show(
				    string.Format("Do you want to change layer to \"{0}\" for all child actors as well?", valueText),
				    "Change actor layer", MessageBox.Buttons.YesNoCancel);
			    if (result == DialogResult.Cancel)
				    return;

			    if (result == DialogResult.Yes)
			    {
				    // Note: this possibly breaks the design a little bit
				    // But it's the easiest way to set value for selected actor and its children with one undo action
				    List<Actor> actors = new List<Actor>(32);
				    GetActorsTree(actors, actor);
				    using (new UndoMultiBlock(Editor.Instance.Undo, actors.ToArray(), "Change layer"))
				    {
					    for (int i = 0; i < actors.Count; i++)
					    {
						    actors[i].Layer = value;
					    }
				    }

				    return;
			    }
		    }

		    SetValue(value);
	    }

	    /// <inheritdoc />
        public override void Refresh()
        {
            if (HasDiffrentValues)
            {
                // TODO: support different values on many actor selected
            }
            else
            {
                element.ComboBox.SelectedIndex = (int)Values[0];
            }
        }
    }
}
