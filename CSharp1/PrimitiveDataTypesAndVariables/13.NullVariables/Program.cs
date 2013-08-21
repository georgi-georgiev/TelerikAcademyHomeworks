using System;

class Program
{
    static void Main(string[] args)
    {
        int nullInt = null;
        double nullDouble = null;
        //Console.WriteLine(nullInt);
        //Console.WriteLine(nullDouble);
        nullInt += 1;
        nullDouble += null;
        Console.WriteLine(nullInt);
        Console.WriteLine(nullDouble);
    }
}
