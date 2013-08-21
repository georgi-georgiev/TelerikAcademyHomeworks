using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FindInFile
{
    public class Entry
    {
        public Entry(string name, string town, string phone)
        {
            this.Name = name;
            this.Town = town;
            this.Phone = phone;
        }

        public string Name { get; set; }
        public string Town { get; set; }
        public string Phone { get; set; }

        
        public override string ToString()
        {
            return this.Name + " " + this.Town+" "+this.Phone;
        }
    }
}
