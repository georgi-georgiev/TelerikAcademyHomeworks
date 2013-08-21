using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RisksWinsRiskLose
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> visited = new HashSet<string>();
            string initial = Console.ReadLine();
            string target = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                visited.Add(Console.ReadLine());
            }

            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
            queue.Enqueue(new Tuple<string,int>(initial, 0));
            visited.Add(initial);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Item1 == target)
                {
                    Console.WriteLine(current.Item2);
                    return;
                }

                StringBuilder sb = new StringBuilder(current.Item1);

                for (int i = 0; i < 5; i++)
                {
                    int digit = current.Item1[i] - '0';
                    digit++;
                    if (digit == 10)
                    {
                        digit = 0;
                    }
                    
                    sb[i] = (char)(digit+'0');
                    string newNode = sb.ToString();
                    if(!visited.Contains(newNode))
                    {
                        visited.Add(newNode);
                        queue.Enqueue(new Tuple<string,int>(newNode, current.Item2+1));
                    }

                    sb[i] = current.Item1[i];
                }

                for (int i = 0; i < 5; i++)
                {
                    int digit = current.Item1[i] - '0';
                    digit--;
                    if (digit == -1)
                    {
                        digit = 9;
                    }
                    
                    sb[i] = (char)(digit+'0');
                    string newNode = sb.ToString();
                    if(!visited.Contains(newNode))
                    {
                        visited.Add(newNode);
                        queue.Enqueue(new Tuple<string,int>(newNode, current.Item2+1));
                    }

                    sb[i] = current.Item1[i];
                }
            }
            Console.WriteLine(-1);
        }
    }
}
