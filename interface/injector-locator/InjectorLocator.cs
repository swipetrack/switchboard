
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

public static class InjectorLocator
{
	public static event System.Action<IInjectable> InjectionRequested;

	public static void RequestInjection(IInjectable injectable)
	{
		if(injectable == null)
			ThrowArgumentNullException(nameof(injectable));

		InjectionRequested?.Invoke(injectable);
	}

	private static void ThrowArgumentNullException(string paramName) => throw new System.ArgumentNullException(paramName);
}
