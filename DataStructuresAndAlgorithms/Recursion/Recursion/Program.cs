using System;
using System.Linq;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] taken = new int[n];

            RecursiveLoop(0, n, taken);
        }

        static void RecursiveLoop(int counter, int limit, int[] taken)
        {
            if (counter >= limit)
            {
                Print(counter, taken);
                return;
            }

            for (int i = 0; i < limit; i++)
            {
                taken[counter] = i+1;
                RecursiveLoop(counter + 1, limit, taken);
            }
        }

        static void Print(int counter, int[] taken)
        {
            for (int i = 0; i < counter; i++)
            {
                Console.Write("{0} ", taken[i]);
            }
            Console.WriteLine();
        }
    }
}
