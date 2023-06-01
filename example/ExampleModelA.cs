using Switchboard;
using UnityEngine;

[CreateAssetMenu(fileName = "ExampleModelA", menuName = "Switchboard/Examples/Example Model A", order = SwitchboardMenuOrder.Value)]
public sealed class ExampleModelA : ExampleModelBase
{
	public float Speed = 1.0f;
	private bool Initialized;

	protected override void Tick(in FrameOfTime time)
	{
		if(Initialized == false)
		{
			Initialized = true;
			Position = Vector3.forward * 10.0f;
		}
		float angle = 360.0f * time.Delta * Speed;
		Position = Quaternion.Euler(0.0f, angle, 0.0f) * Position;
	}
}
