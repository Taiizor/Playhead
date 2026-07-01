using System;

namespace Playhead.Models
{
    /// <summary>
    /// Represents arguments for a <see cref="MediaPlaybackDataSource.MediaPlaybackDataChanged"/> event.
    /// </summary>
    public class MediaPlaybackDataChangedArgs : EventArgs
    {
        /// <summary>
        /// Gets the <see cref="MediaPlaybackDataSource"/> which raised the event.
        /// </summary>
        /// <returns>
        /// The <see cref="MediaPlaybackDataSource"/> which raised the event.
        /// </returns>
        public MediaPlaybackDataSource? MediaPlaybackDataSource { get; internal set; }

        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        /// <returns>A <see cref="MediaPlaybackDataChangedEvent"/> which represents the type of the event.</returns>
        public MediaPlaybackDataChangedEvent DataChangedEvent { get; internal set; }
    }
}
