using System;

class Program
{
    static void Main(string[] args)
    {
        int x = 7;
        int y = 4;
        if (Math.Sqrt(x * x + y * y) <= 5)
        {
            Console.WriteLine("Yes \n");
        }
        else
        {
            Console.WriteLine("No \n");
        }
    }
}
