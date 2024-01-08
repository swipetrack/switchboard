using System;
using Switchboard;
using UnityEngine;

// Rename the class and configure the CreateAssetMenu attribute.
[CreateAssetMenu(fileName = nameof(ExampleInjector), menuName = "Switchboard/Example/Example Injector", order = SwitchboardMenuOrder.Value)]
public class ExampleInjector : BasicInjector
{
	// Example properties. Add your members here.
	[Expandable] public ModelBase Model;
	public SerializableClass ExampleData;

	protected override void Activation()
	{
		base.Activation();

		// Example activation code. Add your code here.
		if(Model != null)
			ApplicationTicker.StartTick(Model.TickAction);
	}

	protected override void Deactivation()
	{
		// Example deactivation code. Add your code here.
		if(Model != null)
			ApplicationTicker.StopTick(Model.TickAction);

		base.Deactivation();
	}

	public override T Get<T>()
	{
		Type type = typeof(T);

		// Example injection code. Provide instances of requested types here.
		if(type == typeof(IModel))
			return Model as T;

		return base.Get<T>();
	}
}
