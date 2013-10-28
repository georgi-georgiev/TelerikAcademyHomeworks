using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_MVC_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
    }
}
