using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("D  |  H  |  C");
        for (int count = 0; count <= 127; count++)
        {
            Console.WriteLine("{0}  |  {1}  |  {2}", count, count.ToString("X"), (char)count);

        }
    }
}
