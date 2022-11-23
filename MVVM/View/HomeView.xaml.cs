using Kelompok01.MVVM.ViewModel;
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
    public partial class HomeView : UserControl
    {
        String[] link = { "https://cdn.myanimelist.net/images/anime/1806/126216.jpg",
                              "https://cdn.myanimelist.net/images/anime/1111/127508.jpg",
                              "https://cdn.myanimelist.net/images/anime/1228/125011.jpg",
                              "https://cdn.myanimelist.net/images/anime/1483/126005.jpg",
                              "https://cdn.myanimelist.net/images/anime/1764/126627.jpg",
                              "https://cdn.myanimelist.net/images/anime/1258/126929.jpg"};

        public static AnimeTiles NewAnime;

        public HomeView()
        {
            InitializeComponent();
            App.HomeFrameGlobal = HomeFrame;
            NewAnime = new AnimeTiles(link, "New Anime");
            HomeFrame.Navigate(NewAnime);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomeFrame.GoBack();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(HomeFrame.CanGoBack) BackButton.Visibility = Visibility.Visible;
            else BackButton.Visibility = Visibility.Hidden;
        }
    }
}
