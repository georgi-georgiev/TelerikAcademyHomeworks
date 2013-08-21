using System;

class Program
{
    static void Main(string[] args)
    {
        int a = 127;
        int b = 3;
        int mask = 1 << b;
        int rightBit = (a & mask) >> b;
        Console.WriteLine(rightBit);
    }
}
