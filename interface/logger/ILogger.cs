
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

using System;
using System.Runtime.CompilerServices;

public interface ILogger
{
	void Log(LogLevel logLevel, ReadOnlySpan<char> message, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0);
	void Log(LogLevel logLevel, Exception exception, ReadOnlySpan<char> message);
}
