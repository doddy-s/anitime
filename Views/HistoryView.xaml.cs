using AnimeDl.Models;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;

namespace Kelompok01.Views
{
    /// <summary>
    /// Interaction logic for HistoryView.xaml
    /// </summary>
    public partial class HistoryView : UserControl
    {
        List<AnimeDl.Models.Anime> animes = new List<AnimeDl.Models.Anime>();

        public HistoryView()
        {
            InitializeComponent();
            _ = FillAnimes();
        }

        private async Task FillAnimes()
        {
            if(App.AnimeHistories.Count == 0) { HistoryLabel.Text = "You never watch anything here."; return; }
            foreach (var i in App.AnimeHistories)
            {
                var temp = await App.client.GetAnimeInfoAsync(i.AnimeId);
                animes.Add(temp);
            }
            GenerateAnimeTiles();
        }

        private void GenerateAnimeTiles()
        {
            if (animes.Count < 1) { return; }
            Style style = this.FindResource("AnimeButtonStyle") as Style;
            for (int i = 0; i < animes.Count; i++)
            {
                Button button = new Button();
                button.Width = 200;
                button.Height = 300;
                button.Margin = new Thickness(0, 0, 20, 20);
                button.Tag = i;
                button.Content = animes[i].Title + "\nLast Wached Episode : " + App.AnimeHistories[i].Episode;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(animes[i].Image);
                bitmap.EndInit();

                button.Background = new ImageBrush(bitmap);
                button.Click += new RoutedEventHandler(OpenAnimeEpisodesView_Click);
                button.Style = style;

                AnimeTilesWrapPanel.Children.Add(button);
            }
        }

        private void OpenAnimeEpisodesView_Click(object sender, RoutedEventArgs e)
        {
            while (HistoryFrame.CanGoBack) HistoryFrame.RemoveBackEntry();
            HistoryFrame.Navigate(new AnimeEpisodesView(animes[(int)(sender as Button).Tag], HistoryFrame));
        }
    }
}
