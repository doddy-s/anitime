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
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public partial class HistoryView : UserControl
    {
        public HistoryView()
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
            //HistoryFrame.Navigate(new AnimeInfoView(animes[(int)(sender as Button).Tag]));
            NavigationPanel.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (HistoryFrame.CanGoBack)
            {
                HistoryFrame.GoBack();
                StreamButton.Visibility = Visibility.Visible;
            }
            else
            {
                HistoryFrame.Content = null;
                NavigationPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void StreamButton_Click(object sender, RoutedEventArgs e)
        {
            //HistoryFrame.Navigate(new AnimeEpisodesView());
            StreamButton.Visibility = Visibility.Collapsed;
        }
    }
}