using Switchboard;
using UnityEngine;

public abstract class ModelBase : ScriptableObject, IModel
{
	public Vector3 Position { get; protected set; }
	public Color Color => _color;
	[SerializeField] protected Color _color;

	public ActionWithInput<FrameOfTime> TickAction => _tickAction ??= Tick;
	private ActionWithInput<FrameOfTime> _tickAction;

	public virtual void Tick(in FrameOfTime time) { }
}
