using System;
using System.Runtime.InteropServices;

namespace Playhead
{
    /// <summary>
    /// A structure that represents the timeline state of the session (Position, seek ranges etc.).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MediaTimelineProperties
    {
#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER || NETCOREAPP
        private readonly TimeSpan startTime;
        private readonly TimeSpan endTime;
        private readonly TimeSpan minSeekTime;
        private readonly TimeSpan maxSeekTime;
        private readonly TimeSpan position;
#else
        private readonly long startTime;
        private readonly long endTime;
        private readonly long minSeekTime;
        private readonly long maxSeekTime;
        private readonly long position;
#endif

        //17134+
        private readonly long positionSetFileTime;

        //For future changes etc.. (prevents crash btw)
        private readonly long padding1;

        private readonly long padding2;
        private readonly long padding3;
        private readonly long padding4;

#if NETSTANDARD2_0_OR_GREATER || NET5_0_OR_GREATER || NETCOREAPP
        /// <summary>
        /// Gets the starting timestamp of the current media item.
        /// </summary>
        public TimeSpan StartTime { get => startTime; }

        /// <summary>
        /// Gets the end timestamp of the current media item.
        /// </summary>
        public TimeSpan EndTime { get => endTime; }

        /// <summary>
        /// Gets the earliest timestamp at which the current media item can currently seek to.
        /// </summary>
        public TimeSpan MinSeekTime { get => minSeekTime; }

        /// <summary>
        /// Gets the furthest timestamp at which the current media item can currently seek to.
        /// </summary>
        public TimeSpan MaxSeekTime { get => maxSeekTime; }

        /// <summary>
        /// Gets the playback position, current as of <see cref="PositionSetFileTime"/>.
        /// </summary>
        public TimeSpan Position { get => position; }
#else
        /// <summary>
        /// Gets the starting timestamp of the current media item.
        /// </summary>
        public TimeSpan StartTime => new(startTime);

        /// <summary>
        /// Gets the end timestamp of the current media item.
        /// </summary>
        public TimeSpan EndTime => new(endTime);

        /// <summary>
        /// Gets the earliest timestamp at which the current media item can currently seek to.
        /// </summary>
        public TimeSpan MinSeekTime => new(minSeekTime);

        /// <summary>
        /// Gets the furthest timestamp at which the current media item can currently seek to.
        /// </summary>
        public TimeSpan MaxSeekTime => new(maxSeekTime);

        /// <summary>
        /// Gets the playback position, current as of <see cref="PositionSetFileTime"/>.
        /// </summary>
        public TimeSpan Position => new(position);
#endif

        //17134+
        /// <summary>
        /// Gets the <see cref="DateTime"/> at which the timeline properties were last updated.
        /// </summary>
        public DateTime PositionSetFileTime => DateTime.FromFileTime(positionSetFileTime);
    }
}
