using Playhead;
using Playhead.Enums;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Playhead.Sample.UWP
{
    public sealed partial class MainPage : Page
    {
        private NowPlayingSessionManager _manager;
        private NowPlayingSession _currentSession;
        public ObservableCollection<SessionViewModel> Sessions { get; set; } = new ObservableCollection<SessionViewModel>();

        public MainPage()
        {
            this.InitializeComponent();
            _manager = new NowPlayingSessionManager();
            SessionsList.ItemsSource = Sessions;
            LoadSessions();
        }

        private void LoadSessions()
        {
            Sessions.Clear();
            var activeSessions = _manager.GetSessions();
            foreach (var session in activeSessions)
            {
                var info = session.GetSessionInfo();
                var mediaInfo = session.GetMediaObjectInfo();
                
                Sessions.Add(new SessionViewModel
                {
                    Session = session,
                    SourceAppId = info?.SourceAppId ?? "Unknown App",
                    Title = mediaInfo?.Title ?? "Unknown Title"
                });
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadSessions();
        }

        private void SessionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SessionsList.SelectedItem is SessionViewModel vm)
            {
                _currentSession = vm.Session;
                var mediaInfo = _currentSession.GetMediaObjectInfo();
                TitleText.Text = mediaInfo?.Title ?? "Unknown Title";
                ArtistText.Text = mediaInfo?.Artist ?? "Unknown Artist";
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            _currentSession?.SendMediaPlaybackCommand(MediaPlaybackCommands.Play);
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            _currentSession?.SendMediaPlaybackCommand(MediaPlaybackCommands.Pause);
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            _currentSession?.SendMediaPlaybackCommand(MediaPlaybackCommands.Previous);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            _currentSession?.SendMediaPlaybackCommand(MediaPlaybackCommands.Next);
        }
    }

    public class SessionViewModel
    {
        public NowPlayingSession Session { get; set; }
        public string SourceAppId { get; set; }
        public string Title { get; set; }
    }
}