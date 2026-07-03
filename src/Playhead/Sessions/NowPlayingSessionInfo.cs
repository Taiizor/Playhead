using System.Runtime.InteropServices;
using static Playhead.Interop.COMInterop;

namespace Playhead.Sessions
{
    /// <summary>
    /// Represents the information associated with a <see cref="NowPlayingSession"/>.
    /// </summary>
    /// <remarks>
    /// This type wraps a native COM reference. Call <see cref="Dispose"/> (or use a
    /// <c>using</c> statement/declaration) once the instance is no longer needed so the
    /// underlying COM reference is released deterministically.
    /// </remarks>
    public class NowPlayingSessionInfo : IEquatable<NowPlayingSessionInfo>, IDisposable
    {
        private readonly INowPlayingSessionInfo_19041 info_19041;
        private readonly INowPlayingSessionInfo_10586 info_10586;
        private readonly int numSelectInterface = 0;

        internal object GetIUnknownInterface { get; }

        internal NowPlayingSessionInfo(object infoIUnknown)
        {
            GetIUnknownInterface = infoIUnknown;

            if (infoIUnknown is INowPlayingSessionInfo_19041 tInfo_19041)
            {
                numSelectInterface = 19041;
                info_19041 = tInfo_19041;
            }
            else if (infoIUnknown is INowPlayingSessionInfo_10586 tInfo_10586)
            {
                numSelectInterface = 10586;
                info_10586 = tInfo_10586;
            }
            else
            {
                throw new NotSupportedException("QueryInterface failed due to non-available interface/guid");
            }
        }

        /// <summary>
        /// Gets the information associated with the session.
        /// </summary>
        /// <param name="hWnd">The window handle associated with the session's source application.</param>
        /// <param name="PID">The process ID of the session's source application.</param>
        /// <param name="DeviceId">The device ID of the session's source application.</param>
        /// <returns>Bool indicating success.</returns>
        public bool GetInfo(out IntPtr hWnd, out uint PID, out string DeviceId)
        {
            if (numSelectInterface == 19041)
            {
                return info_19041.GetInfo(out hWnd, out PID, out DeviceId) == 0;
            }
            else
            {
                return info_10586.GetInfo(out hWnd, out PID, out DeviceId) == 0;
            }
        }

        /// <inheritdoc/>
        public bool Equals(NowPlayingSessionInfo other)
        {
            bool val = false;
            if (numSelectInterface == 19041)
            {
                //Microsoft didn't change the guid once they changed the interface structure...
                //Since we don't know which one is which, we need to gather and test OS build...

                if (NowPlayingSessionManager.OSVersion.Build >= 19582)
                {
                    (info_19041 as INowPlayingSessionInfo_19582).IsEqual(other.GetIUnknownInterface, out val);
                }
                else
                {
                    info_19041.IsEqual(other.GetIUnknownInterface, out val);
                }
            }
            else
            {
                info_10586.IsEqual(other.GetIUnknownInterface, out val);
            }

            return val;
        }

        private bool disposed;

        /// <summary>
        /// Releases the underlying COM reference. The instance should not be used after calling this method.
        /// </summary>
        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            if (GetIUnknownInterface != null && Marshal.IsComObject(GetIUnknownInterface))
            {
                Marshal.ReleaseComObject(GetIUnknownInterface);
            }

            disposed = true;
        }
    }
}