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
    /// Interaction logic for NewAnimeView.xaml
    /// </summary>
    public partial class NewAnimeView : UserControl
    {
        public NewAnimeView()
        {
            InitializeComponent();
            GetDynamicWrapPanel();
        }

        private void GetDynamicWrapPanel()
        {
            String[] link = { "https://cdn.myanimelist.net/images/anime/1806/126216.jpg",
                              "https://cdn.myanimelist.net/images/anime/1111/127508.jpg",
                              "https://cdn.myanimelist.net/images/anime/1228/125011.jpg",
                              "https://cdn.myanimelist.net/images/anime/1483/126005.jpg",
                              "https://cdn.myanimelist.net/images/anime/1764/126627.jpg",
                              "https://cdn.myanimelist.net/images/anime/1258/126929.jpg"};

            Style style = this.FindResource("AnimeButtonStyle") as Style;

            for (int i = 0; i < 6; i++)
            {
                Button button = new Button();
                button.Content = link[i];
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(link[i], UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                button.Background = new ImageBrush(bitmap);
                button.Command = HomeViewModel.AnimeInfoViewCommand;
                button.Style = style;
                HomePanel.Children.Add(button);
            }
        }
    }
}
