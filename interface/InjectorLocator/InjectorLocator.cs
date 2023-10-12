
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

namespace Switchboard
{
	/// <summary> Provides a static event that an IInjectable can invoke to locate an IInjector to call IInjectable.Inject(IInjector). </summary>
	public static class InjectorLocator
	{
		/// <summary> Observers of this event should call IInjectable.Inject(IInjector) on the IInjectable. </summary>
		public static event System.Action<IInjectable> LocateInjector;

		/// <summary> Invokes an event for an IInjectable to locate an IInjector to call IInjectable.Inject(IInjector). </summary>
		/// <param name="injectable"> The injectable requesting an IInjector. </param>
		public static void Inject(IInjectable injectable)
		{
			if(injectable == null)
				ThrowArgumentNullException(nameof(injectable));

			LocateInjector?.Invoke(injectable);
		}

		// Methods that throw exceptions cannot be inlined.
		private static void ThrowArgumentNullException(string paramName) => throw new System.ArgumentNullException(paramName);
	}
}
