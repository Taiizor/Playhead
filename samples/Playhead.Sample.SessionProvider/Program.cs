using System;
using System.Linq;
using Playhead;
using Playhead.Managers;
using Playhead.Sessions;
using Playhead.Data;
using Playhead.Models;
using Playhead.Enums;

namespace Playhead.Sample.SessionProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" Playhead AddSession (SessionProvider) Sample App ");
            Console.WriteLine("==================================================");
            
            NowPlayingSessionManager manager = new NowPlayingSessionManager();
            var sessions = manager.GetSessions();

            if (sessions.Length == 0)
            {
                Console.WriteLine("\n[Error] No active sessions found. Please play some media in Spotify, Edge, etc. so we can clone its data source for the demonstration.");
                Console.ReadLine();
                return;
            }

            // For demonstration, we pick the first active session to "borrow" its COM MediaPlaybackDataSource
            var sourceSession = sessions.First();
            var dataSource = sourceSession.ActivateMediaPlaybackDataSource();

            Console.WriteLine($"\n[Info] Borrowing MediaPlaybackDataSource from: {sourceSession.SourceAppId}");
            
            // Generate some fake app data
            string fakeAppId = "Playhead.FakeApp.exe";
            uint fakePid = (uint)System.Diagnostics.Process.GetCurrentProcess().Id;
            IntPtr fakeHwnd = IntPtr.Zero; // No window

            Console.WriteLine($"\n[Action] Injecting a new cloned session into Windows SMTC as '{fakeAppId}'...");

            try
            {
                bool result = manager.AddSession(
                    type: NowPlayingSessionType.Local,
                    hwnd: fakeHwnd,
                    pid: fakePid,
                    appId: fakeAppId,
                    sourceDeviceId: "",
                    renderDeviceId: "",
                    source: "Cloned Source",
                    mediaControl: dataSource,
                    connection: null,
                    markAsCurrentSession: true,
                    processHandle: IntPtr.Zero
                );

                if (result)
                {
                    Console.WriteLine("\n[Success] The cloned session was successfully injected!");
                    Console.WriteLine("Check your Windows volume flyout or the 'Playhead.Sample.CLI' app to see the new fake session.");
                }
                else
                {
                    Console.WriteLine("\n[Warning] AddSession returned false. The session might not have been added.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Error] Failed to inject session: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
