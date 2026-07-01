# Playhead

![NuGet Version](https://img.shields.io/nuget/v/Playhead?style=for-the-badge&color=blue)
![License](https://img.shields.io/github/license/Taiizor/Playhead?style=for-the-badge)
![Frameworks](https://img.shields.io/badge/.NET-Standard_2.0_|_6.0_|_8.0_|_11.0-512BD4?style=for-the-badge&logo=dotnet)

**Playhead** is a modern, highly professional C# library that serves as a wrapper around the Windows NowPlayingSessionManager (NPSM) and System Media Transport Controls (SMTC) private APIs. 

Designed for **2026** and beyond, Playhead allows developers to seamlessly interact with media sessions across the system. It enables reading "Now Playing" data (metadata, timeline, playback status) and controlling media playback remotely for supported applications such as Spotify, Chrome, Edge, VLC, and Windows Media Player.

## Features
- **Full Media Metadata Access**: Retrieve title, artist, album, genres, and even high-quality thumbnail streams.
- **Playback Control**: Programmatically Play, Pause, Next, Previous, Stop, and seek timeline positions.
- **Session Tracking**: Monitor the lifecycle of all media sessions active on the Windows machine.
- **Modern .NET Support**: Targets `.NET Standard 2.0/2.1`, `.NET Framework 4.8+`, and `.NET 6.0` through `.NET 11.0`.
- **Nullable Reference Types**: Built with modern C# standards including null-safety and `LangVersion=latest`.

## Compatibility
Playhead requires **Windows 10 Version 1511 (Build 10586)** or newer.

*Note on UWP/WinUI*: If you are building a modern Windows App (UWP/WinUI 3), you must ensure your app manifest includes the `globalMediaControl` capability to avoid access denied exceptions.
```xml
<uap7:Capability Name="globalMediaControl" />
```

## Supported Applications
Playhead can interact with any application that integrates with the Windows SMTC APIs. For a comprehensive list of supported apps and browsers, check our [Supported Apps Documentation](./GSMTC-Support-And-Popular-Apps.md).

## Installation
You can install Playhead via the NuGet Package Manager:
```bash
dotnet add package Playhead
```

## Quick Start
```csharp
using Playhead;

// Initialize the Session Manager
var manager = new NowPlayingSessionManager();

// Get the current active session
var session = manager.CurrentSession;

if (session != null)
{
    var mediaInfo = session.GetMediaObjectInfo();
    Console.WriteLine($"Currently Playing: {mediaInfo.Title} by {mediaInfo.Artist}");
    
    // Pause the playback
    session.SendMediaPlaybackCommand(MediaPlaybackCommands.Pause);
}
```

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
Copyright © 2026 Taiizor
