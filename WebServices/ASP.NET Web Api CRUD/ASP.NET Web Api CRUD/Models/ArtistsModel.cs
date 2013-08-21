using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Client.Models
{
    public class ArtistsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int SongsCount { get; set; }
        public int AlbumsCount { get; set; }
    }
}