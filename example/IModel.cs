using UnityEngine;

namespace SwitchboardExample
{
	public interface IModel
	{
		Vector3 Position { get; }
		Color Color { get; }
	}
}
