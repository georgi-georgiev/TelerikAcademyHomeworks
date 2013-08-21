using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GenerateAndPrintElementSubsets
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 2;
            string[] set = new string[] { "hi", "a", "b" };
            int[] variationIndexes = new int[set.Length];

            Variate(0, k, set.Length, set, variationIndexes);
        }

        static void Variate(int counter, int n, int length, string[] set, int[] variationIndexes)
        {
            if (counter >= n)
            {
                Print(n, set, variationIndexes);
                return;
            }

            for (int j = 0; j < length; j++)
            {
                variationIndexes[counter] = j;
                Variate(counter + 1, n, length, set, variationIndexes);
            }

        }

        static void Print(int length, string[] set, int[] varIndexes)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} ", set[varIndexes[i]]);
            }
            Console.WriteLine();
        }
    }
}
