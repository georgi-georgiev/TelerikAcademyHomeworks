using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ASP.NET_MVC_KENDO.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Category()
        {
            this.Books = new HashSet<Book>();
        }
    }
}
