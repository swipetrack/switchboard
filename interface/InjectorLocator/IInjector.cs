
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

namespace Switchboard
{
	/// <summary> Provides a generic interface for injecting a single dependency per type. </summary>
	public interface IInjector
	{
		/// <summary> Provides a reference to a specified type of dependency. </summary>
		/// <typeparam name="T"> The type of instance requested. </typeparam>
		/// <param name="dependency"> Contains the reference to the requested type. </param>
		/// <returns> Returns true if an instance of the requested type was provided successfully. </returns>
		bool Inject<T>(out T dependency) where T : class;
	}
}
