using System;
using UnityEngine;

namespace Switchboard
{
	[CreateAssetMenu(fileName = nameof(BasicInjector), menuName = "Switchboard/Basic Injector", order = SwitchboardMenuOrder.Value)]
	public class BasicInjector : DependencyInjector
	{
		[Tooltip("Sets the log level at activation.")]
		public LogLevel LogLevel;

		[Tooltip("Sets whether the log should display caller info.")]
		public bool DisplayCallerInfo = true;

		[Tooltip("Gets or sets the hardware platforms where log files will be enabled.")]
		public PlatformFlags LogFilePlatforms = (PlatformFlags)532680447;

		private LogFileManager LogFileManager;

		protected override void Activation()
		{
			// Configure logger.
			SwitchboardLogger.Root.LogLevel = LogLevel;
			UnityLogger.StaticInstance.DisplayCallerInfo = DisplayCallerInfo;

			// Activate log files.
			if(LogFilePlatforms.HasFlag(ApplicationPlatform.Flag))
			{
				LogFileManager = new LogFileManager();
				LogFileManager.DisplayCallerInfo = DisplayCallerInfo;
				if(LogFileManager.StartLogging())
				{
					SwitchboardLogger.HijackUnityLogHandler();
					if(!Application.isEditor)
						SwitchboardLogger.RemoveUnityLogger();
				}
			}

			// Periodically synchronize time stamps to system clock.
			ClockSynchronizer.Start();
		}

		protected override void Deactivation()
		{
			ClockSynchronizer.Stop();

			// Reset logger.
			SwitchboardLogger.AddUnityLogger();
			SwitchboardLogger.ResetUnityLogHandler();
			LogFileManager?.StopLogging();
			LogFileManager = null;
		}

		public override T Get<T>()
		{
			Type type = typeof(T);

			if(type == typeof(Switchboard.ILogger))
				return SwitchboardLogger.Root as T;

			if(type == typeof(ITicker))
				return ApplicationTicker.Ticker as T;

			return null;
		}
	}
}
