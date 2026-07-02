# SMTC Support & Popular Applications

Playhead reads from and controls any application that integrates with Windows' **System Media Transport Controls (SMTC)** — the same mechanism that powers the media overlay you see on the lock screen, the volume flyout, and hardware media keys (play/pause/next/previous).

An app doesn't need to know about Playhead specifically: as long as it registers a media session with SMTC (via `Windows.Media.Playback.MediaPlayer`, `SystemMediaTransportControls`, or the web `MediaSession` API), Playhead can see it through `NowPlayingSessionManager`.

> This list is community-maintained and non-exhaustive — integration quality (album art, seek support, timeline accuracy) varies by app and version. If you find an app that works well (or doesn't), please [open a PR](CONTRIBUTING.md) or [issue](https://github.com/Taiizor/Playhead/issues) to help keep this list accurate.

## Browsers (via the web `MediaSession` API)

Any site that implements the [`MediaSession` API](https://developer.mozilla.org/en-US/docs/Web/API/MediaSession) will surface a session when played in a Chromium-based browser:

- Google Chrome
- Microsoft Edge
- Brave, Opera, Vivaldi, and other Chromium-based browsers
- Sites known to work well: YouTube, YouTube Music, Netflix, Spotify Web Player, SoundCloud, Twitch

> Firefox has more limited/partial `MediaSession` support depending on version and site.

## Native Desktop Media Players

- Windows Media Player (legacy and the modern Windows 11 rebuild)
- Groove Music / Movies & TV (built-in Windows apps)
- VLC Media Player (recent versions)
- foobar2000 (v1.5+, may require enabling the relevant output/plugin)
- MusicBee (via plugin)
- MediaMonkey
- AIMP
- PotPlayer
- Winamp (modern community builds)

## Streaming Applications

- Spotify (desktop app)
- iTunes / Apple Music for Windows
- TIDAL desktop app
- Deezer desktop app
- Amazon Music for Windows
- Plex desktop app

## Notes & Caveats

- **Timeline properties** (start/end/position) are only populated by apps that explicitly report them — some apps only expose metadata and playback state.
- **Multiple simultaneous sessions** are supported by SMTC; `NowPlayingSessionManager.CurrentSession` returns whichever session is currently "in focus," while `GetSessions()` (where available) can enumerate all active sessions.
- **UWP/WinUI apps** consuming Playhead must declare the `globalMediaControl` capability in their app manifest, or session enumeration will throw an access-denied exception:
  ```xml
  <uap7:Capability Name="globalMediaControl" />
  ```

## Contributing to This List

Found an app that isn't listed, or one that behaves unexpectedly? Please open a pull request updating this file, or [file an issue](https://github.com/Taiizor/Playhead/issues/new/choose) with the app name, version, and what you observed.