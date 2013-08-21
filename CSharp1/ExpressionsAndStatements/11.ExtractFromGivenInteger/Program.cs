using System;

class Program
{
    static void Main(string[] args)
    {
        int i = 5;
        int b = 2;
        int mask = 1 << b;
        int rightBit = (i & mask) >> b;
        Console.WriteLine(rightBit);
    }
}
