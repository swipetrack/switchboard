
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

namespace Switchboard
{
	/// <summary> Represents information about the timing of a single frame in an update loop. </summary>
	public readonly struct FrameOfTime
	{
		/// <summary> The number of frames since the beginning of the loop. </summary>
		public int FrameCount { get; }

		/// <summary> The number of seconds, potentially paused or scaled, since the beginning of the loop. </summary>
		public float Time { get; }

		/// <summary> The number of seconds, potentially paused or scaled, since the last frame. </summary>
		public float Delta { get; }

		/// <summary> The number of seconds, unpaused and unscaled, since the beginning of the loop. </summary>
		public float RealTime { get; }

		/// <summary> The number of seconds, unpaused and unscaled, since the last frame. </summary>
		public float RealDelta { get; }

		/// <summary> Initializes a new instance of the structure. </summary>
		/// <param name="frameCount"> The number of frames since the beginning of the loop. </param>
		/// <param name="time"> The number of seconds, potentially paused or scaled, since the beginning of the loop. </param>
		/// <param name="delta"> The number of seconds, potentially paused or scaled, since the last frame. </param>
		/// <param name="realTime"> The number of seconds, unpaused and unscaled, since the beginning of the loop. </param>
		/// <param name="realDelta"> The number of seconds, unpaused and unscaled, since the last frame. </param>
		public FrameOfTime(int frameCount, float time, float delta, float realTime, float realDelta)
		{
			FrameCount = frameCount;
			Time = time;
			Delta = delta;
			RealTime = realTime;
			RealDelta = realDelta;
		}
	}
}
