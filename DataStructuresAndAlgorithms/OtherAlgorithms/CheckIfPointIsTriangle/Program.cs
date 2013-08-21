using System;
using System.IO;
using System.Linq;

namespace CheckIfPointIsTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;
            input = "1.0 1.0|2.0 3.0|3.0 2.0|2.0 2.0";

            if (input != null)
                Console.SetIn(new StringReader(input.Replace(" ", "\n").Replace("|", "\n")));

            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            var x3 = double.Parse(Console.ReadLine());
            var y3 = double.Parse(Console.ReadLine());

            var x4 = double.Parse(Console.ReadLine());
            var y4 = double.Parse(Console.ReadLine());

            double dx = (x4 - x3);
            double dy = (y4 - y3);

            double A = x1 - x3;
            double B = y1 - y3;
            double C = x2 - x3;
            double D = y2 - y3;

            double denom = A * D - B * C;

            double alpha = D * dx - C * dy;
            alpha /= denom;

            double beta = -B * dx + A * dy;
            beta /= denom;

            double gamma = 1.0 - (alpha + beta);

            if (alpha >= 0 && beta >= 0 && gamma >= 0)
                Console.WriteLine("Point lies inside the triangle.");
            else
                Console.WriteLine("Point lies outside the triangle.");
        }
    }
}
