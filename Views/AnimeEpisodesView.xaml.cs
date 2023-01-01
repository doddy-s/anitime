using AnimeDl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Kelompok01.Views
{
    /// <summary>
    /// Interaction logic for AnimeEpisodesView.xaml
    /// </summary>
    public partial class AnimeEpisodesView : Page
    {
        List<Episode> episodes;
        List<VideoServer> servers;
        List<Video> videos;
        Frame frame;
        string animeId;
        public AnimeEpisodesView(string animeId, Frame frame)
        {
            InitializeComponent();
            AnimeName.Content = animeId;
            _ = getEpisodes(animeId);
            this.frame = frame;
            this.animeId = animeId;
        }

        private async Task getEpisodes(string animeId)
        {
            episodes = await App.client.GetEpisodesAsync(animeId);
            episodes.Reverse();
            ShowEpisodes();
        }

        private void ShowEpisodes()
        {
            Style style = this.FindResource("WideButtonStyle") as Style;
            for (int i = 0; i < episodes.Count; i++)
            {
                Grid grid = new Grid
                {
                    Height = 60,
                    HorizontalAlignment= HorizontalAlignment.Stretch,
                    Margin = new Thickness(0,0,40,0)
                };

                Button button = new Button
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Tag = i,
                    Content = "Episode " + Convert.ToString(i + 1),
                    Style = style
                };
                button.Click += new RoutedEventHandler(PlayEpisode);

                grid.Children.Add(button);
                EpisodesStackPanel.Children.Add(grid);
            }
        }

        private void PlayEpisode(object sender, RoutedEventArgs e)
        {
            SaveHistory();
            _ = playEpisode(episodes[(int)(sender as Button).Tag]);
        }

        private async Task playEpisode(Episode episode)
        {
            servers = await App.client.GetVideoServersAsync(episode.Id);
            videos = await App.client.GetVideosAsync(servers[4]);
            string vidUrl = "/C mpv " + videos[0].VideoUrl;
            System.Diagnostics.Process.Start("CMD.exe", vidUrl);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack) frame.GoBack();
            else frame.Content = null;
        }

        private void SaveHistory()
        {
            if (App.AnimeHistories.Contains(animeId)) App.AnimeHistories.Remove(animeId);
            App.AnimeHistories.Add(animeId);
            File.WriteAllLines("history.txt", App.AnimeHistories.ToArray());
        }
    }
}
