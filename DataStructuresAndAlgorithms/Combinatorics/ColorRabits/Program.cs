using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorRabits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] rabbits = new int[n];
            for (int i = 0; i < n; i++)
            {
                rabbits[i] = int.Parse(Console.ReadLine());
            }

            int[] rabitsCounter = new int[1000002];

            for (int i = 0; i < rabbits.Length; i++)
            {
                rabitsCounter[rabbits[i] + 1]++;
            }

            int min = 0;
            for (int i = 0; i < rabitsCounter.Length; i++)
            {
                if (rabitsCounter[i] == 0)
                {
                    continue;
                }
                if (rabitsCounter[i] <= i)
                {
                    min += i;
                }
                else
                {
                    min += (int)Math.Ceiling((double)rabitsCounter[i] / i) * i;
                }
            }
            Console.WriteLine(min);
        }
    }
}
