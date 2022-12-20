using AnimeDl;
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

namespace Kelompok01.Views
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

        private void GetDynamicWrapPanel()
        {
            Style style = this.FindResource("AnimeButtonStyle") as Style;
            for (int i = 0; i < 6; i++)
            {
            }
        }

        private void OpenAnimeInfoView_Click(object sender, RoutedEventArgs e)
        {
            //HomeFrame.Navigate(new AnimeInfoView(animes[(int)(sender as Button).Tag]));
            NavigationPanel.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(HomeFrame.CanGoBack)
            {
                HomeFrame.GoBack();
                StreamButton.Visibility = Visibility.Visible;
            }
            else
            {
                HomeFrame.Content = null;
                NavigationPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void StreamButton_Click(object sender, RoutedEventArgs e)
        {
            //HomeFrame.Navigate(new AnimeEpisodesView());
            StreamButton.Visibility = Visibility.Collapsed;
        }
    }
}
