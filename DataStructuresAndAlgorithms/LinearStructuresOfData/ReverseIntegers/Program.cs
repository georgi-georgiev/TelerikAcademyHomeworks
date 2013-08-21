using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseIntegers
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            Stack<int> newNumbers = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                numbers.Push(int.Parse(Console.ReadLine()));
            }
            Console.Write("Old stack: ");
            while(numbers.Count>0)
            {
                int number = numbers.Pop();
                Console.Write(number);
                newNumbers.Push(number);
            }
            Console.WriteLine();
            Console.Write("New stack: ");
            while(newNumbers.Count > 0)
            {
                int number = newNumbers.Pop();
                Console.Write(number);
            }
            Console.WriteLine();
        }
    }
}
