namespace Playhead.Enums
{
    /// <summary>
    /// Specifies the type of sessions changed notification.
    /// </summary>
    public enum NowPlayingSessionManagerNotificationType
    {
        /// <summary>
        /// A new session was created.
        /// </summary>
        SessionCreated = 0x0,

        /// <summary>
        /// The current session changed.
        /// </summary>
        CurrentSessionChanged = 0x1,

        /// <summary>
        /// A session was disconnected.
        /// </summary>
        SessionDisconnected = 0x2
    }
}
