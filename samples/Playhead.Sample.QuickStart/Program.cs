using Playhead.Data;
using Playhead.Managers;
using Playhead.Models;
using Playhead.Sessions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Starting Playhead Quick Start Sample...");

        // Initialize the Session Manager (disposed automatically when Main exits)
        using NowPlayingSessionManager manager = new();

        // Setup event handlers to react to changes
        manager.SessionListChanged += (sender, args) =>
        {
            NowPlayingSession session = manager.CurrentSession;

            if (session != null)
            {
                MediaPlaybackDataSource src = session.ActivateMediaPlaybackDataSource();
                src.MediaPlaybackDataChanged += (s, e) =>
                {
                    MediaTimelineProperties timeline = src.GetMediaTimelineProperties();
                    Console.WriteLine($"Position: {timeline.Position} / {timeline.EndTime}");
                };
            }
        };

        // Get the current active session
        NowPlayingSession currentSession = manager.CurrentSession;

        if (currentSession != null)
        {
            // Activate the playback data source to read metadata / control playback
            MediaPlaybackDataSource src = currentSession.ActivateMediaPlaybackDataSource();

            MediaObjectInfo mediaInfo = src.GetMediaObjectInfo();
            Console.WriteLine($"Currently Playing: {mediaInfo.Title} by {mediaInfo.Artist}");

            // Pause the playback (Uncomment to test)
            // src.SendMediaPlaybackCommand(MediaPlaybackCommands.Pause);
        }
        else
        {
            Console.WriteLine("No media is currently playing or no session was found.");
        }

        Console.WriteLine("Listening to events... Press any key to exit.");
        Console.ReadKey();
    }
}