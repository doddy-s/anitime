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
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public partial class HistoryView : UserControl
    {
        public HistoryView()
        {
            InitializeComponent();
            GetDynamicWrapPanel();
        }

        string[] link = { "https://cdn.myanimelist.net/images/anime/1806/126216.jpg",
                          "https://cdn.myanimelist.net/images/anime/1764/126627.jpg",
                          "https://cdn.myanimelist.net/images/anime/1111/127508.jpg",
                          "https://cdn.myanimelist.net/images/anime/1483/126005.jpg",
                          "https://cdn.myanimelist.net/images/anime/1228/125011.jpg",
                          "https://cdn.myanimelist.net/images/anime/1476/125643.jpg"};
        string[] animeName = { "Chainsaw Man", "Bleach: Sennen Kessen-hen", "Spy x Family Part 2",
                               "Boku no Hero Academia 6th Season", "Mob Psycho 100 III", "Shinobi no Ittoki" };
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
            HistoryFrame.Navigate(new AnimeInfoView(animes[(int)(sender as Button).Tag]));
            NavigationPanel.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HistoryFrame.Content = null;
            NavigationPanel.Visibility = Visibility.Collapsed;
        }
    }
}