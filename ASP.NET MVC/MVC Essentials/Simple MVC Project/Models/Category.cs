using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_MVC_Project.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new HashSet<Product>();
        }
    }
}
