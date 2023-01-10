using AnimeDl.Models;
using JikanDotNet;
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
        JikanDotNet.Anime anime;
        Frame frame;
        public AnimeInfoView(JikanDotNet.Anime anime, Frame frame)
        {
            InitializeComponent();
            this.DataContext = this;
            this.anime = anime;
            this.frame = frame;
            setInfo();
        }

        public void setInfo()
        {
            AnimeName.Content = anime.Titles.First().Title;
            AnimeDesc.Text = anime.Synopsis;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(anime.Images.JPG.ImageUrl);
            bitmap.EndInit();
            AnimePic.Background = new ImageBrush(bitmap);

            ScoreValue.Content = anime.Score;
            RankingValue.Content = anime.Popularity;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = null;
            while(frame.CanGoBack) { frame.RemoveBackEntry(); }
        }

        private void StreamButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new StreamView(anime.Titles.First().Title, frame);
        }
    }
}
