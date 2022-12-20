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
        public AnimeEpisodesView(string animeId)
        {
            InitializeComponent();
            AnimeName.Content = animeId;
            _ = getEpisodes(animeId);
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
                Grid grid = new Grid();
                grid.Height = 60;

                Button button = new Button();
                button.HorizontalAlignment = HorizontalAlignment.Stretch;
                button.Tag = i;
                button.Content = "Episode " + Convert.ToString(i+1);
                button.Style = style;
                button.Click += new RoutedEventHandler(PlayEpisode);

                grid.Children.Add(button);
                EpisodesStackPanel.Children.Add(grid);
            }
        }

        private void PlayEpisode(object sender, RoutedEventArgs e)
        {
            _ = playEpisode(episodes[(int)(sender as Button).Tag]);
        }

        private async Task playEpisode(Episode episode)
        {
            servers = await App.client.GetVideoServersAsync(episode.Id);
            videos = await App.client.GetVideosAsync(servers[4]);
            string vidUrl = "/C mpv " + videos[0].VideoUrl;
            System.Diagnostics.Process.Start("CMD.exe", vidUrl);
        }
    }
}
