using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearStructuresOfData
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            float sum = 0;
            float avarage = 0;
            while (input > 0)
            {
                numbers.Add(input % 10);
                input /= 10;
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            avarage = sum / numbers.Count;
            Console.WriteLine("Sum : {0}", sum);
            Console.WriteLine("Avarage : {0}", avarage);
        }
    }
}
