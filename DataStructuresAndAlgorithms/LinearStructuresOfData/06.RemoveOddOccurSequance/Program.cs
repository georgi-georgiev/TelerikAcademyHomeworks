using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RemoveOddOccurSequance
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
                Console.Write(" " + list[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < list.Count; i++)
            {
                int subCounter = 0;
                for (int j = i; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        subCounter++;
                    }
                }

                if (subCounter % 2 != 0 || subCounter == 1)
                {
                    for (int k = 0; k < subCounter; k++)
                    {
                        list.Remove(list[i]);
                    }
                    i--;
                }
                else
                {
                    i += subCounter - 1;
                }
                
            }

            Console.Write("Without odd occur subsequances: ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
            }
            Console.WriteLine();
        }
    }
}
