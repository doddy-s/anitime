using AnimeDl;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Kelompok01
{
    public partial class App : Application
    {
        public static Jikan JikanClient = new Jikan();
        public static AnimeClient client = new AnimeClient(AnimeDl.Scrapers.AnimeSites.GogoAnime);
        public static Frame UserProfileFrame;
    }
}
