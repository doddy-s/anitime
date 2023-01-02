using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok01.Models
{
    public class AnimeHistory
    {
        public string AnimeId { get; set; }
        public int Episode { get; set; }

        public AnimeHistory(string animeId, int episode)
        {
            AnimeId = animeId;
            Episode = episode;
        }
    }
}
