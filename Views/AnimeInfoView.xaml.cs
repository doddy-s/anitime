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
    /// Interaction logic for AnimeInfoView.xaml
    /// </summary>
    public partial class AnimeInfoView : Page
    {
        Anime anime;
        public AnimeInfoView(string animeId)
        {
            InitializeComponent();
            this.DataContext = this;
            _ = getInfo(animeId);
        }

        private async Task getInfo(string animeId)
        {
            anime = await App.client.GetAnimeInfoAsync(animeId);
            setInfo();
        }

        public void setInfo()
        {
            AnimeName.Content = anime.Title;
            AnimeDesc.Text = anime.Summary;
            //AnimePic.Background = new ImageBrush(anime.bitmapImage);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(anime.Image);
            bitmap.EndInit();
            AnimePic.Background = new ImageBrush(bitmap);
        }

    }
}
