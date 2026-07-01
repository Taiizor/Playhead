namespace Playhead.Interop
{
    internal struct OSVersion(ushort major, ushort minor, ushort build, ushort revision)
    {
        public readonly ushort Major => major;
        public readonly ushort Minor => minor;
        public readonly ushort Build => build;
        public readonly ushort Revision => revision;
    }
}