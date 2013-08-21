using System;

class Program
{
    static void Main(string[] args)
    {
        int v = 5;
        int p = 1;
        int mask = 1 << p;
        int rightBit = (v & mask) >> p;
        if (rightBit == 1)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}
