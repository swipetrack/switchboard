using Switchboard;
using UnityEngine;

namespace SwitchboardExample
{
	public abstract class ModelBase : ScriptableObject, IModel
	{
		public Vector3 Position { get; protected set; }
		public Color Color => _color;
		[SerializeField] protected Color _color;

		public ActionIn<FrameOfTime> TickAction => _tickAction ??= Tick;
		private ActionIn<FrameOfTime> _tickAction;

		public virtual void Tick(in FrameOfTime time) { }
	}
}
