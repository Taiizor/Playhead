namespace Playhead.Enums
{
    /// <summary>
    /// Specifies which properties of <see cref="MediaPlaybackInfo"/> are valid.
    /// </summary>
    [Flags]
    public enum MediaPlaybackProps
    {
        /// <summary>
        /// The <see cref="MediaPlaybackInfo.PlaybackCaps"/> property is valid.
        /// </summary>
        Capabilities = 0x1,

        /// <summary>
        /// The <see cref="MediaPlaybackInfo.PlaybackState"/> property is valid.
        /// </summary>
        State = 0x2,

        /// <summary>
        /// The <see cref="MediaPlaybackInfo.PlaybackMode"/> property is valid.
        /// </summary>
        Mode = 0x4,

        /// <summary>
        /// The <see cref="MediaPlaybackInfo.RepeatMode"/> property is valid.
        /// </summary>
        AutoRepeatMode = 0x8,

        /// <summary>
        /// The <see cref="MediaPlaybackInfo.PlaybackRate"/> property is valid.
        /// </summary>
        PlaybackRate = 0x10,

        /// <summary>
        /// The <see cref="MediaPlaybackInfo.ShuffleEnabled"/> property is valid.
        /// </summary>
        ShuffleEnabled = 0x20
    }
}