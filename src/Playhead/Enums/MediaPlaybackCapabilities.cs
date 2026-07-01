using System;

namespace Playhead.Enums
{
    /// <summary>
    /// Specifies the capabilities of a media playback.
    /// </summary>
    [Flags]
    public enum MediaPlaybackCapabilities
    {
        /// <summary>
        /// The media playback currently has no capabilities.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.Play"/> command.
        /// </summary>
        Play = 0x1,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.Pause"/> command.
        /// </summary>
        Pause = 0x2,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.Stop"/> command.
        /// </summary>
        Stop = 0x4,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.Record"/> command.
        /// </summary>
        Record = 0x8,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.FastForward"/> command.
        /// </summary>
        FastForward = 0x10,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.Rewind"/> command.
        /// </summary>
        Rewind = 0x20,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.Next"/> command.
        /// </summary>
        Next = 0x40,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.Previous"/> command.
        /// </summary>
        Previous = 0x80,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.ChannelUp"/> command.
        /// </summary>
        ChannelUp = 0x100,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.ChannelDown"/> command.
        /// </summary>
        ChannelDown = 0x200,

        /// <summary>
        /// The media playback currently supports the <see cref="MediaPlaybackCommands.PlayPauseToggle"/> command.
        /// </summary>
        PlayPauseToggle = 0x400,

        /// <summary>
        /// The media playback currently supports handling end-point changes.
        /// </summary>
        HandleEndpointChange = 0x800,

        /// <summary>
        /// The media playback currently supports changing its shuffle state.
        /// </summary>
        Shuffle = 0x1000,

        /// <summary>
        /// The media playback currently supports changing its repeat mode.
        /// </summary>
        Repeat = 0x2000,

        /// <summary>
        /// The media playback currently supports changing its playback rate.
        /// </summary>
        PlaybackRate = 0x4000,

        /// <summary>
        /// The media playback currently supports changing its playback position.
        /// </summary>
        PlaybackPosition = 0x8000
    }
}
