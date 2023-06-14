# Switchboard

Switchboard is an application framework for the Unity game engine.
It provides a composition root so you can define what happens when the application runs, regardless of which scenes are loaded.
Also, dependency injection so your classes can have loose dependencies that are automatically injected at run time.
It even works when adding new objects to a scene at run time.
You don't need Monobehaviour singletons or special scenes to load first! It just works! No reflection! No baking!
Any object you create, meaning any non-MonoBehaviour, can be automatically updated with the game loop.
The core library provides persistent log files, and garbage-free string manipulation to any C# application, not just Unity.
Every feature has been meticulously crafted for maximum stability and performance.

#### Unity

Switchboard is a Unity framework for composing your application and injecting dependencies automatically when objects are instantiated.

- Composition Root
- Automatic Dependency Injection
- Update Any Object
- Encourages Best Practices, S.O.L.I.D. Programming, Loose Coupling, Clean Code Architecture

#### C# Core

The core library contains Unity-independent features that can be used in any C# application.

- High Performance Log Files
- A Better StringBuilder
- Render Number Values that ToString() Cannot
- Eliminates Garbage Collection

________________

## Installation

The files contained in this repository only represent the interface, examples, and documentation pages. The full Switchboard package can be downloaded from the Unity Asset Store at https://assetstore.unity.com/packages/slug/250879. (This link is not active yet, as I am waiting for Asset Store approval from Unity. I am # 1905 in queue as of 6-14-2023. Based on the current pace through the queue I predict that Switchboard may be available some time around July 17th 2023.) Even if you only intend to use the core library for a non-Unity application, the package is licensed for purchase through the Unity Asset Store. Once downloaded, the SwitchboardCore.dll can be migrated to any C# application that targets .NET Standard 2.1 or above.

## Documentation

Please view the full documentation at https://swipetrack.github.io/switchboard.

## Forum

If you would like to discuss any topic please add your contribution to https://github.com/swipetrack/switchboard/discussions.

## Report an Issue

If you discover a bug, would like to request a feature, or have any other issue please contribute the issue to https://github.com/swipetrack/switchboard/issues.

## Direct Message

If you would like to send a direct message concerning Switchboard, email rmoon@swipetrack.com with "Switchboard" somewhere in the subject line.
