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
    /// Interaction logic for AnimeTiles.xaml
    /// </summary>
    public partial class AnimeTiles : Page
    {
        String[] link;
        List<Button> buttons = new List<Button>();
        public AnimeTiles(String[] PhotoUrl, String header)
        {
            InitializeComponent();
            link = PhotoUrl;
            AnimeTilesHeader.Content = header;
            GetDynamicWrapPanel();
        }

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
                button.Click += new RoutedEventHandler(OpenAnimePage_Click);
                button.Style = style;
                buttons.Add(button);
                AnimeTilesWrapPanel.Children.Add(button);
            }
        }

        private void OpenAnimePage_Click(object sender, EventArgs e)
        {
            AnimeInfoView animeInfoView = new AnimeInfoView();
            App.HomeFrameGlobal.Navigate(animeInfoView);
        }
    }
}
