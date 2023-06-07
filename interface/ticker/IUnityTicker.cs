
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

namespace Switchboard
{
	/// <summary> Provides an interface for adding observers to Update, LateUpdate, and FixedUpdate events. </summary>
	public interface IUnityTicker : ITicker
	{
		/// <summary> Adds an observer event handler to the late tick event, invoked at the end of each frame. </summary>
		/// <param name="handler"> The observer event handler to add. </param>
		void StartLateTick(InputAction<FrameOfTime> handler);

		/// <summary> Adds an observer event handler to the late tick event, invoked at the end of each frame. </summary>
		/// <param name="handler"> The observer event handler to add. </param>
		/// <param name="priority"> The order in which the event handler will be called. </param>
		void StartLateTick(InputAction<FrameOfTime> handler, int priority);

		/// <summary> Removes an observer event handler from the late tick event. </summary>
		/// <param name="handler"> The event handler to be removed. </param>
		void StopLateTick(InputAction<FrameOfTime> handler);

		/// <summary> Adds an observer event handler to the fixed tick event, invoked once per update of the physics state. </summary>
		/// <param name="handler"> The observer event handler to add. </param>
		void StartFixedTick(InputAction<FrameOfTime> handler);

		/// <summary> Adds an observer event handler to the fixed tick event, invoked once per update of the physics state. </summary>
		/// <param name="handler"> The observer event handler to add. </param>
		/// <param name="priority"> The order in which the event handler will be called. </param>
		void StartFixedTick(InputAction<FrameOfTime> handler, int priority);

		/// <summary> Removes an observer event handler from the fixed tick event. </summary>
		/// <param name="handler"> The event handler to be removed. </param>
		void StopFixedTick(InputAction<FrameOfTime> handler);
	}
}
