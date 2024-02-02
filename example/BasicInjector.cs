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
		public bool DisplayCallerInfo;

		[Tooltip("Gets or sets the hardware platforms where log files will be enabled.")]
		public PlatformFlags LogFilePlatforms = (PlatformFlags)532680447;


		protected override void Activation()
		{
			// Configure Switchboard logger.
			SwitchboardLogger.Root.LogLevel = LogLevel;
			UnityLogger.Default.DisplayCallerInfo = DisplayCallerInfo;

			// Activate log files.
			if(LogFilePlatforms.HasFlag(ApplicationPlatform.Flag))
			{
				GameObject logFileObject = new GameObject(nameof(FileLogger));
				DontDestroyOnLoad(logFileObject);
				logFileObject.hideFlags = HideFlags.HideInHierarchy;

				// Configure log files.
				FileLogger logFiles = logFileObject.AddComponent<FileLogger>();
				// Default Values:
				//logFiles.Directory = Application.persistentDataPath;
				//logFiles.FileNamePrefix = Application.productName.Replace(" ", "");
				//logFiles.FileExtension = LogFileWriter.DefaultFileExtension;
				//logFiles.FileSizeLimit = LogFileWriter.DefaultFileSizeLimit;
				//logFiles.DirectorySizeLimit = FileLogger.DefaultDirectorySizeLimit;
				//logFiles.Formatter = StandardLogFormatter.Default;
				logFiles.LogLevel = LogLevel;
				logFiles.DisplayCallerInfo = DisplayCallerInfo;
				logFiles.enabled = true;
				if(logFiles.enabled)
				{
					// Add log files to the root logger.
					SwitchboardLogger.Root.Add(logFiles);
					logFiles.Destroyed += static (ILogger logger) => SwitchboardLogger.Root.Remove(logger);

					// Send Debug.Log calls to the root logger, not directly to Unity's default logger.
					// The root logger still sends the messages to Unity's default logger, but they pass through the root first.
					SwitchboardLogger.HijackDebugLogHandler();

					if(!Application.isEditor)
					{
						// Remove Unity's default logger from the root logger, disabling Unity's log files outside of the editor.
						SwitchboardLogger.RemoveDefaultUnityLogger();
						logFiles.Destroyed += static (ILogger logger) => SwitchboardLogger.AddDefaultUnityLogger();
					}

					// Add hardware platform information directly to the log file.
					logFiles.LogInformation(PlatformStatLog.GetStatLog());
				}
				else
					Destroy(logFileObject);
			}
		}

		protected override void Deactivation()
		{
			// Send Debug.Log calls directly to Unity's default logger.
			SwitchboardLogger.RestoreDebugLogHandler();
		}

		public override T Get<T>()
		{
			Type type = typeof(T);

			if(type == typeof(ILogger))
				return SwitchboardLogger.Root as T;

			return null;
		}
	}
}
