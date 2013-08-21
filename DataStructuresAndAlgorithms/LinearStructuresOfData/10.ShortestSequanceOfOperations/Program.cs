using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.ShortestSequanceOfOperations
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            Queue<int> seq = new Queue<int>();
            seq.Enqueue(n);
            while (m != n)
            {
                while (n * 2 < m/2)
                {
                    n *= 2;
                    seq.Enqueue(n);
                }
                if(!(n+1==m || (n+1)*2==m || n*2==m || ((n+1)*2)+1==m))
                {
                    n+=2;
                    seq.Enqueue(n);
                }
                else if (!(n + 1 == m || (n + 2) == m))
                {
                    n *= 2;
                    seq.Enqueue(n);
                }
                else if (!(n + 2 == m || (n + 2) * 2 == m || n * 2 == m))
                {
                    n += 1;
                    seq.Enqueue(n);
                }
                
            }
            while (seq.Count > 0)
            {
                if (seq.Count == 1)
                {
                    Console.Write(seq.Dequeue());
                }
                else
                {
                    Console.Write(seq.Dequeue() + " -> ");
                }
            }
            Console.WriteLine();
        }
    }
}
