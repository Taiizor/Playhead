using Playhead.Data;
using Playhead.Enums;
using Playhead.Managers;
using Playhead.Sessions;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Playhead.Sample.SessionProvider
{
    [ComVisible(true)]
    [Guid("99dbe0af-ed3c-431a-bd28-98aa0740e7d2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFakeDataSource_10586
    {
        [PreserveSig] int GetMediaPlaybackInfo(IntPtr pPlaybackInfo);
        [PreserveSig] int SendMediaPlaybackCommand(int command);
        [PreserveSig] int GetMediaObjectInfo(out IntPtr ppMediaObjectInfo);
        [PreserveSig] int GetMediaTimelineProperties(IntPtr pTimelineProperties);
        [PreserveSig] int RegisterEventHandler(IntPtr handler, out long token);
        [PreserveSig] int UnregisterEventHandler(long token);
    }

    [ComVisible(true)]
    [Guid("23c14a92-2ba3-4a1e-84b2-034bb628c62c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFakeDataSource_19041 : IFakeDataSource_10586
    {
        [PreserveSig] int SendRepeatModeChangeRequest(int requestedRepeatMode);
        [PreserveSig] int SendPlaybackRateChangeRequest(double requestedPlaybackRate);
        [PreserveSig] int SendShuffleEnabledChangeRequest(bool requestedShuffleEnabled);
        [PreserveSig] int SendPlaybackPositionChangeRequest(long requestedPlaybackPosition);
        [PreserveSig] int GetMediaObjectInfoAsSet(Guid guid, out IntPtr ppUnknown);
    }

    [ComVisible(true)]
    public class FakeDataSource : IFakeDataSource_19041, IFakeDataSource_10586
    {
        public int GetMediaPlaybackInfo(IntPtr p) => unchecked((int)0x80004001);
        public int SendMediaPlaybackCommand(int c) => unchecked((int)0x80004001);
        public int GetMediaObjectInfo(out IntPtr p) { p = IntPtr.Zero; return unchecked((int)0x80004001); }
        public int GetMediaTimelineProperties(IntPtr p) => unchecked((int)0x80004001);
        public int RegisterEventHandler(IntPtr h, out long t) { t = 0; return unchecked((int)0x80004001); }
        public int UnregisterEventHandler(long t) => unchecked((int)0x80004001);
        public int SendRepeatModeChangeRequest(int r) => unchecked((int)0x80004001);
        public int SendPlaybackRateChangeRequest(double r) => unchecked((int)0x80004001);
        public int SendShuffleEnabledChangeRequest(bool s) => unchecked((int)0x80004001);
        public int SendPlaybackPositionChangeRequest(long p) => unchecked((int)0x80004001);
        public int GetMediaObjectInfoAsSet(Guid g, out IntPtr p) { p = IntPtr.Zero; return unchecked((int)0x80004001); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" Playhead AddSession (SessionProvider) Sample App ");
            Console.WriteLine("==================================================");
            
            NowPlayingSessionManager manager = new NowPlayingSessionManager();

            string fakeAppId = "Playhead.FakeApp.exe";
            uint fakePid = (uint)System.Diagnostics.Process.GetCurrentProcess().Id;
            IntPtr fakeHwnd = IntPtr.Zero;

            Console.WriteLine($"\n[Info] Preparing to inject session for '{fakeAppId}'...");
            Console.WriteLine("\n[Architectural Note]:");
            Console.WriteLine("The 'AddSession' method calls an undocumented, private Windows API (NPSM).");
            Console.WriteLine("Because it expects a fully implemented, perfectly mapped C++ COM object");
            Console.WriteLine("(IMediaPlaybackDataSource, IPropertyStore, etc.), passing anything else");
            Console.WriteLine("(including cloned sessions or fake C# CCW wrappers) will cause the internal");
            Console.WriteLine("Windows service to crash with an Access Violation (0xC0000005).");
            Console.WriteLine("\nTo prevent this sample from crashing your console, the actual API call is");
            Console.WriteLine("currently bypassed. This project remains as a Proof of Concept (PoC)");
            Console.WriteLine("for developers who wish to fully reverse-engineer the required COM interfaces.");

            /*
            // ⚠️ WARNING: Uncommenting this block will crash the application with 0xC0000005.
            try
            {
                FakeDataSource _keepAlive = new FakeDataSource();
                IntPtr pUnknown = Marshal.GetIUnknownForObject(_keepAlive);
                object rcw = Marshal.GetObjectForIUnknown(pUnknown);
                var myFakeControl = new MediaPlaybackDataSource(rcw);

                bool result = manager.AddSession(
                    type: NowPlayingSessionType.Local,
                    hwnd: fakeHwnd,
                    pid: fakePid,
                    appId: fakeAppId,
                    sourceDeviceId: "",
                    renderDeviceId: "",
                    source: "My C# Fake Source",
                    mediaControl: myFakeControl,
                    connection: null,
                    markAsCurrentSession: true,
                    processHandle: IntPtr.Zero
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            */

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}