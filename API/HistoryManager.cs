using Kelompok01.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kelompok01.API
{
    public class HistoryManager
    {
        public static void SaveHistory(List<AnimeHistory> list)
        {
            using (StreamWriter file = File.CreateText("History.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, list);
            }
        }

        public static List<AnimeHistory> LoadHistory(string filePath)
        {
            return JsonConvert.DeserializeObject<List<AnimeHistory>>(File.ReadAllText(filePath));
        }
    }
}
