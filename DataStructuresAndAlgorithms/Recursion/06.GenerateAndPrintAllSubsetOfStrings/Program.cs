using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.GenerateAndPrintAllSubsetOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = new string[] { "test", "rock", "fun" };
            string[] taken = new string[strings.Length];
            int k = 2;

            RecursiveLoop(1, 0, strings.Length, k, strings, taken);
        }

        static void RecursiveLoop(int counter, int after, int limit, int k, string[] strings, string[] taken)
        {
            if (counter > k)
            {
                return;
            }

            for (int j = after; j < limit; j++)
            {
                taken[counter - 1] = strings[j];
                if (counter == k)
                {
                    Print(counter, taken);
                }
                RecursiveLoop(counter + 1, j + 1, limit, k, strings, taken);
            }
        }

        static void Print(int length, string[] taken)
        {
            for (int l = 0; l < length; l++)
            {
                Console.Write("{0} ", taken[l]);
            }
            Console.WriteLine();
        }
    }
}
