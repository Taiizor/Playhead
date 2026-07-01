namespace Playhead.Interop
{
    internal class Helpers
    {
        internal static OSVersion GetOSVersion()
        {
            NativeMethods.RtlGetDeviceFamilyInfoEnum(out ulong version, out uint b, out uint c);

            return new OSVersion(
                major: (ushort)((version & 0xFFFF000000000000L) >> 48),
                minor: (ushort)((version & 0x0000FFFF00000000L) >> 32),
                build: (ushort)((version & 0x00000000FFFF0000L) >> 16),
                revision: (ushort)(version & 0x000000000000FFFFL)
            );
        }
    }
}
