namespace Playhead.Interop
{
    internal struct OSVersion
    {
        private readonly ushort major;
        private readonly ushort minor;
        private readonly ushort build;
        private readonly ushort revision;

        public ushort Major => major;
        public ushort Minor => minor;
        public ushort Build => build;
        public ushort Revision => revision;

        public OSVersion(ushort major, ushort minor, ushort build, ushort revision)
        {
            this.major = major;
            this.minor = minor;
            this.build = build;
            this.revision = revision;
        }
    }
}
