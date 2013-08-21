using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FindInFile
{
    class Command
    {
        public Command(string name, string town=null)
        {
            this.Name = name;
            this.Town = town;
        }

        public string Name { get; set; }
        public string Town { get; set; }
    }
}
