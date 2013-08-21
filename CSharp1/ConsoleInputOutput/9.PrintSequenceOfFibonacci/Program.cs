using System;

class Program
{
    static void Main(string[] args)
    {
        decimal previousNumer = 0;
        decimal currentNumber = 1;

        decimal nextNumber = 0;

        for (int i = 0; i <= 100; i++)
        {
            Console.WriteLine(previousNumer);
            nextNumber = previousNumer + currentNumber;
            previousNumer = currentNumber;
            currentNumber = nextNumber;
        }
    }
}
