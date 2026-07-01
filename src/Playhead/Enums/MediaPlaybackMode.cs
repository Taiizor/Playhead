namespace Playhead
{
    /// <summary>
    /// Specifies the mode or type of a media playback.
    /// </summary>
    public enum MediaPlaybackMode
    {
        /// <summary>
        /// The media type is unknown.
        /// </summary>
        Unknown = 0x0,

        /// <summary>
        /// The media type is audio.
        /// </summary>
        Audio = 0x1,

        /// <summary>
        /// The media type is video.
        /// </summary>
        Video = 0x2,

        /// <summary>
        /// The media type is image.
        /// </summary>
        Image = 0x3,

        /// <summary>
        /// The media type is podcast.
        /// </summary>
        Podcast = 0x4,

        /// <summary>
        /// The media type is audio book.
        /// </summary>
        AudioBook = 0x5
    }
}
