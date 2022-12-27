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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        UserProfile userProfile = new UserProfile();
        Frame frame;
        public LoginView(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            this.frame.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = null;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            GetProfile(UsernameBox.Text).Wait();
            frame.Navigate(new UserProfileView(userProfile, frame));
        }

        private async Task GetProfile(string username)
        {
            var _userProfile = await App.JikanClient.GetUserProfileAsync(username);
            userProfile = _userProfile.Data;
        }
    }
}
