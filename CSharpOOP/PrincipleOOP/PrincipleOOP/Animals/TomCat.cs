using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class TomCat : Cat
    {
        public TomCat(int age, string name)
            : base(age, name, "male")
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("TomCat");
        }
    }
}
