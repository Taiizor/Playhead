namespace Playhead
{
    /// <summary>
    /// A structure that holds information about the content that the current session has.
    /// </summary>
    public struct MediaObjectInfo
    {
        private readonly string? albumArtist;
        private readonly string? albumTitle;
        private readonly string? subtitle;
        private readonly string? title;
        private readonly string? artist;
        private readonly string? mediaClassPrimaryID;
        private readonly string[]? genres;
        private readonly uint albumTrackCount;
        private readonly uint trackNumber;

        /// <summary>
        /// Gets the album's artist.
        /// </summary>
        public string? AlbumArtist => albumArtist;

        /// <summary>
        /// Gets the title of the album.
        /// </summary>
        public string? AlbumTitle => albumTitle;

        /// <summary>
        /// Gets the subtitle.
        /// </summary>
        public string? Subtitle => subtitle;

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string? Title => title;

        /// <summary>
        /// Gets the artist's name.
        /// </summary>
        public string? Artist => artist;

        /// <summary>
        /// Gets the primary class ID or schema of the media.
        /// </summary>
        public string? MediaClassPrimaryID => mediaClassPrimaryID;

        /// <summary>
        /// Gets the list of genres.
        /// </summary>
        public string[]? Genres => genres;

        /// <summary>
        /// Gets the total number of tracks on the album.
        /// </summary>
        public uint AlbumTrackCount => albumTrackCount;

        /// <summary>
        /// Gets the track's number.
        /// </summary>
        public uint TrackNumber => trackNumber;

        internal MediaObjectInfo(string? albumArtist,
            string? albumTitle,
            string? subtitle,
            string? title,
            string? artist,
            string? mediaClassPrimaryID,
            string[]? genres,
            uint albumTrackCount,
            uint trackNumber)
        {
            this.albumArtist = albumArtist;
            this.albumTitle = albumTitle;
            this.subtitle = subtitle;
            this.title = title;
            this.artist = artist;
            this.mediaClassPrimaryID = mediaClassPrimaryID;
            this.genres = genres;
            this.albumTrackCount = albumTrackCount;
            this.trackNumber = trackNumber;
        }
    }
}
