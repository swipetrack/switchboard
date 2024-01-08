public readonly struct FrameOfTime
{
	public int FrameCount { get; }
	public float Time { get; }
	public float Delta { get; }
	public float RealTime { get; }
	public float RealDelta { get; }

	public FrameOfTime(int frameCount, float time, float delta, float realTime, float realDelta)
	{
		FrameCount = frameCount;
		Time = time;
		Delta = delta;
		RealTime = realTime;
		RealDelta = realDelta;
	}
}
