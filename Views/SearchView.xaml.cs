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
using System.Collections.ObjectModel;
using JikanDotNet;

namespace Kelompok01.Views
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        ObservableCollection<JikanDotNet.Anime> SearchResult;

        public SearchView(string keyWord)
        {
            InitializeComponent();
            if (keyWord == null) return;
            _ = FillSearchResult(keyWord);
            NumAnimeFound.Content = keyWord;
        }

        private async Task FillSearchResult(string keyWord)
        {
            AnimeSearchConfig animeSearchConfig = new AnimeSearchConfig
            {
                Query = keyWord,
                Rating = AnimeAgeRating.RX
            };
            var _searchResult = await App.JikanClient.SearchAnimeAsync(animeSearchConfig);
            SearchResult = new ObservableCollection<JikanDotNet.Anime>(_searchResult.Data);
            GenerateAnimeTiles();
            NumAnimeFound.Content = SearchResult.Count.ToString() + " Titles Found For \"" + keyWord + "\"";
        }

        private void GenerateAnimeTiles()
        {
            if(SearchResult.Count < 1) { return; }
            Style style = this.FindResource("AnimeButtonStyle") as Style;
            for (int i = 0; i < SearchResult.Count; i++)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(SearchResult[i].Images.JPG.ImageUrl);
                bitmap.EndInit();

                Button button = new Button
                {
                    Width = 200,
                    Height = 300,
                    Margin = new Thickness(0, 0, 20, 20),
                    Tag = i,
                    Content = SearchResult[i].Titles.First().Title,
                    Background = new ImageBrush(bitmap),
                    Style = style
                };

                button.Click += new RoutedEventHandler(OpenAnimeInfoView_Click);
                
                AnimeTilesWrapPanel.Children.Add(button);
            }
        }

        private void OpenAnimeInfoView_Click(object sender, RoutedEventArgs e)
        {
            SearchFrame.Navigate(new AnimeInfoView(SearchResult[(int)(sender as Button).Tag], SearchFrame));
        }
    }
}
