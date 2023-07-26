
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

namespace Switchboard
{
	/// <summary> Provides an interface for observing an event that is invoked every time a frame of the application is updated. </summary>
	public interface ITicker
	{
		/// <summary> Adds an observer event handler to an event invoked once per update. </summary>
		/// <param name="handler"> The observer event handler to add. </param>
		public void StartTick(ActionIn<FrameOfTime> handler);

		/// <summary> Removes an observer event handler from the the event. </summary>
		/// <param name="handler"> The event handler to be removed. </param>
		public void StopTick(ActionIn<FrameOfTime> handler);
	}
}
