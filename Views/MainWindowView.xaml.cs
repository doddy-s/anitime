﻿using System;
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
using System.Windows.Shapes;

namespace Kelompok01.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        List<UserControl> userControls = new List<UserControl>();

        public MainWindowView()
        {
            InitializeComponent();
            SetProfilePhoto();
            userControls.AddRange(new List<UserControl>
            {
                new HomeView(),
                new SearchView(null),
                new HistoryView(),
                new SettingView()
            });

            MainContent.Content = userControls[0];
        }

        private void SetProfilePhoto()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            if (App.UserProfile == null) 
            {
                bitmap.UriSource = new Uri("https://cdn.discordapp.com/attachments/1006411248411361370/1061487340633206784/UserName1.png");
            }
            else
            {
                bitmap.UriSource = new Uri(App.UserProfile.Images.JPG.ImageUrl);
            }
            bitmap.EndInit();
            ProfileButton.Background = new ImageBrush(bitmap);

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.UserProfile == null) UserProfileFrame.Navigate(new LoginView(UserProfileFrame));
            else UserProfileFrame.Navigate(new UserProfileView(App.UserProfile, UserProfileFrame));
        }

        private void NavigateMainContent(object sender, RoutedEventArgs e)
        {
            var tag = Convert.ToInt32((sender as RadioButton).Tag);
            if (tag == 2) userControls[2] = new HistoryView();
            MainContent.Content = userControls[tag];
        }

        private void EnterSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string query = (sender as TextBox).Text;
                OpenSearch(query);
            }
        }

        private void OpenSearch(string keyWord)
        {
            userControls[1] = new SearchView(keyWord);
            Search.IsChecked = true;
            MainContent.Content = userControls[1];
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            OpenSearch(SearchBox.Text);
        }
    }
}
