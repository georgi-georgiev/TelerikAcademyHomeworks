using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            int stars = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '*')
                {
                    stars++;
                }
            }
            long result = 1;
            for (int i = 0; i < stars; i++)
            {
                result *= 2;
            }
            Console.WriteLine(result);
        }
    }
}
