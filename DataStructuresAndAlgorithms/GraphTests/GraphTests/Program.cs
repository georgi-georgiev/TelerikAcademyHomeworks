using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> asd = new Dictionary<int, List<int>>();
            List<int> ha = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                ha.Add(i);
            }
            asd.Add(0,ha);

            foreach (var a in asd)
            {
                foreach (var h in a.Value)
                {
                    Console.WriteLine(h);
                }
            }

        }
    }
}
