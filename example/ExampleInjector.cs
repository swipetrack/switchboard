[CreateAssetMenu(fileName = nameof(ExampleInjector), menuName = "Switchboard/Example Injector", order = SwitchboardMenuOrder.Value)]
public class ExampleInjector : BasicInjector
{
	// Add properties.

	protected override void Activation()
	{
		base.Activation();

		// Activate your application.
	}

	protected override void Deactivation()
	{
		// Deactivate your application.

		base.Deactivation();
	}

	// Provide dependencies via IInjector.Get<T>().
	public override T Get<T>()
	{
		Type type = typeof(T);

		if(type == typeof(IService))
			return Service as T;

		return base.Get<T>();
	}
}
