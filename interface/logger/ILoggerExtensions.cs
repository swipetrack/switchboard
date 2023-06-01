
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

using System;
using System.Runtime.CompilerServices;

public static class ILoggerExtensions
{
	public static void LogError(this ILogger logger, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
	{
		logger.Log(LogLevel.Error, message, memberName, filePath, lineNumber);
	}

	public static void LogError(this ILogger logger, Exception exception, ReadOnlySpan<char> message)
	{
		logger.Log(LogLevel.Error, exception, message);
	}

	public static void LogWarning(this ILogger logger, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
	{
		logger.Log(LogLevel.Warning, message, memberName, filePath, lineNumber);
	}

	public static void LogWarning(this ILogger logger, Exception exception, ReadOnlySpan<char> message)
	{
		logger.Log(LogLevel.Warning, exception, message);
	}

	public static void LogInformation(this ILogger logger, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
	{
		logger.Log(LogLevel.Information, message, memberName, filePath, lineNumber);
	}

	public static void LogInformation(this ILogger logger, Exception exception, ReadOnlySpan<char> message)
	{
		logger.Log(LogLevel.Information, exception, message);
	}

	public static void LogDebug(this ILogger logger, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
	{
		logger.Log(LogLevel.Debug, message, memberName, filePath, lineNumber);
	}

	public static void LogDebug(this ILogger logger, Exception exception, ReadOnlySpan<char> message)
	{
		logger.Log(LogLevel.Debug, exception, message);
	}
}
