using AnimeDl.Models;
using JikanDotNet;
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
    /// Interaction logic for VideosPage.xaml
    /// </summary>
    public partial class VideosPage : Page
    {
        string animeId;
        List<Video> videos;
        public VideosPage(VideoServer videoServer, string animeId)
        {
            InitializeComponent();
            this.animeId = animeId;
            ServerName.Content = videoServer.Name;
            _ = GetVideos(videoServer);
        }

        private async Task GetVideos(VideoServer videoServer)
        {
            videos = await App.client.GetVideosAsync(videoServer);
            ShowVideos();
        }

        private void ShowVideos()
        {
            Style style = this.FindResource("WideButtonStyle") as Style;
            for (int i = 0; i < videos.Count; i++)
            {
                Grid grid = new Grid
                {
                    Height = 60,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(0, 0, 40, 0)
                };

                Button button = new Button
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Tag = i,
                    Content = videos[i].Resolution,
                    Style = style
                };
                button.Click += new RoutedEventHandler(OpenVideos);

                grid.Children.Add(button);
                VideosStackPanel.Children.Add(grid);
            }
        }

        private void OpenVideos(object sender, RoutedEventArgs e)
        {
            App.AnimeHistories.RemoveAll(p => p.AnimeId == animeId);
            App.AnimeHistories.Add(new Models.AnimeHistory(animeId, (int)(sender as Button).Tag + 1));
            string vidUrl = "/C mpv " + videos[(int)(sender as Button).Tag].VideoUrl;
            System.Diagnostics.Process.Start("CMD.exe", vidUrl);
        }

    }
}
