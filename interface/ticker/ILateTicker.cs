
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

public interface ILateTicker
{
	void StartLateTick(InputAction<FrameOfTime> handler);
	void StartLateTick(InputAction<FrameOfTime> handler, int priority);
	void StopLateTick(InputAction<FrameOfTime> handler);
}
