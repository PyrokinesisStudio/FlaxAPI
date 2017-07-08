////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
	/// <summary>
	/// Renders model on the screen.
	/// </summary>
	public sealed partial class ModelActor : Actor
	{
		/// <summary>
		/// Creates new <see cref="ModelActor"/> object.
		/// </summary>
		private ModelActor() : base()
		{
		}

		/// <summary>
		/// Creates new instance of <see cref="ModelActor"/> object.
		/// </summary>
		/// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static ModelActor New() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_Create(typeof(ModelActor)) as ModelActor;
#endif
		}

		/// <summary>
		/// Gets or sets model scale in lightmap parameter
		/// </summary>
		[UnmanagedCall]
		public float ScaleInLightmap
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetScaleInLightmap(unmanagedPtr); }
			set { Internal_SetScaleInLightmap(unmanagedPtr, value); }
#endif
		}

		/// <summary>
		/// Gets or sets model asset
		/// </summary>
		[UnmanagedCall]
		public Model Model
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetModel(unmanagedPtr); }
			set { Internal_SetModel(unmanagedPtr, value); }
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern float Internal_GetScaleInLightmap(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetScaleInLightmap(IntPtr obj, float val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Model Internal_GetModel(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetModel(IntPtr obj, Model val);
#endif
#endregion
	}
}

