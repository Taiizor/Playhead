using System;

namespace Playhead.Models
{
    /// <summary>
    /// Represents arguments for a <see cref="NowPlayingSessionManager.SessionListChanged"/> event.
    /// </summary>
    public class NowPlayingSessionManagerEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the change notification type of the event.
        /// </summary>
        /// <returns>
        /// A <see cref="NowPlayingSessionManagerNotificationType"/> that represents the
        /// the change notification type of the event.
        /// </returns>
        public NowPlayingSessionManagerNotificationType NotificationType { get; internal set; }

        /// <summary>
        /// Gets the changed session's information.
        /// </summary>
        /// <return>A <see cref="NowPlayingSessionInfo"/> that represents the changed session which gave raise to the event.</return>
        public NowPlayingSessionInfo? NowPlayingSessionInfo { get; internal set; }

        /// <summary>
        /// Gets the type of the session.
        /// </summary>
        public string? SessionTypeString { get; internal set; }
    }
}