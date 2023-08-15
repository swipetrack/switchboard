using System;
using Switchboard;
using UnityEngine;
using ILogger = Switchboard.ILogger;

namespace SwitchboardExample
{
	[CreateAssetMenu(fileName = "ExampleInjector", menuName = "Switchboard/Example/Dependency Injector", order = SwitchboardMenuOrder.Value)]
	public sealed class ExampleInjector : DependencyInjector
	{
		[Tooltip("Gets or sets the hardware platforms for which log files will be enabled.")]
		public PlatformFlags LogFilePlatforms = (PlatformFlags)532680447;

		private LogFileManager LogFileManager;

		// Example
		[Expandable]
		public ModelBase Model;

		[Expandable] public SerializableClass ExampleData;


		protected override void Activation()
		{
			// Enable Logger
			LogFileManager = new LogFileManager();
			if(LogFilePlatforms.HasFlag(ApplicationPlatform.Flag) && LogFileManager.StartLogging())
			{
				if(!Application.isEditor)
					SwitchboardLogger.RemoveUnityLogger();
				SwitchboardLogger.HijackUnityLogHandler();
			}

			// Synchronize time stamps to system clock.
			ClockSynchronizer.Start();


			// Example code. Add your code here.
			if(Model != null)
				ApplicationTicker.StartTick(Model.TickAction);
		}

		protected override void Deactivation()
		{
			// Example
			if(Model != null)
				ApplicationTicker.StopTick(Model.TickAction);


			// Disable Logger
			SwitchboardLogger.ResetUnityLogHandler();
			SwitchboardLogger.AddUnityLogger();
			LogFileManager.StopLogging();
			LogFileManager = null;
		}

		protected override object GetInstanceOf(Type type)
		{
			// This way of type comparison provides an instance only if the exact type is requested.
			if(type == typeof(ILogger))
				return SwitchboardLogger.RootInstance;

			if(type == typeof(ITicker))
				return ApplicationTicker.Ticker;

			// This way is more flexible and provides an instance to any type that accepts the assignment.
			if(type.IsAssignableFrom(typeof(ModelBase)))
				return Model;

			return null;
		}
	}
}
