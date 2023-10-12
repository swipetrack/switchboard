# Switchboard

Switchboard is an application framework for the Unity game engine.
It provides a composition root to define what executes when the application starts playing, regardless of which scenes are loaded.
Dependency injection allows your classes to have loosely coupled dependencies that are automatically injected at run time.
It even works when adding new objects that are instantiated at run time.
You don't need singletons or special scenes to load first. It just works! No reflection, no baking.
Switchboard supports maximum compatibility with other plugins and code bases.
There is no need to inherit from a special base class, or establish tightly coupled dependencies.
Switchboard is also a logging framework. 
The core library provides persistent log files, and garbage-free string operations for any C# application, not just Unity.
Any object, including any non-MonoBehaviour, can be updated in the game loop via the static ApplicationTicker.
Every feature has been meticulously crafted for maximum stability and performance.
Switchboard is built on a system of collections that pool shared memory in universally re-usable memory pools.
The core library is thread safe, and fast.
Integrating with Switchboard will undoubtedly improve the architecture and performance of your applications.

## Unity Specific Features

- Dependency Injection
- Composition Root
- Update Any Object
- S.O.L.I.D. Code, Loose Coupling

## Universal C# Features

- High Performance Log Files
- Better String Handling
- Zero Garbage
- Render Number Values that .NET Cannot

________________

## Installation

The files contained in this repository only represent the interface, examples, and documentation pages. The full Switchboard package can be downloaded from the Unity Asset Store at https://assetstore.unity.com/packages/slug/250879. Even if you only intend to use the core library for a non-Unity application, the package is licensed for purchase through the Unity Asset Store. Once downloaded, the SwitchboardCore.dll can be migrated to any C# application that targets .NET Standard 2.1 or above.

## Documentation

Please view the full documentation at https://swipetrack.github.io/switchboard.

## Forum

If you would like to discuss any topic please add your contribution to https://github.com/swipetrack/switchboard/discussions.

## Report an Issue

If you discover a bug, would like to request a feature, or have any other issue please contribute the issue to https://github.com/swipetrack/switchboard/issues.

## Direct Message

If you would like to send a direct message concerning Switchboard, email switchboard@swipetrack.com.
