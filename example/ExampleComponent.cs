using Switchboard;
using UnityEngine;
using ILogger = Switchboard.ILogger;

public sealed class ExampleComponent : MonoBehaviour, IInjectable
{
	[Min(0.0f)]
	public float LogFrequency = 0.5f;
	private float Timer;
	private ILogger Logger;
	private ITicker Ticker;
	private IExampleModel Model;
	private MeshRenderer Renderer;
	private InputAction<FrameOfTime> TickAction;


	private void Awake()
	{
		TickAction = Tick;
		Renderer = GetComponent<MeshRenderer>();
		InjectorLocator.RequestInjection(this);
	}

	void IInjectable.InjectWith(IInjector injector)
	{
		// In this example, the first non-null instance injected, from the first IInjector to observe InjectorLocator.InjectionRequested, is maintained.
		if(Ticker == null)
			injector.Inject(out Ticker);

		// In the following examples, multiple InjectWith(IInjector) calls result in the later calls overriding the original injection.
		if(injector.Inject(out ILogger logger))
		{
			if(Logger != null && Logger != logger)
				Logger.LogWarning("Logger override!");
			Logger = logger;
		}
		
		if(injector.Inject(out IExampleModel model))
			Model = model;
	}

	private void OnEnable()
	{
		Ticker?.StartTick(TickAction);
	}

	private void Start()
	{
		LogFloatingPointNumbers();
	}

	private void Tick(in FrameOfTime time)
	{
		UpdateRenderer();
		Log(time.RealDelta);
	}

	private void OnDisable()
	{
		Ticker?.StopTick(TickAction);
	}

	private void LogFloatingPointNumbers()
	{
		if(Logger != null)
		{
			StringMaker stringMaker = StringMaker.ThreadStaticInstance;
			float floatValue = 0.0f;
			double doubleValue = 0.0;

			Logger.LogInformation("The float.ToString() method cannot render more than 7 significant digits, except when the \"G9\" format specifier is used. The double.ToString() method cannot render more than 15 significant digits, except when the \"G17\" format spefifier is used. There are many floating-point numbers that can never be accurately represented by using ToString(). Here are some examples of numbers that cannot be rendered with ToString(). However, the Switchboard ConvertToText() and StringMaker.Append() methods can render these values accurately in any format you choose.");

			floatValue = 268435456.0f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(): ").Append(floatValue.ToString())
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			floatValue = 0.0001220703125f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(): ").Append(floatValue.ToString())
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			floatValue = 0.000000000000000000000000006462348535570528709932880406796584793482907116413116455078125f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(): ").Append(floatValue.ToString())
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			floatValue = 268435456.0f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(\"0.####################\"): ").Append(floatValue.ToString("0.####################"))
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			floatValue = 0.0000019073486328125f;

			stringMaker.Length = 0;
			stringMaker.Append("float.ToString(\"0.####################\"): ").Append(floatValue.ToString("0.####################"))
				.Append("\nfloat.ConvertToText(): ").Append(floatValue);
			Logger.LogInformation(stringMaker);

			doubleValue = 5192296858534827628530496329220096.0;

			stringMaker.Length = 0;
			stringMaker.Append("double.ToString(): ").Append(doubleValue.ToString())
				.Append("\ndouble.ConvertToText(): ").Append(doubleValue);
			Logger.LogInformation(stringMaker);

			doubleValue = 0.000000007450580596923828125;

			stringMaker.Length = 0;
			stringMaker.Append("double.ToString(): ").Append(doubleValue.ToString())
				.Append("\ndouble.ConvertToText(): ").Append(doubleValue);
			Logger.LogInformation(stringMaker);

			doubleValue = 36028797018963968.0;

			stringMaker.Length = 0;
			stringMaker.Append("double.ToString(\"0.###################################################\"): ").Append(doubleValue.ToString("0.###################################################"))
				.Append("\ndouble.ConvertToText(): ").Append(doubleValue);
			Logger.LogInformation(stringMaker);

			doubleValue = 0.000000000000000444089209850062616169452667236328125;

			stringMaker.Length = 0;
			stringMaker.Append("double.ToString(\"0.###################################################\"): ").Append(doubleValue.ToString("0.###################################################"))
				.Append("\ndouble.ConvertToText(): ").Append(doubleValue);
			Logger.LogInformation(stringMaker);

			stringMaker.Clear();
		}
	}

	// All of the changes that update the position and properties of the renderer components in the scene come from the IExampleModel, but it is only a loosely coupled dependency on an interface.
	private void UpdateRenderer()
	{
		if(Renderer != null && Model != null)
		{
			transform.position = Model.Position;
			if(Renderer.material.color != Model.Color)
				Renderer.material.color = Model.Color;
		}
	}

	private void Log(float realDeltaTime)
	{
		Timer += realDeltaTime;
		if(LogFrequency > 0.0f && Timer >= LogFrequency)
		{
			Timer -= LogFrequency;
			if(Timer >= LogFrequency)
				Timer = 0.0f;

			if(Model != null && Logger != null)
			{
				// These logs are all written to a persistent file on disk without allocating any new objects for garbage collection.
				StringMaker stringMaker = StringMaker.ThreadStaticInstance;
				stringMaker.Length = 0;
				stringMaker.Append("Position: ").Append(Model.Position)
					.Append(" Color: ").Append(Model.Color);
				Logger.LogInformation(stringMaker);
				stringMaker.Clear();
			}
		}
	}
}
