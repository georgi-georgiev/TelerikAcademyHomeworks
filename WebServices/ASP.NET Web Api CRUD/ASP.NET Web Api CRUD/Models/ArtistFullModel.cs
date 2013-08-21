using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET_Web_Api_CRUD.Models;

namespace MusicStore.Client.Models
{
    public class ArtistFullModel : ArtistsModel
    {
        public IEnumerable<SongsModel> Songs { get; set; }
        public IEnumerable<AlbumsModel> Albums { get; set; }
    }
}