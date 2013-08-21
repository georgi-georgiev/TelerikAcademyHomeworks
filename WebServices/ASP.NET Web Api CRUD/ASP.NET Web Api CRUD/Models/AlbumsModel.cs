using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Web_Api_CRUD.Models
{
    public class AlbumsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Producer { get; set; }
        public int SongsCount { get; set; }
        public int ArtistsCount { get; set; }
    }
}