
// Copyright © 2023 SwipeTrack Solutions
// The contents of this file are licensed under the MIT license in the file named MIT.txt or LICENSE.txt located in the nearest parent directory.

namespace Switchboard
{
	/// <summary> Represents a type of delegate similar to <see cref="System.Action{T}"/>, but utilizing an in parameter as a readonly reference.
	/// Because the parameter is an in parameter, the action cannot have a contravariant type parameter like <see cref="System.Action{T}"/>. </summary>
	/// <typeparam name="T"> The invariant type of the in parameter for the method the delegate encapsulates. </typeparam>
	/// <param name="input"> The in parameter for the method the delegate encapsulates. </param>
	public delegate void ActionIn<T>(in T input);
}
