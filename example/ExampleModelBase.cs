using Switchboard;
using UnityEngine;

public abstract class ExampleModelBase : ScriptableObject, IExampleModel
{
	public Vector3 Position { get; protected set; }
	public Color Color => _color;
	public Color _color;

	public InputAction<FrameOfTime> TickAction => _tickAction ??= Tick;
	private InputAction<FrameOfTime> _tickAction;

	protected virtual void Tick(in FrameOfTime time) { }
}
