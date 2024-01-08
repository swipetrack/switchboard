using System;
using System.Runtime.CompilerServices;

public interface ILogger
{
	void Log(LogLevel logLevel, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0);

	void Log(LogLevel logLevel, Exception exception, ReadOnlySpan<char> message);
}
