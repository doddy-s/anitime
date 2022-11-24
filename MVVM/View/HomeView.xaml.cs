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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    /// 
        

    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            GetDynamicWrapPanel();
        }

        string[] link = { "https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx1535-lawCwhzhi96X.jpg",
                              "https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx107704-3Noksvj7wah5.png",
                              "https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx21519-XIr3PeczUjjF.png",
                              "https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx30-wmNoX3m2qTzz.jpg",
                              "https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx132126-kxCCgt2vrCtC.png",
                              "https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx103047-LYIbLtN2Rb5T.jpg"};

        List<Button> buttons = new List<Button>();
        List<AnimeListTemp> animes = new List<AnimeListTemp>();

        private void GetDynamicWrapPanel()
        {
            Style style = this.FindResource("AnimeButtonStyle") as Style;
            for (int i = 0; i < 6; i++)
            {
                Button button = new Button();
                button.Content = link[i];
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(link[i]);
                bitmap.EndInit();
                button.Background = new ImageBrush(bitmap);
                button.Click += new RoutedEventHandler(OpenAnimeInfoView_Click);
                button.Style = style;
                button.Tag = i;
                buttons.Add(button);
                AnimeTilesWrapPanel.Children.Add(button);
                AnimeListTemp anime = new AnimeListTemp(link[i], link[i], bitmap);
                animes.Add(anime);
            }
        }

        private void OpenAnimeInfoView_Click(object sender, RoutedEventArgs e)
        {
            HomeFrame.Navigate(new AnimeInfoView(animes[(int)(sender as Button).Tag]));
            BackButton.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomeFrame.Content = null;
            BackButton.Visibility = Visibility.Collapsed;
        }
    }
}
