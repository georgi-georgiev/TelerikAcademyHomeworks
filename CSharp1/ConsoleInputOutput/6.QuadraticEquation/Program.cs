using System;

class Program
{
    static void Main(string[] args)
    {
        double firstCoef = double.Parse(Console.ReadLine());
        double secondCoef = double.Parse(Console.ReadLine());
        double thridCoef = double.Parse(Console.ReadLine());

        double D = secondCoef * secondCoef - 4 * firstCoef * thridCoef;

        double x, x1, x2;
        if (D > 0)
        {
            x1 = (-secondCoef + Math.Sqrt(D)) / (2 * firstCoef);
            x2 = (-secondCoef - Math.Sqrt(D)) / (2 * firstCoef);
            Console.WriteLine("x1 = {0} x2 = {1}", x1, x2);
        }
        else if (D < 0)
        {
            Console.WriteLine("No solution");
        }
        else if(D == 0)
        {
            x = -secondCoef / (2 * firstCoef);
            Console.WriteLine("x = {0}", x);
        }
    }
}
