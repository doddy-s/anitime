﻿using AnimeDl.Models;
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
    /// Interaction logic for StreamView.xaml
    /// </summary>
    public partial class StreamView : Page
    {
        List<AnimeDl.Models.Anime> animes = new List<AnimeDl.Models.Anime>();
        Frame frame;

        public StreamView(string keyWord, Frame frame)
        {
            InitializeComponent();
            this.frame = frame;

            _ = FillAnimes(keyWord);
            NumAnimeFound.Content = "Animes in streaming entries";
        }

        private async Task FillAnimes(string keyWord)
        {
            animes = await App.client.SearchAsync(keyWord);
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
                button.Content = animes[i].Title;

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
            frame.Navigate(new AnimeEpisodesView(animes[(int)(sender as Button).Tag], frame));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            frame.GoBack();
        }
    }
}
