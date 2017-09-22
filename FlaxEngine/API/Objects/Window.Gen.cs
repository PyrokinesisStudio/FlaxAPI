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
	/// Provides the ability to create, configure, show, and manage the lifetime of windows.
	/// </summary>
	public partial class Window : Object
	{
		/// <summary>
		/// Creates the new managed window using the specified settings.
		/// </summary>
		/// <param name="settings">The settings.</param>
		/// <returns>Created window or null if failed.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static Window Create(CreateWindowSettings settings) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_Create(ref settings);
#endif
		}

		/// <summary>
		/// Gets or sets a value that indicates whether a window is in a fullscreen mode.
		/// </summary>
		[UnmanagedCall]
		public bool IsFullscreen
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetIsFullscreen(unmanagedPtr); }
			set { Internal_SetIsFullscreen(unmanagedPtr, value); }
#endif
		}

		/// <summary>
		/// Gets or sets a value that indicates whether a window is visible (hidden or shown).
		/// </summary>
		[UnmanagedCall]
		public bool IsVisible
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetIsVisible(unmanagedPtr); }
			set { Internal_SetIsVisible(unmanagedPtr, value); }
#endif
		}

		/// <summary>
		/// Gets a value that indicates whether a window is minimized.
		/// </summary>
		[UnmanagedCall]
		public bool IsMinimized
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetIsMinimized(unmanagedPtr); }
#endif
		}

		/// <summary>
		/// Gets a value that indicates whether a window is maximized.
		/// </summary>
		[UnmanagedCall]
		public bool IsMaximized
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetIsMaximized(unmanagedPtr); }
#endif
		}

		/// <summary>
		/// Gets or sets the position of the mouse in the window space coordinates.
		/// </summary>
		[UnmanagedCall]
		public Vector2 MousePosition
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector2 resultAsRef; Internal_GetMousePosition(unmanagedPtr, out resultAsRef); return resultAsRef; }
			set { Internal_SetMousePosition(unmanagedPtr, ref value); }
#endif
		}

		/// <summary>
		/// Gets the native window handle (platform specific).
		/// </summary>
		[UnmanagedCall]
		public IntPtr Handle
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetHandle(unmanagedPtr); }
#endif
		}

		/// <summary>
		/// Shows the window.
		/// </summary>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void Show() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_Show(unmanagedPtr);
#endif
		}

		/// <summary>
		/// Hides the window.
		/// </summary>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void Hide() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_Hide(unmanagedPtr);
#endif
		}

		/// <summary>
		/// Minimizes the window.
		/// </summary>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void Minimize() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_Minimize(unmanagedPtr);
#endif
		}

		/// <summary>
		/// Maximizes the window.
		/// </summary>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void Maximize() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_Maximize(unmanagedPtr);
#endif
		}

		/// <summary>
		/// Restores the window state before minimizing or maximazing.
		/// </summary>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void Restore() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_Restore(unmanagedPtr);
#endif
		}

		/// <summary>
		/// Closes the window.
		/// </summary>
		/// <param name="reason">The closing reason.</param>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void Close(ClosingReason reason = ClosingReason.CloseEvent) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_Close(unmanagedPtr, reason);
#endif
		}

		/// <summary>
		/// Gets or sets the client bounds of the window (client area not including border).
		/// </summary>
		[UnmanagedCall]
		public Rectangle ClientBounds
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Rectangle resultAsRef; Internal_GetClientBounds(unmanagedPtr, out resultAsRef); return resultAsRef; }
			set { Internal_SetClientBounds(unmanagedPtr, ref value); }
#endif
		}

		/// <summary>
		/// Gets or sets the window position (in screen coordinates).
		/// </summary>
		[UnmanagedCall]
		public Vector2 Position
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector2 resultAsRef; Internal_GetPosition(unmanagedPtr, out resultAsRef); return resultAsRef; }
			set { Internal_SetPosition(unmanagedPtr, ref value); }
