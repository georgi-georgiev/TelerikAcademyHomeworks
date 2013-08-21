using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RemoveNegativeNumbersFromSequance
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();//Split by space
            List<int> list = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                list.Add(int.Parse(input[i]));
            }
            Console.Write("Sequance: ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(" "+list[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            Console.Write("Sequance without negative numbers: ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(" "+list[i]);
            }

            Console.WriteLine();
        }
    }
}
