using System;

class Program
{
    static void Main(string[] args)
    {
        decimal radius = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Area: {0}\nPerimeter: {1}", (decimal)Math.PI * (radius * radius), 2 * (decimal)Math.PI * radius);
    }
}
