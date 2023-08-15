using Switchboard;
using UnityEngine;

namespace SwitchboardExample
{
	[CreateAssetMenu(fileName = "ModelB", menuName = "Switchboard/Example/Model B", order = SwitchboardMenuOrder.Value)]
	public sealed class ModelB : ModelBase
	{
		public AnimationCurve VerticalMotion;
		private float Time;

		public override void Tick(in FrameOfTime time)
		{
			float startTime = 0.0f;
			int keyCount = VerticalMotion.length;
			if(keyCount < 2)
				Time = 0.0f;
			else
			{
				Time += time.Delta;
				startTime = VerticalMotion[0].time;
				float endTime = VerticalMotion[keyCount - 1].time;
				float animationLength = endTime - startTime;
				while(Time >= animationLength)
				{
					Time -= animationLength;
				}
			}
			Position = new Vector3(Position.x, VerticalMotion.Evaluate(startTime + Time), Position.z);
		}
	}
}
