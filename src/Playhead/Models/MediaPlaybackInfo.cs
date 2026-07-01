using System;
using System.Runtime.InteropServices;

namespace Playhead.Models
{
    /// <summary>
    /// The structure that holds all the playback information about a media session.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MediaPlaybackInfo
    {
        private readonly int shuffleEnabled;

        //20279
        private readonly long lastPlayingFileTime;

        //For future changes etc.. (prevents crash btw)
        private readonly long padding1;

        private readonly long padding2;
        private readonly long padding3;
        private readonly long padding4;

        /// <summary>
        /// Gets a value indicating which properties of <see cref="MediaPlaybackInfo"/> are valid.
        /// </summary>
        public MediaPlaybackProps PropsValid { get; }

        /// <summary>
        /// Gets the capabilities of the media playback.
        /// </summary>
        public MediaPlaybackCapabilities PlaybackCaps { get; }

        /// <summary>
        /// Gets the state of the media playback.
        /// </summary>
        public MediaPlaybackState PlaybackState { get; }

        /// <summary>
        /// Gets the mode or type of the media playback.
        /// </summary>
        public MediaPlaybackMode PlaybackMode { get; }

        /// <summary>
        /// Gets the auto-repeat mode of the media playback.
        /// </summary>
        public MediaPlaybackRepeatMode RepeatMode { get; }

        /// <summary>
        /// Gets the rate of the media playback.
        /// </summary>
        public double PlaybackRate { get; }

        /// <summary>
        /// Gets the shuffle state of the media playback.
        /// </summary>
        public bool ShuffleEnabled => shuffleEnabled != 0;

        //20279
        /// <summary>
        /// Gets the last playing time of the media playback.
        /// </summary>
        public DateTime LastPlayingFileTime => DateTime.FromFileTime(lastPlayingFileTime);
    }
}