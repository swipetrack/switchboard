
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

using System;
using System.Runtime.CompilerServices;

namespace Switchboard
{
	/// <summary> Provides an interface for logging. </summary>
	public interface ILogger
	{
		/// <summary> Logs a message. </summary>
		/// <param name="logLevel"> The level of significance assigned to the message. </param>
		/// <param name="message"> The log message. </param>
		/// <param name="memberName"> The name of the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="filePath"> The name of the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		/// <param name="lineNumber"> The line number within the file that contains the member that called the method.
		/// Do not provide an argument. The compiler will automatically assign the correct value. </param>
		void Log(LogLevel logLevel, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0);

		/// <summary> Logs an exception. </summary>
		/// <param name="logLevel"> The level of significance assigned to the exception. </param>
		/// <param name="exception"> The exception to log. </param>
		/// <param name="message"> A log message to be included with the exception. </param>
		void Log(LogLevel logLevel, Exception exception, ReadOnlySpan<char> message);
	}
}
