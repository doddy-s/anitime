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
using Kelompok01.Models;
using Kelompok01.API;

namespace Kelompok01
{
    public partial class App : Application
    {
        public static Jikan JikanClient = new Jikan();
        public static AnimeClient client = new AnimeClient(AnimeDl.Scrapers.AnimeSites.GogoAnime);
        public static List<AnimeHistory> AnimeHistories = new List<AnimeHistory>();
        public static HistoryManager HistoryManagerClient = new HistoryManager();

        public App()
        {
            AnimeHistories = HistoryManager.LoadHistory("History.json");
        }

        ~App()
        {
            HistoryManager.SaveHistory(AnimeHistories);
        }

    }
}
