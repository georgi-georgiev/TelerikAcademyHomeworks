using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public partial class Song
    {
        public Song()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public Nullable<int> ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
