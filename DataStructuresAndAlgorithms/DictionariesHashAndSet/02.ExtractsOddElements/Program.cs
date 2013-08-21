using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ExtractsOddElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splittedInput = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> values = new Dictionary<string, int>();

            for (int i = 0; i < splittedInput.Length; i++)
            {

                if (values.ContainsKey(splittedInput[i]))
                {

                    values[splittedInput[i]] = values[splittedInput[i]]+1;
                }
                else
                {
                    values.Add(splittedInput[i], 1);
                }
            }

            foreach (var word in values)
            {
                if (word.Value % 2 != 0)
                {
                    Console.WriteLine(word.Key);
                }
            }
        }
    }
}
