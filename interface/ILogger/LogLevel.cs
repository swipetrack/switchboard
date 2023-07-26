
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

namespace Switchboard
{
	/// <summary> Defines the levels of significance that may be assigned to a log entry. </summary>
	public enum LogLevel
	{
		Exact,
		Debug,
		Information,
		Warning,
		Error,
		//Fatal = 5,
		None = 6,
	}
}
