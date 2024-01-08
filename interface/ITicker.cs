public interface ITicker
{
	public void StartTick(ActionWithInput<FrameOfTime> handler);

	public void StopTick(ActionWithInput<FrameOfTime> handler);
}
