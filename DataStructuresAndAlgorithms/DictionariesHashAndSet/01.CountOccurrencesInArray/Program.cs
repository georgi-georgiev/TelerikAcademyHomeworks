using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CountOccurrencesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splittedInput = input.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, int> values = new Dictionary<int, int>();

            for (int i = 0; i < splittedInput.Length; i++)
            {
                int currentNumber = int.Parse(splittedInput[i]);

                if (values.ContainsKey(currentNumber))
                {
                    values[currentNumber] = currentNumber + 1;
                }
                else
                {
                    values.Add(currentNumber, 1);
                }
            }

            foreach (var number in values)
            {
                Console.WriteLine("Number {0} -> {1}", number.Key, number.Value);
            }
        }
    }
}
