using System;

namespace Playhead.Interop
{
    internal struct OSVersion
    {
        private readonly ushort major;
        private readonly ushort minor;
        private readonly ushort build;
        private readonly ushort revision;

        public ushort Major { get => major; }
        public ushort Minor { get => minor; }
        public ushort Build { get => build; }
        public ushort Revision { get => revision; }

        public OSVersion(ushort major, ushort minor, ushort build, ushort revision)
        {
            this.major = major;
            this.minor = minor;
            this.build = build;
            this.revision = revision;
        }
    }
}
