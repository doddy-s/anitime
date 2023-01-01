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
    /// Interaction logic for UserProfileView.xaml
    /// </summary>
    public partial class UserProfileView : Page
    {
        UserProfile userProfile;
        Frame frame;
        public UserProfileView(UserProfile userProfile ,Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
            this.userProfile = userProfile;
            SetComponents();
        }

        private void SetComponents()
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(userProfile.Images.JPG.ImageUrl);
            bitmap.EndInit();
            UserImage.Source = bitmap;

            UserName.Content = userProfile.Username;
            Joined.Content = userProfile.Joined;
            LastOnline.Content = userProfile.LastOnline;

            /*
            if(animeStatistics == null) { return; }
            Watching.Content = animeStatistics.Watching;
            Completed.Content = animeStatistics.Completed;
            Onhold.Content = animeStatistics.OnHold;
            Dropped.Content = animeStatistics.Dropped;
            Plantowatch.Content = animeStatistics.PlanToWatch;
            */
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = null;
        }
    }
}
