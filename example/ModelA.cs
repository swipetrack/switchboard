using Switchboard;
using UnityEngine;

namespace SwitchboardExample
{
	[CreateAssetMenu(fileName = "ModelA", menuName = "Switchboard/Example/Model A", order = SwitchboardMenuOrder.Value)]
	public sealed class ModelA : ModelBase
	{
		public float Speed = 1.0f;
		private bool Initialized;

		public override void Tick(in FrameOfTime time)
		{
			if(!Initialized)
			{
				Initialized = true;
				Position = Vector3.forward * 10.0f;
			}
			float angle = 360.0f * Speed * time.Delta;
			Position = Quaternion.Euler(0.0f, angle, 0.0f) * Position;
		}
	}
}
