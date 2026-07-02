# Contributing to Playhead

First off, thank you for considering contributing to **Playhead**! This document explains how to set up your environment, the conventions used in this repository, and the process for submitting changes.

## Table of Contents
- [Code of Conduct](#code-of-conduct)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Building & Running Samples](#building--running-samples)
- [Coding Guidelines](#coding-guidelines)
- [Working with the Native Interop Layer](#working-with-the-native-interop-layer)
- [Commit Message Convention](#commit-message-convention)
- [Branching & Pull Requests](#branching--pull-requests)
- [Reporting Bugs & Requesting Features](#reporting-bugs--requesting-features)

## Code of Conduct

This project adheres to a [Code of Conduct](.github/CODE_OF_CONDUCT.md). By participating, you are expected to uphold it.

## Prerequisites

- **Windows 10 (Build 10586)+** — Playhead wraps a Windows-only private API (NowPlayingSessionManager / SMTC), so all development and testing must happen on Windows.
- **.NET SDK** — install the latest [.NET SDK](https://dotnet.microsoft.com/download) that supports the target frameworks you intend to build. `global.json` pins the preferred SDK for this repo; `dotnet --version` should resolve to a compatible SDK via `rollForward`.
- **Visual Studio 2022+** (recommended) or any editor with C# / OmniSharp support.

## Getting Started

```powershell
git clone https://github.com/Taiizor/Playhead.git
cd Playhead
dotnet restore
dotnet build -c Release
```

The solution file is `Playhead.slnx` and can be opened directly in Visual Studio.

## Project Structure

```
src/
  Playhead/              # The library itself (packed and published to NuGet)
    Data/                # MediaPlaybackDataSource and related playback data APIs
    Enums/                # Public enums (playback state, capabilities, commands, ...)
    Interop/              # COM interop definitions (P/Invoke, PROPVARIANT, native structs)
    Managers/             # NowPlayingSessionManager
    Models/               # Public value types returned from native calls
    Sessions/             # NowPlayingSession / NowPlayingSessionInfo wrappers
samples/
  Playhead.Sample.CLI/           # Modern .NET console sample
  Playhead.Sample.CLI.FX462/     # .NET Framework 4.6.2 console sample
  Playhead.Sample.SessionProvider/ # Sample that registers a fake session (AddSession)
  Playhead.Sample.UWP/           # UWP/WinUI sample app
```

## Building & Running Samples

```powershell
# Build everything
dotnet build Playhead.slnx -c Release

# Run the modern CLI sample (requires something playing in an SMTC-integrated app)
dotnet run --project samples/Playhead.Sample.CLI

# Run the .NET Framework 4.6.2 sample
dotnet run --project samples/Playhead.Sample.CLI.FX462
```

Since Playhead targets a very wide matrix of frameworks (`netstandard1.1` through `net11.0`, and `net45` through `net481`), please build the **full matrix** before submitting a change that touches `src/Playhead`:

```powershell
dotnet build src/Playhead/Playhead.csproj -c Release
```

Watch the output for errors on every target framework, not just the one you developed against.

## Coding Guidelines

- Formatting and naming conventions are enforced via [`.editorconfig`](.editorconfig) — most editors will pick this up automatically.
- Nullable reference types (`Nullable=enable`) are already on for the library project; keep new public APIs null-safe.
- All new public members should have XML documentation comments (`GenerateDocumentationFile` is enabled, and missing docs on public members will raise `CS1591` warnings).
- Prefer the smallest, most surgical change that fully addresses the issue — avoid unrelated refactors in the same PR.

## Working with the Native Interop Layer

Playhead's public models (`MediaTimelineProperties`, `MediaPlaybackInfo`, etc.) are populated directly by COM calls into the internal Windows `NowPlayingSessionManager` API. This makes their exact field layout critical:

> **Rule of thumb:** Any struct marked `[StructLayout(LayoutKind.Sequential)]` that is filled by a native `out` parameter **must** use plain, explicitly-named private fields declared in the exact native order. **Never** use auto-implemented properties (`{ get; }`) for these structs — the compiler-generated backing field is emitted at the property's *textual* position in the source file, which can silently shift the struct's memory layout relative to what the native side actually writes, corrupting every field after the shift point. This exact bug affected `MediaTimelineProperties` and `MediaPlaybackInfo` prior to v1.0.1 (see [CHANGELOG.md](CHANGELOG.md)).

If you add a new native struct or extend an existing one, verify the layout with a native COM call (a fake IUnknown vtable is enough — see the reproduction technique used for the v1.0.1 fixes) rather than assuming the layout is correct because it compiles.

## Commit Message Convention

Commit messages in this repository follow a `<Type>: <short description>` style, for example:

```
Fix: Restore correct native struct layout for MediaPlaybackInfo
Feature: Implement AddSession method in NowPlayingSessionManager
Refactor: Split Enums and Models into individual files per type
Docs: Update README with legacy frameworks; add samples to slnx
```

Common types: `Fix`, `Feature`, `Refactor`, `Docs`, `Test`, `Chore`.

## Branching & Pull Requests

- The default development branch is `develop`. Please branch off `develop` and target your pull requests back at `develop`.
- Keep pull requests focused on a single concern; large, unrelated changes are harder to review and more likely to be rejected.
- Make sure `dotnet build src/Playhead/Playhead.csproj -c Release` succeeds across the full target framework matrix before requesting review.
- Reference any related issue in your PR description (e.g. `Fixes #123`).

## Reporting Bugs & Requesting Features

Please use the issue templates provided when opening a [new issue](https://github.com/Taiizor/Playhead/issues/new/choose). For security vulnerabilities, see [SECURITY.md](../.github/SECURITY.md) instead of opening a public issue.