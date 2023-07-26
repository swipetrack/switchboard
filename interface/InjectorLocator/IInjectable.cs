
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

namespace Switchboard
{
	/// <summary> Provides a generic interface for having a single dependency injected per type. </summary>
	public interface IInjectable
	{
		/// <summary> Provides an <see cref="IInjector"/> for dependency injection. </summary>
		/// <param name="injector"> The injector to use. </param>
		void Inject(IInjector injector);
	}
}
