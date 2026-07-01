namespace Playhead.Enums
{
    /// <summary>
    /// Specifies the type of media playback data changed event.
    /// </summary>
    public enum MediaPlaybackDataChangedEvent
    {
        /// <summary>
        /// The playback information of the media playback changed.
        /// </summary>
        PlaybackInfoChanged = 0x0,

        /// <summary>
        /// The media information of the media playback changed.
        /// </summary>
        MediaInfoChanged = 0x1,

        /// <summary>
        /// The timeline properties of the media playback changed.
        /// </summary>
        TimelinePropertiesChanged = 0x2
    }
}