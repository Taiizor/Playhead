namespace Playhead.Enums
{
    /// <summary>
    /// Specifies the state of a media playback.
    /// </summary>
    public enum MediaPlaybackState
    {
        /// <summary>
        /// The media playback state is unknown.
        /// </summary>
        Unknown = 0x0,

        /// <summary>
        /// The media playback closed.
        /// </summary>
        Closed = 0x1,

        /// <summary>
        /// The media playback opened.
        /// </summary>
        Opened = 0x2,

        /// <summary>
        /// The media playback is changing.
        /// </summary>
        Changing = 0x3,

        /// <summary>
        /// The media playback is stopped.
        /// </summary>
        Stopped = 0x4,

        /// <summary>
        /// The media playback is playing.
        /// </summary>
        Playing = 0x5,

        /// <summary>
        /// The media playback is paused.
        /// </summary>
        Paused = 0x6
    }
}
