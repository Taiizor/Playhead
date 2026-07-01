namespace Playhead
{
    /// <summary>
    /// Specifies the now playing session type.
    /// </summary>
    public enum NowPlayingSessionType
    {
        /// <summary>
        /// The session type is unknown.
        /// </summary>
        Unknown = 0x0,

        /// <summary>
        /// The session is played remotely.
        /// </summary>
        PlayTo = 0x1,

        /// <summary>
        /// The session is local.
        /// </summary>
        Local = 0x2
    }
}
