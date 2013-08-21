using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Permutations
{
    class Program
    {
        static void RecursiveLoop(int counter, int n, int[] taken, int[] used)
        {
            if (counter >= n)
            {
                Print(counter, taken);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (used[i] == 0)
                {
                    used[i] = 1;
                    taken[counter] = i+1;
                    RecursiveLoop(counter + 1, n, taken, used);
                    used[i] = 0;
                }
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
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] taken = new int[n];
            int[] used = new int[n];
            RecursiveLoop(0, n, taken, used);
        }
    }
}
