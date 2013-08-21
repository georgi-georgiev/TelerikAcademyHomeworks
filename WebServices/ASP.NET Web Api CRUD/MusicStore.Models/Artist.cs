using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public partial class Artist
    {
        public Artist()
        {
            this.Songs = new HashSet<Song>();
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public System.DateTime DateOfBirth { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
