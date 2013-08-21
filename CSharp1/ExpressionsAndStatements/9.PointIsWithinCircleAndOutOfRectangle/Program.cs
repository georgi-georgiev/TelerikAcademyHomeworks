using System;

class Program
{
    static void Main(string[] args)
    {
        double x = 1;
        double y = 1;
        if ((Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1)) <= 3) && (((x - (-1)) * (x - 5) >= 0) || (y - (-1)) * (y - 1) >= 0))
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
