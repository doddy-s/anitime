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
    /// Interaction logic for SettingView.xaml
    /// </summary>
    public partial class SettingView : UserControl
    {
        public SettingView()
        {
            InitializeComponent();
            ShowSettings();
        }

        string[] settings = { "Notifikasi", "Bahasa", "Hapus Riwayat", "Ubah Tema Warna", "Log Out" };

        private void ShowSettings()
        {
            Style style = this.FindResource("WideButtonStyle") as Style;
            for (int i = 0; i < 5; i++)
            {
                Grid grid = new Grid();
                grid.Height = 60;

                Button button = new Button();
                button.HorizontalAlignment = HorizontalAlignment.Stretch;
                button.Tag = i;
                button.Content = settings[i];
                button.Style = style;

                grid.Children.Add(button);
                SettingStackPanel.Children.Add(grid);
            }
        }
    }
}
