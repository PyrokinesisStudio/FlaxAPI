// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using System;
using FlaxEngine;

namespace FlaxEditor.Content
{
    /// <summary>
    /// Content item that contains <see cref="FlaxEngine.Scene"/> data.
    /// </summary>
    /// <seealso cref="FlaxEditor.Content.JsonAssetItem" />
    public sealed class SceneItem : JsonAssetItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneItem"/> class.
        /// </summary>
        /// <param name="path">The asset path.</param>
        /// <param name="id">The asset identifier.</param>
        public SceneItem(string path, Guid id)
        : base(path, id, Scene.EditorPickerTypename)
        {
        }

        /// <inheritdoc />
        public override ContentDomain ItemDomain => ContentDomain.Scene;

        /// <inheritdoc />
        public override ContentItemType ItemType => ContentItemType.Scene;

        /// <inheritdoc />
        public override Sprite DefaultThumbnail => Editor.Instance.Icons.Scene64;
    }
}
