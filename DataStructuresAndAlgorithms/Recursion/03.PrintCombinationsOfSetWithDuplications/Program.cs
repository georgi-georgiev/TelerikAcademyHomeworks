using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PrintCombinationsOfSetWithDuplications
{
    class Program
    {
        static void RecursiveLoop(int counter, int start, int n, int k, int[] taken)
        {
            if (counter > k)
            {
                return;
            }
            
            for (int i =start; i < n; i++)
            {
                taken[counter - 1] =i+1;
                if (counter == k)
                {
                    Print(counter, taken);
                }
                RecursiveLoop(counter + 1, i, n, k, taken);
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
            int k = int.Parse(Console.ReadLine());
            int[] taken = new int[k];
            RecursiveLoop(1, 0, n, k, taken);
        }
    }
}
