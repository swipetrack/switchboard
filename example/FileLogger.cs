using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Switchboard
{
	// Provides a helpful utility for using LogFileWriter objects in Unity.
	[DefaultExecutionOrder(31999)]
	public sealed class FileLogger : MonoBehaviour, ILogger
	{
		private LogFileWriter LogFileWriter;

		public string Path => LogFileWriter?.Path;

		[Tooltip("The component will automatically disable on Awake if this is true. Allows components created in script to set properties before enabling.")]
		[SerializeField] private bool DisableOnAwake = true;

		// The directory where log files will be created. Setting a new value disables the component.
		public string Directory { get => _Directory; set { _Directory = value; enabled = false; } }
		private string _Directory;

		[Tooltip("Log file names begin with this, but a timestamp will be added to ensure file names are different. Setting a new value disables the component.")]
		public string FileNamePrefix { get => _FileNamePrefix; set { _FileNamePrefix = value; enabled = false; } }
		[SerializeField][Delayed] private string _FileNamePrefix;

		[Tooltip("The file extension applied to the file name. Setting a new value disables the component.")]
		public string FileExtension { get => _FileExtension; set { _FileExtension = value; enabled = false; } }
		[SerializeField][Delayed] private string _FileExtension = LogFileWriter.DefaultFileExtension;

		[Tooltip("The maximum size of log files, in bytes. When a log file reaches the size limit a new file will be created.")]
		public int FileSizeLimit { get => _FileSizeLimit; set { if(LogFileWriter != null) LogFileWriter.FileSizeLimit = value; _FileSizeLimit = value; } }
		[SerializeField][Delayed][Min(LogFileWriter.MaxBytesPerLog)] private int _FileSizeLimit = LogFileWriter.DefaultFileSizeLimit;

		[Tooltip("The total number of bytes allowed for all log files in the log directory from this source. The newest file will not be removed.")]
		public int DirectorySizeLimit { get => _DirectorySizeLimit; set => _DirectorySizeLimit = value; }
		[SerializeField][Delayed] private int _DirectorySizeLimit = DefaultDirectorySizeLimit;
		public const int DefaultDirectorySizeLimit = 50_000_000;

		[Tooltip("The minimum log level for a log entry to be written.")]
		public LogLevel LogLevel { get => _LogLevel; set { if(LogFileWriter != null) LogFileWriter.LogLevel = value; _LogLevel = value; } }
		[SerializeField] private LogLevel _LogLevel;

		[Tooltip("Whether information about the caller of a log method should be displayed.")]
		public bool DisplayCallerInfo { get => _DisplayCallerInfo; set { if(LogFileWriter != null) LogFileWriter.DisplayCallerInfo = value; _DisplayCallerInfo = value; } }
		[SerializeField] private bool _DisplayCallerInfo;

		[Tooltip("How often to synchronize with the system clock, in seconds. This affects the time stamps in the standard log formatter.")]
		public float ClockSyncFrequency { get => _ClockSyncFrequency; set => _ClockSyncFrequency = value; }
		[SerializeField][Delayed][Min(0.0f)] private float _ClockSyncFrequency = DefaultClockSyncFrequency;
		public const float DefaultClockSyncFrequency = 2.0f;
		private float ClockSyncTimer;

		// The formatter to use for formatting log entries.
		public ILogFormatter Formatter { get => _Formatter; set { if(LogFileWriter != null) LogFileWriter.Formatter = value; _Formatter = value; } }
		private ILogFormatter _Formatter = StandardLogFormatter.Default;

		public event Action<ILogger> Destroyed;


		public void Log(LogLevel logLevel, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
		{
			LogFileWriter?.Log(logLevel, message, memberName, filePath, lineNumber);
		}

		public void Log(LogLevel logLevel, Exception exception, ReadOnlySpan<char> message)
		{
			LogFileWriter?.Log(logLevel, exception, message);
		}

		private void OnValidate()
		{
			InitializePathProperties();
		}

		private void Awake()
		{
			InitializePathProperties();
			if(DisableOnAwake)
				enabled = false;
		}

		private void InitializePathProperties()
		{
			if(string.IsNullOrEmpty(_Directory))
				_Directory = Application.persistentDataPath;
			if(string.IsNullOrEmpty(_FileNamePrefix))
				_FileNamePrefix = Application.productName.Replace(" ", "");
		}

		private void OnEnable()
		{
			// Setting LogFileWriter.FileSizeLimit can throw an exception if the value is set too low, below LogFileWriter.MaxBytesPerLog.
			FileSizeLimit = Math.Max(FileSizeLimit, LogFileWriter.MaxBytesPerLog);

			// If the path has changed, flush any remaining log entries, then close the file. Set the LogFileWriter null so we can make a new one.
			if(LogFileWriter != null)
			{
				bool pathChanged = LogFileWriter.Directory != Directory;
				pathChanged |= LogFileWriter.FileNamePrefix != FileNamePrefix;
				pathChanged |= LogFileWriter.FileExtension != FileExtension;
				if(pathChanged)
				{
					FlushAndCloseLogFile();
					LogFileWriter = null;
				}
			}

			// Create a new LogFileWriter object. If it succeeds, the path arguments contain valid characters. Disable on failure.
			if(LogFileWriter == null)
			{
				try
				{
					LogFileWriter = new LogFileWriter(Directory, FileNamePrefix, FileExtension, FileSizeLimit, Formatter);
					LogFileWriter.FileClosed += RemoveExcessLogFiles;
				}
				catch(Exception exception)
				{
					Debug.LogException(exception);
					enabled = false;
				}
			}

			// Ensure the LogFileWriter has the latest properties. Try to open the file. Disable on failure.
			if(LogFileWriter != null)
			{
				LogFileWriter.LogLevel = LogLevel;
				LogFileWriter.DisplayCallerInfo = DisplayCallerInfo;
				LogFileWriter.Formatter = Formatter;
				try
				{
					LogFileWriter.FileSizeLimit = FileSizeLimit;
					LogFileWriter.Open();
				}
				catch(Exception exception)
				{
					Debug.LogException(exception);
					enabled = false;
				}
			}
		}

		private void Update()
		{
			FileSizeLimit = Math.Max(FileSizeLimit, LogFileWriter.MaxBytesPerLog);

			// Synchronize the PreciseClock used by the StandardLogFormatter for timestamps with the system clock.
			ClockSyncTimer += Time.unscaledDeltaTime;
			ClockSyncFrequency = Math.Max(ClockSyncFrequency, 0.0f);
			if(ClockSyncTimer < -ClockSyncFrequency)
				ClockSyncTimer = 0.0f;
			if(ClockSyncTimer >= ClockSyncFrequency)
			{
				PreciseClock.SynchronizeWithSystemClock();
				ClockSyncTimer -= ClockSyncFrequency;
				if(ClockSyncTimer >= ClockSyncFrequency)
					ClockSyncTimer = 0.0f;
			}

			// Ensure that the LogFileWriter has the latest property values. Disable if the path has changed.
			if(LogFileWriter != null)
			{
				bool pathChanged = LogFileWriter.Directory != Directory;
				pathChanged |= LogFileWriter.FileNamePrefix != FileNamePrefix;
				pathChanged |= LogFileWriter.FileExtension != FileExtension;
				if(!pathChanged)
				{
					LogFileWriter.LogLevel = LogLevel;
					LogFileWriter.DisplayCallerInfo = DisplayCallerInfo;
					LogFileWriter.Formatter = Formatter;
					LogFileWriter.FileSizeLimit = FileSizeLimit;
				}
				else
					enabled = false;
			}
		}

		private void LateUpdate()
		{
			FlushLogs();
		}

		public void FlushLogs()
		{
			LogFileWriter?.FlushLogs();
		}

		private void OnDisable()
		{
			FlushAndCloseLogFile();
		}

		private void FlushAndCloseLogFile()
		{
			if(LogFileWriter != null)
			{
				try
				{
					LogFileWriter.FlushLogs();
				}
				catch(Exception exception)
				{
					Debug.LogException(exception);
				}
				try
				{
					LogFileWriter.Close();
				}
				catch(Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private void OnDestroy()
		{
			LogFileWriter = null;
			Destroyed?.Invoke(this);
		}

		public void RemoveExcessLogFiles()
		{
			RemoveLogFilesBeyondLimit(LogFileWriter, DirectorySizeLimit);
		}

		public void RemoveLogFilesBeyondLimit(int byteLimit)
		{
			RemoveLogFilesBeyondLimit(LogFileWriter, byteLimit);
		}

		private void RemoveExcessLogFiles(LogFileWriter logFileWriter)
		{
			RemoveLogFilesBeyondLimit(logFileWriter, DirectorySizeLimit);
		}

		private void RemoveLogFilesBeyondLimit(LogFileWriter logFileWriter, int byteLimit)
		{
			if(logFileWriter != null)
			{
				try
				{
					FileRemover.RemoveFilesBeyondLimit(byteLimit, logFileWriter.Directory, logFileWriter.FileNamePrefix, logFileWriter.FileExtension, true);
				}
				catch(Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}
	}
}