#endif
		}

		/// <summary>
		/// Gets or sets the client position of the window (client area not including border).
		/// </summary>
		[UnmanagedCall]
		public Vector2 ClientPosition
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector2 resultAsRef; Internal_GetClientPosition(unmanagedPtr, out resultAsRef); return resultAsRef; }
			set { Internal_SetClientPosition(unmanagedPtr, ref value); }
#endif
		}

		/// <summary>
		/// Gets the window size (including border).
		/// </summary>
		[UnmanagedCall]
		public Vector2 Size
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector2 resultAsRef; Internal_GetSize(unmanagedPtr, out resultAsRef); return resultAsRef; }
#endif
		}

		/// <summary>
		/// Gets or sets the size of the client area of the window (not including border).
		/// </summary>
		[UnmanagedCall]
		public Vector2 ClientSize
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector2 resultAsRef; Internal_GetClientSize(unmanagedPtr, out resultAsRef); return resultAsRef; }
			set { Internal_SetClientSize(unmanagedPtr, ref value); }
#endif
		}

		/// <summary>
		/// Converts screen space location into window space coordinates.
		/// </summary>
		/// <param name="screenPos">The screen position.</param>
		/// <returns>The client space position.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public Vector2 ScreenToClient(Vector2 screenPos) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Vector2 resultAsRef;
			Internal_ScreenToClient(unmanagedPtr, ref screenPos, out resultAsRef);
			return resultAsRef;
#endif
		}

		/// <summary>
		/// Converts window space location into screen space coordinates.
		/// </summary>
		/// <param name="clientPos">The client position.</param>
		/// <returns>The screen space position.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public Vector2 ClientToScreen(Vector2 clientPos) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Vector2 resultAsRef;
			Internal_ClientToScreen(unmanagedPtr, ref clientPos, out resultAsRef);
			return resultAsRef;
#endif
		}

		/// <summary>
		/// Gets or sets window title.
		/// </summary>
		[UnmanagedCall]
		public string Title
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetTitle(unmanagedPtr); }
			set { Internal_SetTitle(unmanagedPtr, value); }
#endif
		}

		/// <summary>
		/// Gets or set window opacity value (vaild only for windows created with SupportsTransparency flag). Opacity values are normalized to range [0;1].
		/// </summary>
		[UnmanagedCall]
		public float Opacity
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetOpacity(unmanagedPtr); }
			set { Internal_SetOpacity(unmanagedPtr, value); }
#endif
		}

		/// <summary>
		/// Determines whether this window is focused.
		/// </summary>
		[UnmanagedCall]
		public bool IsFocused
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetIsFocused(unmanagedPtr); }
#endif
		}

		/// <summary>
		/// Focuses this window.
		/// </summary>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void Focus() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_Focus(unmanagedPtr);
#endif
		}

		/// <summary>
		/// Brings window to the front of the Z order.
		/// </summary>
		/// <param name="force">True if move to the front by force, otheriwse false.</param>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void BringToFront(bool force = false) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_BringToFront(unmanagedPtr, force);
#endif
		}

		/// <summary>
		/// Flashes the window to bring use attention.
		/// </summary>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void FlashWindow() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_FlashWindow(unmanagedPtr);
#endif
		}

		/// <summary>
		/// Starts drag and drop operation
		/// </summary>
		/// <param name="data">The data.</param>
		/// <returns>The result.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public DragDropEffect DoDragDrop(string data) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_DoDragDrop(unmanagedPtr, data);
#endif
		}

		/// <summary>
		/// Starts the mouse tracking.
		/// </summary>
		/// <param name="useMouseScreenOffset">If set to true will use mouse screen offset.</param>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void StartTrackingMouse(bool useMouseScreenOffset) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_StartTrackingMouse(unmanagedPtr, useMouseScreenOffset);
