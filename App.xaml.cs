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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kelompok01
{
    // Application
    public partial class App : Application
    {
        public static Jikan JikanClient = new Jikan();
        public static AnimeClient client = new AnimeClient(AnimeDl.Scrapers.AnimeSites.GogoAnime);
        public static JsonManager JsonClient = new JsonManager();
        public static List<AnimeHistory> AnimeHistories = new List<AnimeHistory>();
        public static UserProfile UserProfile;

        public App()
        {
            AnimeHistories = JsonClient.LoadList<AnimeHistory>("History.json");
            UserProfile = JsonClient.Load<UserProfile>("UserProfile.json");
        }

        ~App()
        {
            JsonClient.SaveList(AnimeHistories, "History.Json");
            App.JsonClient.Save(UserProfile, "UserProfile.json");
        }

        public static void Restart()
        {
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0]);
        }
    }
}
