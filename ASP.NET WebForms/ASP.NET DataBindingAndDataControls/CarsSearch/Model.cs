using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsSearch
{
    public class Model
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Extra> Extras { get; set; }
    }
}
