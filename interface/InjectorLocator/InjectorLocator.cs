
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

namespace Switchboard
{
	/// <summary> Provides a static event that an <see cref="IInjectable"/> can invoke to locate an <see cref="IInjector"/>
	/// to call <see cref="IInjectable.Inject(IInjector)"/>. </summary>
	public static class InjectorLocator
	{
		/// <summary> Observers of this event should call <see cref="IInjectable.Inject(IInjector)"/> on the <see cref="IInjectable"/>. </summary>
		public static event System.Action<IInjectable> LocateInjector;

		/// <summary> Invokes an event for an <see cref="IInjectable"/> to locate an <see cref="IInjector"/> to call <see cref="IInjectable.Inject(IInjector)"/>. </summary>
		/// <param name="injectable"> The injectable requesting an <see cref="IInjector"/> from any event observer. </param>
		public static void Inject(IInjectable injectable)
		{
			if(injectable == null)
				ThrowArgumentNullException(nameof(injectable));

			LocateInjector?.Invoke(injectable);
		}

		private static void ThrowArgumentNullException(string paramName) => throw new System.ArgumentNullException(paramName);
	}
}
