namespace Playhead.Enums
{
    /// <summary>
    /// Specifies the repeat mode for media playback.
    /// </summary>
    public enum MediaPlaybackRepeatMode
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0x0,

        /// <summary>
        /// No repeating.
        /// </summary>
        None = 0x1,

        /// <summary>
        /// Repeat the current track.
        /// </summary>
        Track = 0x2,

        /// <summary>
        /// Repeat the current list of tracks.
        /// </summary>
        List = 0x3
    }
}
