# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [1.0.1] - 2026-07-02

### Fixed
- **`MediaTimelineProperties`**: fixed a struct field-layout bug where, on modern target frameworks (`netstandard2.0+`, `net5.0+`, `netcoreapp`), auto-implemented properties declared after the `positionSetFileTime`/padding fields shifted the compiled field order out of alignment with the native COM struct, causing `StartTime` to read garbage data and `EndTime`/`MinSeekTime`/`MaxSeekTime`/`Position` to always read as zero.
- **`MediaPlaybackInfo`**: fixed the same class of struct field-layout bug affecting `PropsValid`, `PlaybackCaps`, `PlaybackState`, `PlaybackMode`, `RepeatMode`, and `PlaybackRate`.

Both structs now use explicit, correctly-ordered backing fields on every target framework, matching the verified layout of the underlying native `IMediaPlaybackDataSource` COM interface.

### Added
- NuGet package metadata: embedded `README.md` and package icon, [SourceLink](https://github.com/dotnet/sourcelink) support, and `.snupkg` symbol packages for a first-class debugging experience.
- Repository community health files: `CONTRIBUTING.md`, `SECURITY.md`, issue templates, pull request template, and `CODEOWNERS`.
- Continuous integration: build/verification workflow across the full target framework matrix, CodeQL security scanning, and a tag-triggered NuGet publish workflow.

### Security
- Pinned the transitive `System.Net.Http` and `System.Text.RegularExpressions` dependencies (pulled in by `NETStandard.Library` for the `netstandard1.x` targets) to patched versions, resolving [GHSA-7jgj-8wvc-jh57](https://github.com/advisories/GHSA-7jgj-8wvc-jh57) and [GHSA-cmhx-cq75-c4mj](https://github.com/advisories/GHSA-cmhx-cq75-c4mj).

## [1.0.0] - 2026-07-01

### Added
- Initial public release, modernized from [NPSMLib](https://github.com/ADeltaX/NPSMLib).
- Full `NowPlayingSessionManager` / System Media Transport Controls (SMTC) wrapper: session enumeration and tracking, media metadata retrieval, playback control (play/pause/next/previous/seek), and timeline properties.
- `AddSession` support for registering custom/fake media sessions.
- Broad target framework support: `netstandard1.1`–`netstandard2.1`, `netcoreapp3.0`/`3.1`, `net5.0`–`net11.0`, and `net45`–`net481`.
- Nullable reference type annotations and modern C# language features.
- Sample applications: modern .NET CLI, .NET Framework 4.6.2 CLI, a fake session provider, and a UWP media controller UI.

[Unreleased]: https://github.com/Taiizor/Playhead/compare/v1.0.1...HEAD
[1.0.1]: https://github.com/Taiizor/Playhead/compare/v1.0.0...v1.0.1
[1.0.0]: https://github.com/Taiizor/Playhead/releases/tag/v1.0.0