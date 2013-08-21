using System;
using System.Collections.Generic;
using System.Text;

public class SimpleTasksSolver
{
    // Reverse digits
    public static string DigitReverser(string inputNumber)
    {
        StringBuilder newNumber = new StringBuilder();
        for (int i = inputNumber.Length - 1; i >= 0; i--)
        {
            newNumber.Append(inputNumber[i]);
        }

        return newNumber.ToString();
    }

    // Average of a set
    public static decimal AverageOfASet(decimal[] setArray)
    {
        decimal sum = 0;
        for (int i = 0; i < setArray.Length; i++)
        {
            sum = sum + setArray[i];
        }

        return sum / setArray.Length;
    }

    // Linear solver
    public static decimal LinearSolver(decimal a, decimal b)
    {
        // a * x + b = 0
        decimal x = -(b / a);
        return x;
    }

    public static void Main()
    {
        // Text menu
        Console.WriteLine("For reversing the digit of number enter \"1\"");
        Console.WriteLine("For average of set of numbers enter \"2\"");
        Console.WriteLine("For linear equation solver enter \"3\"");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            Console.WriteLine("Enter the number:");
            string input = Console.ReadLine();
            Console.WriteLine("The new number is: {0}", DigitReverser(input));
        }
        else if (choice == 2)
        {
            int n = 0;
            do
            {
                Console.WriteLine("Enter how many numbers you will enter. The number must be different from 0 :");
                n = int.Parse(Console.ReadLine());
            }
            while (n == 0);
            decimal[] setOfNums = new decimal[n];
            for (int i = 0; i < setOfNums.Length; i++)
            {
                Console.WriteLine("Enter number {0}", i + 1);
                setOfNums[i] = decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine("The average of the set is: {0}", AverageOfASet(setOfNums));
        }
        else if (choice == 3)
        {
            decimal a = 0;
            do
            {
                Console.WriteLine("Enter A, that is NOT 0 :");
                a = int.Parse(Console.ReadLine());
            }
            while (a == 0);
            Console.WriteLine("Enter B:");
            decimal b = int.Parse(Console.ReadLine());
            Console.WriteLine("The root of the equation is: {0}", LinearSolver(a, b));
        }
        else
        {
            Console.WriteLine("Wrong input, try again.");
            Main();
        }
    }
}
