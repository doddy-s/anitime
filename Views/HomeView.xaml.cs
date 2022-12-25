using AnimeDl;
using AnimeDl.Models;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    /// 
    public partial class HomeView : UserControl
    {
        ObservableCollection<JikanDotNet.Anime> SeasonalAnimes;
        JikanDotNet.Anime SelectedAnime;

        public HomeView()
        {
            InitializeComponent();
            _ = FillSeasonalAnimes();
        }

        private async Task FillSeasonalAnimes()
        {
            var seasonalAnimes = await App.JikanClient.GetCurrentSeasonAsync();
            SeasonalAnimes = new ObservableCollection<JikanDotNet.Anime>(seasonalAnimes.Data);
            GenerateAnimeTiles();
        }


        private void GenerateAnimeTiles()
        {
            if (SeasonalAnimes.Count < 1) { return; }
            Style style = this.FindResource("AnimeButtonStyle") as Style;
            for (int i = 0; i < SeasonalAnimes.Count; i++)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(SeasonalAnimes[i].Images.JPG.ImageUrl);
                bitmap.EndInit();

                Button button = new Button
                {
                    Width = 200,
                    Height = 300,
                    Margin = new Thickness(0, 0, 20, 20),
                    Tag = i,
                    Content = SeasonalAnimes[i].Titles.First().Title,
                    Background = new ImageBrush(bitmap),
                    Style = style
                };

                button.Click += new RoutedEventHandler(OpenAnimeInfoView_Click);

                AnimeTilesWrapPanel.Children.Add(button);
            }
        }

        private void OpenAnimeInfoView_Click(object sender, RoutedEventArgs e)
        {
            SelectedAnime = SeasonalAnimes[(int)(sender as Button).Tag];
            HomeFrame.Navigate(new AnimeInfoView(SelectedAnime));
            NavigationPanel.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomeFrame.Content = null;
            NavigationPanel.Visibility = Visibility.Collapsed;
            StreamButton.Visibility = Visibility.Visible;
        }

        private void StreamButton_Click(object sender, RoutedEventArgs e)
        {
            HomeFrame.Navigate(new StreamView(SelectedAnime.Titles.First().Title));
            StreamButton.Visibility = Visibility.Collapsed;
        }
    }
}
