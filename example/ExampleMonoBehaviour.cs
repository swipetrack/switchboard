public class ExampleMonoBehaviour : MonoBehaviour
{
	private ILogger Logger;
	private IService RequiredDependency;

	private void OnEnable()
	{
		IInjector injector = InjectorLocator.GetInjector();

		// Get Logger
		Logger ??= injector?.Get<ILogger>();

		// Get Required Dependency
		RequiredDependency ??= injector?.Get<IService>();
		if(RequiredDependency == null)
		{
			enabled = false;
			Logger?.LogError("A required dependency was not provided!");
			return;
		}
	}

	private void OnDisable()
	{
		// If you release the reference OnDisable, a new instance can be injected OnEnable.
		RequiredDependency = null;
	}

	private void Start()
	{
		Logger?.LogInformation("Hello world! I definitely have my required dependencies!");
	}
}
