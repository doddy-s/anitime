using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Kelompok01.MVVM.Model
{
    public class AnimeListTemp
    {
        public string name;
        public string description;
        public BitmapImage bitmapImage;
        public AnimeListTemp(string name, string description, BitmapImage bitmapImage)
        {
            this.name = name;
            this.description = description;
            this.bitmapImage = bitmapImage;
        }
    }
}
