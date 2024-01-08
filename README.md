# Switchboard

Switchboard is a dependency injection framework for the Unity game engine, and more. It provides a composition root where you can add code that runs when you play, in any scene. From there, you can initialize objects that MonoBehaviours get when they awake. Getting a dependency as an interface creates loose coupling, enabling modular design. You don't need to create singletons, or service locators, or load certain scenes before others. The composition root can be changed easily in the editor, perfect for testing and experimentation. An innovative design pattern allows Switchboard to completely avoid the costly reflection and code generation that other frameworks use.

Switchboard is highly compatible with other projects and plugins. Your MonoBehaviours don't need to inherit from a certain base class or implement an interface. There are no framework specific attributes or methods to add to your code base. Domain reload and scene reload can be disabled, so you can enter play mode instantly. The performance is beyond compare. Dependencies resolve in milliseconds, and there is no code generation necessary when making changes.

Switchboard also provides high performance log files. Log files can be used in debug or release builds with almost no impact on performance, and zero memory allocated for garbage collection. The StringMaker class is a direct replacement for StringBuilder. It allows you to append number variables to strings without allocating garbage memory, which is not possible with StringBuilder in Unity.

StringMaker can also render accurate floating-point numbers that standard C# can not. The standard C# methods for displaying floating-point numbers always round the real value to a limited number of digits, even in the debugger! StringMaker can reveal the true value of a floating-point number, formatted to your liking. These, and the other core modules work in any C# application, not just Unity.

Applying Switchboard to your project is sure to improve the quality of your application. Download Switchboard from the [Unity Asset Store](https://assetstore.unity.com/packages/tools/utilities/switchboard-250879) today.

## Unity Specific Features

- Dependency Injection
- Composition Root
- Update Any Object
- S.O.L.I.D. Code, Loose Coupling

## Universal C# Features

- High Performance Log Files
- Zero-Garbage Strings
- Accurate Floating-Point Values

________________

## Installation

The files contained in this repository only represent the interface, examples, and documentation. The full Switchboard package can be downloaded from the Unity Asset Store at https://assetstore.unity.com/packages/tools/utilities/switchboard-250879. Even if you only intend to use the core library for non-Unity applications, the package is licensed for purchase through the Unity Asset Store. Once downloaded, the core assemblies can be integrated with any C# application that targets .NET Standard 2.1 or above.

## Documentation

Please see the full documentation at https://swipetrack.github.io/switchboard.

## Forum

If you would like to discuss any topic please add your contribution to https://github.com/swipetrack/switchboard/discussions.

## Report an Issue

If you discover a bug, would like to request a feature, or have any other issue please contribute the issue to https://github.com/swipetrack/switchboard/issues.

## Direct Message

If you would like to send a direct message concerning Switchboard, email switchboard@swipetrack.com.
