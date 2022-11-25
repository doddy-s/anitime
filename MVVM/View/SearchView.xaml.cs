using Kelompok01.MVVM.Model;
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

namespace Kelompok01.MVVM.View
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        public SearchView()
        {
            InitializeComponent();
            GetDynamicWrapPanel();
        }

        string[] link = { "https://cdn.myanimelist.net/images/anime/1295/106551.jpg",
                          "https://cdn.myanimelist.net/images/anime/1764/106659.jpg",
                          "https://cdn.myanimelist.net/images/anime/1935/93606.jpg",
                          "https://cdn.myanimelist.net/images/anime/1027/115055.jpg",
                          "https://cdn.myanimelist.net/images/anime/1160/122627.jpg",
                          "https://cdn.myanimelist.net/images/anime/1670/130060.jpg"};

        string[] animeName = { "Kaguya-sama wa Kokurasetai: Tensai-tachi no Renai Zunousen",
                               "Kaguya-sama wa Kokurasetai? Tensai-tachi no Renai Zunousen",
                               "Kaguya-hime no Monogatari",
                               "Kaguya-sama wa Kokurasetai? Tensai-tachi no Renai Zunousen OVA",
                               "Kaguya-sama wa Kokurasetai: Ultra Romantic",
                               "Kaguya-sama wa Kokurasetai: First Kiss wa Owaranai" };

        List<AnimeListTemp> animes = new List<AnimeListTemp>();

        private void GetDynamicWrapPanel()
        {
            Style style = this.FindResource("AnimeButtonStyle") as Style;
            for (int i = 0; i < 6; i++)
            {
                Button button = new Button();
                button.Width = 200;
                button.Height = 300;
                button.Margin = new Thickness(0, 0, 20, 20);
                button.Tag = i;
                button.Content = animeName[i];

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(link[i]);
                bitmap.EndInit();

                button.Background = new ImageBrush(bitmap);
                button.Click += new RoutedEventHandler(OpenAnimeInfoView_Click);
                button.Style = style;

                AnimeTilesWrapPanel.Children.Add(button);

                AnimeListTemp anime = new AnimeListTemp(animeName[i], link[i], bitmap);
                animes.Add(anime);
            }
        }

        private void OpenAnimeInfoView_Click(object sender, RoutedEventArgs e)
        {
            SearchFrame.Navigate(new AnimeInfoView(animes[(int)(sender as Button).Tag]));
            NavigationPanel.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SearchFrame.Content = null;
            NavigationPanel.Visibility = Visibility.Collapsed;
        }
    }
}
