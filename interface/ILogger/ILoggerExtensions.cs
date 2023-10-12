
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

using System;
using System.Runtime.CompilerServices;

namespace Switchboard
{
	/// <summary> Provides extension methods for the <see cref="Switchboard.ILogger"/> interface that assign the <see cref="LogLevel"/> based on the method. </summary>
	public static class ILoggerExtensions
	{
		/// <summary> Logs a message with the <see cref="LogLevel"/> set to <see cref="LogLevel.Critical"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="message"> The log message. </param>
		/// <param name="memberName"> The name of the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="filePath"> The name of the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="lineNumber"> The line number within the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		public static void LogCritical(this ILogger logger, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
		{
			logger.Log(LogLevel.Critical, message, memberName, filePath, lineNumber);
		}

		/// <summary> Logs an exception with the <see cref="LogLevel"/> set to <see cref="LogLevel.Critical"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="exception"> The exception to log. </param>
		/// <param name="message"> A log message to be included with the exception. </param>
		public static void LogCritical(this ILogger logger, Exception exception, ReadOnlySpan<char> message)
		{
			logger.Log(LogLevel.Critical, exception, message);
		}

		/// <summary> Logs a message with the <see cref="LogLevel"/> set to <see cref="LogLevel.Error"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="message"> The log message. </param>
		/// <param name="memberName"> The name of the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="filePath"> The name of the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="lineNumber"> The line number within the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		public static void LogError(this ILogger logger, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
		{
			logger.Log(LogLevel.Error, message, memberName, filePath, lineNumber);
		}

		/// <summary> Logs an exception with the <see cref="LogLevel"/> set to <see cref="LogLevel.Error"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="exception"> The exception to log. </param>
		/// <param name="message"> A log message to be included with the exception. </param>
		public static void LogError(this ILogger logger, Exception exception, ReadOnlySpan<char> message)
		{
			logger.Log(LogLevel.Error, exception, message);
		}

		/// <summary> Logs a message with the <see cref="LogLevel"/> set to <see cref="LogLevel.Warning"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="message"> The log message. </param>
		/// <param name="memberName"> The name of the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="filePath"> The name of the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="lineNumber"> The line number within the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		public static void LogWarning(this ILogger logger, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
		{
			logger.Log(LogLevel.Warning, message, memberName, filePath, lineNumber);
		}

		/// <summary> Logs an exception with the <see cref="LogLevel"/> set to <see cref="LogLevel.Warning"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="exception"> The exception to log. </param>
		/// <param name="message"> A log message to be included with the exception. </param>
		public static void LogWarning(this ILogger logger, Exception exception, ReadOnlySpan<char> message)
		{
			logger.Log(LogLevel.Warning, exception, message);
		}

		/// <summary> Logs a message with the <see cref="LogLevel"/> set to <see cref="LogLevel.Information"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="message"> The log message. </param>
		/// <param name="memberName"> The name of the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="filePath"> The name of the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="lineNumber"> The line number within the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		public static void LogInformation(this ILogger logger, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
		{
			logger.Log(LogLevel.Information, message, memberName, filePath, lineNumber);
		}

		/// <summary> Logs an exception with the <see cref="LogLevel"/> set to <see cref="LogLevel.Information"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="exception"> The exception to log. </param>
		/// <param name="message"> A log message to be included with the exception. </param>
		public static void LogInformation(this ILogger logger, Exception exception, ReadOnlySpan<char> message)
		{
			logger.Log(LogLevel.Information, exception, message);
		}

		/// <summary> Logs a message with the <see cref="LogLevel"/> set to <see cref="LogLevel.Debug"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="message"> The log message. </param>
		/// <param name="memberName"> The name of the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="filePath"> The name of the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="lineNumber"> The line number within the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		public static void LogDebug(this ILogger logger, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
		{
			logger.Log(LogLevel.Debug, message, memberName, filePath, lineNumber);
		}

		/// <summary> Logs an exception with the <see cref="LogLevel"/> set to <see cref="LogLevel.Debug"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="exception"> The exception to log. </param>
		/// <param name="message"> A log message to be included with the exception. </param>
		public static void LogDebug(this ILogger logger, Exception exception, ReadOnlySpan<char> message)
		{
			logger.Log(LogLevel.Debug, exception, message);
		}

		/// <summary> Logs a message with the <see cref="LogLevel"/> set to <see cref="LogLevel.Trace"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="message"> The log message. </param>
		/// <param name="memberName"> The name of the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="filePath"> The name of the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="lineNumber"> The line number within the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		public static void LogTrace(this ILogger logger, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
		{
			logger.Log(LogLevel.Trace, message, memberName, filePath, lineNumber);
		}

		/// <summary> Logs an exception with the <see cref="LogLevel"/> set to <see cref="LogLevel.Trace"/>. </summary>
		/// <param name="logger"> The logger. </param>
		/// <param name="exception"> The exception to log. </param>
		/// <param name="message"> A log message to be included with the exception. </param>
		public static void LogTrace(this ILogger logger, Exception exception, ReadOnlySpan<char> message)
		{
			logger.Log(LogLevel.Trace, exception, message);
		}
	}
}
