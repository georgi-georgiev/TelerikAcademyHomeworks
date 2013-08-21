using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortIntegersWithList
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();//Split by space
            List<int> numbers = new List<int>();
            Console.Write("Unsort: ");
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(int.Parse(input[i]));
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i]);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        int swap = numbers[j];
                        numbers[j] = numbers[i];
                        numbers[i] = swap;
                    }
                }
            }

            //numbers.Sort();

            Console.WriteLine();

            Console.Write("Sort: ");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i]);
            }
            Console.WriteLine();
        }
    }
}
