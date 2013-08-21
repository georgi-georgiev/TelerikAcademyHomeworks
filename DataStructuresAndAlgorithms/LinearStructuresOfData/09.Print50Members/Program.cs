using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Print50Members
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> seq = new Queue<int>();
            seq.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                int index = seq.Peek();

                seq.Dequeue();

                seq.Enqueue(index + 1);

                seq.Enqueue((2 * index) + 1);

                seq.Enqueue(index + 2);

                Console.WriteLine(index);
            }
        }
    }
}
