using System;

class Program
{
    static void Main(string[] args)
    {
        int n = 7;
        int p = 4;
        int v = 1;
        int mask = v << p;
        int newNumber = n | mask;
        Console.WriteLine(newNumber);
    }
}
