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
        Frame frame;
        AnimeDl.Models.Anime anime;
        public AnimeEpisodesView(AnimeDl.Models.Anime anime, Frame frame)
        {
            InitializeComponent();
            _ = getEpisodes(anime.Id);
            this.frame = frame;
            this.anime = anime;
            AnimeName.Content = anime.Title;
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
                button.Click += new RoutedEventHandler(OpenServers);

                grid.Children.Add(button);
                EpisodesStackPanel.Children.Add(grid);
            }
        }

        private void OpenServers(object sender, RoutedEventArgs e)
        {
            ServerFrame.Navigate(new ServersPage(episodes[(int)(sender as Button).Tag], anime.Id, (int)(sender as Button).Tag + 1));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack) frame.GoBack();
            else frame.Content = null;
        }
    }
}
