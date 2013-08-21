using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.HowMuchTimesEachOccur
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();//Split by space
            List<int> list = new List<int>();
            List<int> exist = new List<int>();
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
                int countExist = 0;
                for (int j = i; j < list.Count; j++)
                {
                    if(list[i]==list[j])
                    {
                        if (!exist.Contains(list[i]))
                        {
                            countExist++;
                        }
                    }
                }
                
                if (!exist.Contains(list[i]))
                {
                    Console.WriteLine("{0} -> {1} times", list[i], countExist);

                    exist.Add(list[i]);
                }
            }
        }
    }
}
