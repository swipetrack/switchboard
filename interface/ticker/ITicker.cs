
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

public interface ITicker
{
	void StartTick(InputAction<FrameOfTime> handler);
	void StartTick(InputAction<FrameOfTime> handler, int priority);
	void StopTick(InputAction<FrameOfTime> handler);
}
