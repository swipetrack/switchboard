using System;
using Switchboard;
using UnityEngine;

[CreateAssetMenu(fileName = "ExampleInjectorDerived", menuName = "Switchboard/Examples/Injector Derived", order = SwitchboardMenuOrder.Value)]
public sealed class ExampleInjectorDerived : StandardDependencyInjector
{
	[Expandable]
	public ExampleModelBase Model;

	protected override void Activation()
	{
		base.Activation();

		if(Model != null)
			ApplicationTicker.StaticInstance.StartTick(Model.TickAction);
	}

	protected override void Deactivation()
	{
		if(Model != null)
			ApplicationTicker.StaticInstance.StopTick(Model.TickAction);

		base.Deactivation();
	}

	protected override object GetInstanceOf(Type type)
	{
		if(type.IsAssignableFrom(TheTypeOf<ExampleModelBase>.Type))
			return Model;

		return base.GetInstanceOf(type);
	}
}
