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
    /// Interaction logic for ServersPage.xaml
    /// </summary>
    public partial class ServersPage : Page
    {
        string animeId;
        int episodeNum;
        List<VideoServer> servers;
        public ServersPage(Episode episode, string animeId, int episodeNum)
        {
            InitializeComponent();
            this.animeId = animeId;
            this.episodeNum = episodeNum;
            EpisodeNumber.Content = episode.Name;
            _ = GetServers(episode.Id);
        }

        private async Task GetServers(string episodeId)
        {
            servers = await App.client.GetVideoServersAsync(episodeId);
            ShowServers();
        }

        private void ShowServers()
        {
            Style style = this.FindResource("WideButtonStyle") as Style;
            for (int i = 0; i < servers.Count; i++)
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
                    Content = servers[i].Name,
                    Style = style
                };
                button.Click += new RoutedEventHandler(OpenVideos);

                grid.Children.Add(button);
                ServersStackPanel.Children.Add(grid);
            }
        }

        private void OpenVideos(object sender, RoutedEventArgs e)
        {
            VideosFrame.Navigate(new VideosPage(servers[(int)(sender as Button).Tag], animeId, episodeNum));
        }

    }
}
