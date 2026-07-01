namespace Playhead
{
    /// <summary>
    /// Specifies the media playback commands that could be sent to a media session
    /// through the <see cref="MediaPlaybackDataSource.SendMediaPlaybackCommand(MediaPlaybackCommands)"/> method.
    /// </summary>
    public enum MediaPlaybackCommands
    {
        /// <summary>
        /// The play command.
        /// </summary>
        Play = 0x0,

        /// <summary>
        /// The pause command.
        /// </summary>
        Pause = 0x1,

        /// <summary>
        /// The stop command.
        /// </summary>
        Stop = 0x2,

        /// <summary>
        /// The record command.
        /// </summary>
        Record = 0x3,

        /// <summary>
        /// The fast forward command.
        /// </summary>
        FastForward = 0x4,

        /// <summary>
        /// The rewind command.
        /// </summary>
        Rewind = 0x5,

        /// <summary>
        /// The next command.
        /// </summary>
        Next = 0x6,

        /// <summary>
        /// The previous command.
        /// </summary>
        Previous = 0x7,

        /// <summary>
        /// The channel up command.
        /// </summary>
        ChannelUp = 0x8,

        /// <summary>
        /// The channel down command.
        /// </summary>
        ChannelDown = 0x9,

        /// <summary>
        /// The play/pause toggle command.
        /// </summary>
        PlayPauseToggle = 0xA,

        /// <summary>
        /// The max command.
        /// </summary>
        Max = 0xB
    }
}
