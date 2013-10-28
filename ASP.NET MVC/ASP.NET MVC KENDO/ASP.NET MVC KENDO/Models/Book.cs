using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ASP.NET_MVC_KENDO.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Author { get; set; }

        [MaxLength(50)]
        public string ISBN { get; set; }

        [Required]
        [MinLength(5)]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [MaxLength(255)]
        public string Website { get; set; }

        [Required]
        public virtual Category Category { get; set; }

    }
}
