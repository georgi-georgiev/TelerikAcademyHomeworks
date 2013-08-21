using System;

class Program
{
    static void Main(string[] args)
    {
        decimal sum = 1;
        decimal oldSum = -1;
        for (decimal i = 2; i < 100000000; i++)
        {
            if (i % 2 == 0)
            {
                sum += (1 / i);
            }
            else
            {
                sum -= (1 / i);
            }

            if (sum - oldSum == 0.001M)
            {
                break;
            }
            else
            {
                oldSum = sum;
            }
        }
        Console.WriteLine(sum);
    }
}
