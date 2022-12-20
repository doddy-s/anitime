using AnimeDl.Models;
using AnimeDl;
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
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        List<Anime> animes;
        Anime currentAnime;

        public SearchView(string keyWord)
        {
            InitializeComponent();
            _ = FillAnimes(keyWord);
            NumAnimeFound.Content = "Search value for " + keyWord;
        }

        private async Task FillAnimes(string keyWord)
        {
            animes = await App.client.SearchAsync(keyWord);
            GetDynamicWrapPanel();
        }

        private void GetDynamicWrapPanel()
        {
            if(animes.Count < 1) { return; }
            Style style = this.FindResource("AnimeButtonStyle") as Style;
            for (int i = 0; i < 6; i++)
            {
                Button button = new Button();
                button.Width = 200;
                button.Height = 300;
                button.Margin = new Thickness(0, 0, 20, 20);
                button.Tag = i;
                button.Content = animes[i].Title;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(animes[i].Image);
                bitmap.EndInit();

                button.Background = new ImageBrush(bitmap);
                button.Click += new RoutedEventHandler(OpenAnimeInfoView_Click);
                button.Style = style;

                AnimeTilesWrapPanel.Children.Add(button);
            }
        }

        private void OpenAnimeInfoView_Click(object sender, RoutedEventArgs e)
        {
            currentAnime = animes[(int)(sender as Button).Tag];
            SearchFrame.Navigate(new AnimeInfoView(currentAnime.Id));
            NavigationPanel.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SearchFrame.Content = null;
            NavigationPanel.Visibility = Visibility.Collapsed;
            StreamButton.Visibility = Visibility.Visible;
        }

        private void StreamButton_Click(object sender, RoutedEventArgs e)
        {
            SearchFrame.Navigate(new AnimeEpisodesView(currentAnime.Id));
            StreamButton.Visibility = Visibility.Collapsed;
        }
    }
}
