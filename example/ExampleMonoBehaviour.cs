using Switchboard;
using UnityEngine;
// Switchboard.ILogger aligns with the standard .NET System.ILogger interface.
// UnityEngine.ILogger does not, and is almost never referenced by those using UnityEngine.
using ILogger = Switchboard.ILogger;

namespace SwitchboardExample
{
	[RequireComponent(typeof(MeshRenderer))]
	public sealed class ExampleMonoBehaviour : MonoBehaviour, IInjectable
	{
		[Min(0.0f)]
		public float LogFrequency = 0.5f;
		private float Timer;
  
		private MeshRenderer Renderer;
		private ILogger Logger;
		private ITicker Ticker;
		private ActionIn<FrameOfTime> TickAction;
		private IModel Model;


		private void Awake()
		{
			Renderer = GetComponent<MeshRenderer>();
			TickAction = Tick;
			InjectorLocator.Inject(this);
		}

		void IInjectable.Inject(IInjector injector)
		{
			// In this example, the first instance injected from the root IInjector observing InjectorLocator.LocateInjector is assigned permanently.
			if(Ticker == null)
				injector.Inject(out Ticker);

			// In the following examples, nested Inject(IInjector) calls result in the later calls overriding the original.
   			// This can be used to implement nested, scene or context based dependency containers.
			if(injector.Inject(out ILogger logger))
			{
				if(Logger != null && Logger != logger)
					Logger.LogWarning("Logger override!");
				Logger = logger;
			}

			injector.Inject(out Model);
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

		// All of the changes that update the position and properties of the renderer components in the scene come from the model data, yet it is a loosely coupled dependency upon an interface.
		// This is not intended to imply that model data at the composition root should be moving MonoBehaviours around.
		// It is only meant to demonstrate how it is possible to keep models at the root of your application as pure C# objects, loosely coupled to scene data.
		private void UpdateRenderer()
		{
			if(Renderer != null && Model != null)
			{
				transform.position = Model.Position;
				if(Renderer.material.color != Model.Color)
					Renderer.material.color = Model.Color;
			}
		}

		// These logs are written to a persistent file on disk without allocating any new objects for garbage collection.
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
					StringMaker stringMaker = StringMaker.ThreadStaticInstance;
					stringMaker.Length = 0;
					stringMaker.Append("Position: ").Append(Model.Position)
						.Append(" Color: ").Append(Model.Color);
					Logger.LogInformation(stringMaker);
					stringMaker.Clear();
				}
			}
		}

		private void LogFloatingPointNumbers()
		{
			if(Logger != null)
			{
				StringMaker stringMaker = StringMaker.ThreadStaticInstance;
				float floatValue;
				double doubleValue;

				Logger.LogInformation("The float.ToString() method cannot render more than 7 significant digits, except when the \"G9\" format specifier is used. The double.ToString() method cannot render more than 15 significant digits, except when the \"G17\" format spefifier is used. There are many floating-point numbers that can never be accurately represented by using ToString(). Here are some examples of numbers that cannot be rendered with ToString(). However, the Switchboard ConvertToText() and StringMaker.Append() methods can render these values accurately in any format you choose.");

				floatValue = 1.4f;

				stringMaker.Length = 0;
				stringMaker.Append("float.ToString(): ").Append(floatValue.ToString())
					.Append("\nfloat.ConvertToText(): ").Append(floatValue);
				Logger.LogInformation(stringMaker);

				floatValue = 48103632896.0f;

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

				floatValue = 48103632896.0f;

				stringMaker.Length = 0;
				stringMaker.Append("float.ToString(\"############\"): ").Append(floatValue.ToString("############"))
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

				doubleValue = 6456360425798342656.0;

				stringMaker.Length = 0;
				stringMaker.Append("double.ToString(\"####################\"): ").Append(doubleValue.ToString("####################"))
					.Append("\ndouble.ConvertToText(): ").Append(doubleValue);
				Logger.LogInformation(stringMaker);

				doubleValue = 0.000000000000000444089209850062616169452667236328125;

				stringMaker.Length = 0;
				stringMaker.Append("double.ToString(\"0.####################################################\"): ").Append(doubleValue.ToString("0.####################################################"))
					.Append("\ndouble.ConvertToText(): ").Append(doubleValue);
				Logger.LogInformation(stringMaker);

				stringMaker.Clear();
			}
		}

	}
}
