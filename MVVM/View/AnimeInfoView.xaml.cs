using Kelompok01.MVVM.Model;
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
    /// Interaction logic for AnimeInfoView.xaml
    /// </summary>
    public partial class AnimeInfoView : Page
    {
        AnimeListTemp anime;
        public AnimeInfoView(AnimeListTemp anime)
        {
            InitializeComponent();
            this.DataContext = this;
            this.anime = anime;
            setInfo();
        }

        public void setInfo()
        {
            AnimeName.Content = anime.name;
            AnimeDesc.Text = anime.description;
            AnimeImage.ImageSource = anime.bitmapImage;
        }

    }
}
