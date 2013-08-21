using System;

class Program
{
    static void Main(string[] args)
    {
        int number = 5624728;
        bool prime = ((number % 1000) / 100) == 7;
        if (prime) Console.WriteLine("True");
        else Console.WriteLine("False");
    }
}
