# Playhead

![NuGet Version](https://img.shields.io/nuget/v/Playhead?style=for-the-badge&color=blue)
![NuGet Downloads](https://img.shields.io/nuget/dt/Playhead?style=for-the-badge&color=blue)
![Build Status](https://img.shields.io/github/actions/workflow/status/Taiizor/Playhead/build.yml?branch=develop&style=for-the-badge&label=build)
![License](https://img.shields.io/github/license/Taiizor/Playhead?style=for-the-badge)
![.NET Standard 1.1](https://img.shields.io/badge/.NET_Standard-1.1-512BD4?style=for-the-badge&logo=dotnet)
![.NET Framework 4.5](https://img.shields.io/badge/.NET_Framework-4.5-512BD4?style=for-the-badge&logo=dotnet)
![.NET 8.0](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![.NET 11.0](https://img.shields.io/badge/.NET-11.0-512BD4?style=for-the-badge&logo=dotnet)

**Playhead** is a modern, highly professional C# library that serves as a wrapper around the Windows NowPlayingSessionManager (NPSM) and System Media Transport Controls (SMTC) private APIs.

Designed for **2026** and beyond, Playhead allows developers to seamlessly interact with media sessions across the system. It enables reading "Now Playing" data (metadata, timeline, playback status) and controlling media playback remotely for supported applications such as Spotify, Chrome, Edge, VLC, and Windows Media Player.

## Table of Contents
- [Features](#features)
- [Compatibility](#compatibility)
- [Supported Applications](#supported-applications)
- [Installation](#installation)
- [Quick Start](#quick-start)
- [Documentation](#documentation)
- [Contributing](#contributing)
- [Security](#security)
- [License](#license)

## Features
- **Full Media Metadata Access**: Retrieve title, artist, album, genres, and even high-quality thumbnail streams.
- **Playback Control**: Programmatically Play, Pause, Next, Previous, Stop, and seek timeline positions.
- **Session Tracking**: Monitor the lifecycle of all media sessions active on the Windows machine.
- **Modern & Legacy .NET Support**: Targets everything from `.NET Framework 4.5` and `.NET Standard 1.1` through `.NET 11.0`, covering `netstandard1.1`–`2.1`, `netcoreapp3.0`/`3.1`, `net5.0`–`net11.0`, and `net45`–`net481`.
- **Nullable Reference Types**: Built with modern C# standards including null-safety and `LangVersion=preview`.
- **Debugger-Friendly**: Ships with [SourceLink](https://github.com/dotnet/sourcelink) and symbol packages (`.snupkg`) for step-through debugging straight from NuGet.

## Compatibility
Playhead requires **Windows 10 Version 1511 (Build 10586)** or newer.

*Note on UWP/WinUI*: If you are building a modern Windows App (UWP/WinUI 3), you must ensure your app manifest includes the `globalMediaControl` capability to avoid access denied exceptions.
```xml
<uap7:Capability Name="globalMediaControl" />
```

## Supported Applications
Playhead can interact with any application that integrates with the Windows SMTC APIs. For a comprehensive list of supported apps and browsers, check our [Supported Apps Documentation](https://github.com/Taiizor/Playhead/blob/develop/GSMTC-Support-And-Popular-Apps.md).

## Installation
You can install Playhead via the NuGet Package Manager:
```bash
dotnet add package Playhead
```

## Quick Start
```csharp
using Playhead.Data;
using Playhead.Enums;
using Playhead.Managers;
using Playhead.Sessions;

// Initialize the Session Manager
var manager = new NowPlayingSessionManager();

// Get the current active session
NowPlayingSession session = manager.CurrentSession;

if (session != null)
{
    // Activate the playback data source to read metadata / control playback
    MediaPlaybackDataSource src = session.ActivateMediaPlaybackDataSource();

    MediaObjectInfo mediaInfo = src.GetMediaObjectInfo();
    Console.WriteLine($"Currently Playing: {mediaInfo.Title} by {mediaInfo.Artist}");

    // Pause the playback
    src.SendMediaPlaybackCommand(MediaPlaybackCommands.Pause);
}
```

### Reacting to Changes

Playhead raises events both when the active session changes and when the current session's playback data changes, so you don't have to poll:

```csharp
manager.SessionListChanged += (sender, args) =>
{
    NowPlayingSession session = manager.CurrentSession;

    if (session != null)
    {
        MediaPlaybackDataSource src = session.ActivateMediaPlaybackDataSource();
        src.MediaPlaybackDataChanged += (s, e) =>
        {
            MediaTimelineProperties timeline = src.GetMediaTimelineProperties();
            Console.WriteLine($"Position: {timeline.Position} / {timeline.EndTime}");
        };
    }
};
```

See the [samples](https://github.com/Taiizor/Playhead/tree/develop/samples) folder for complete, runnable console, .NET Framework, and UWP examples.

## Documentation
Playhead ships with full XML documentation comments, so IntelliSense will guide you through the entire public API directly in Visual Studio / VS Code / Rider. For deeper API exploration, browse the [`src/Playhead`](https://github.com/Taiizor/Playhead/tree/develop/src/Playhead) source directly.

## Contributing
Contributions are welcome! Please read [CONTRIBUTING.md](https://github.com/Taiizor/Playhead/blob/develop/CONTRIBUTING.md) for details on our development setup, coding guidelines, and the process for submitting pull requests.

## Security
If you discover a security vulnerability, please follow the responsible disclosure process described in [SECURITY.md](https://github.com/Taiizor/Playhead/blob/develop/SECURITY.md) rather than opening a public issue.

## License
This project is licensed under the MIT License - see the [LICENSE](https://github.com/Taiizor/Playhead/blob/develop/LICENSE) file for details.
Copyright © 2026 Taiizor