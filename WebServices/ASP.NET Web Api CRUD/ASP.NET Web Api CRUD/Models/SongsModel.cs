using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Client.Models
{
    public class SongsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Artist { get; set; }
        public int AlbumsCount { get; set; }
    }
}