#endif
		}

		/// <summary>
		/// Ends the mouse tracking.
		/// </summary>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void EndTrackingMouse() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_EndTrackingMouse(unmanagedPtr);
#endif
		}

		/// <summary>
		/// Gets or sets the mouse cursor.
		/// </summary>
		[UnmanagedCall]
		public CursorType Cursor
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetCursor(unmanagedPtr); }
			set { Internal_SetCursor(unmanagedPtr, value); }
#endif
		}

		/// <summary>
		/// Gets mouse button state.
		/// </summary>
		/// <param name="button">Mouse button to check.</param>
		/// <returns>True if user holds down the button, otherwise false.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public bool GetMouseButton(MouseButtons button) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_GetMouseButton(unmanagedPtr, button);
#endif
		}

		/// <summary>
		/// Gets mouse button down state.
		/// </summary>
		/// <param name="button">Mouse button to check.</param>
		/// <returns>True if user starts pressing down the button, otherwise false.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public bool GetMouseButtonDown(MouseButtons button) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_GetMouseButtonDown(unmanagedPtr, button);
#endif
		}

		/// <summary>
		/// Gets mouse button up state.
		/// </summary>
		/// <param name="button">Mouse button to check.</param>
		/// <returns>True if user releases the button, otherwise false.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public bool GetMouseButtonUp(MouseButtons button) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_GetMouseButtonUp(unmanagedPtr, button);
#endif
		}

		/// <summary>
		/// Gets or sets value indicating whenever window rendering is enabled.
		/// </summary>
		[UnmanagedCall]
		public bool RenderingEnabled
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetRenderingEnabled(unmanagedPtr); }
			set { Internal_SetRenderingEnabled(unmanagedPtr, value); }
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Window Internal_Create(ref CreateWindowSettings settings);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetIsFullscreen(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetIsFullscreen(IntPtr obj, bool val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetIsVisible(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetIsVisible(IntPtr obj, bool val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetIsMinimized(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetIsMaximized(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetMousePosition(IntPtr obj, out Vector2 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetMousePosition(IntPtr obj, ref Vector2 val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern IntPtr Internal_GetHandle(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Show(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Hide(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Minimize(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Maximize(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Restore(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Close(IntPtr obj, ClosingReason reason);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetClientBounds(IntPtr obj, out Rectangle resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetClientBounds(IntPtr obj, ref Rectangle val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetPosition(IntPtr obj, out Vector2 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetPosition(IntPtr obj, ref Vector2 val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetClientPosition(IntPtr obj, out Vector2 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetClientPosition(IntPtr obj, ref Vector2 val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetSize(IntPtr obj, out Vector2 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetClientSize(IntPtr obj, out Vector2 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetClientSize(IntPtr obj, ref Vector2 val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_ScreenToClient(IntPtr obj, ref Vector2 screenPos, out Vector2 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_ClientToScreen(IntPtr obj, ref Vector2 clientPos, out Vector2 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string Internal_GetTitle(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetTitle(IntPtr obj, string val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern float Internal_GetOpacity(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetOpacity(IntPtr obj, float val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetIsFocused(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Focus(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_BringToFront(IntPtr obj, bool force);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_FlashWindow(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern DragDropEffect Internal_DoDragDrop(IntPtr obj, string data);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_StartTrackingMouse(IntPtr obj, bool useMouseScreenOffset);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_EndTrackingMouse(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern CursorType Internal_GetCursor(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetCursor(IntPtr obj, CursorType val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetKey(IntPtr obj, KeyCode key);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetKeyDown(IntPtr obj, KeyCode key);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetKeyUp(IntPtr obj, KeyCode key);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetMouseButton(IntPtr obj, MouseButtons button);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetMouseButtonDown(IntPtr obj, MouseButtons button);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetMouseButtonUp(IntPtr obj, MouseButtons button);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetRenderingEnabled(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetRenderingEnabled(IntPtr obj, bool val);
#endif
#endregion
	}
}

