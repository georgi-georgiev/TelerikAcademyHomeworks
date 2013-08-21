using System;

class Program
{
    static void Main()
    {
        double firstNumber = Convert.ToDouble(Console.ReadLine());
        int fractionFirstNumber = new System.Version(firstNumber.ToString()).Minor;
        double secondNumber = Convert.ToDouble(Console.ReadLine());
        int fractionSecondNumber = new System.Version(secondNumber.ToString()).Minor;
        if (fractionFirstNumber.ToString().Length == fractionSecondNumber.ToString().Length)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}
