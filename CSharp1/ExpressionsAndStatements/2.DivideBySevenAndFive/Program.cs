using System;

class Program
{
    static void Main(string[] args)
    {
        int number = 42;
        if ((number % 5 == 0) && (number % 7 == 0))
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
