using System;

class Program
{
    static void Main(string[] args)
    {

        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());

        while (firstNumber > secondNumber)
        {
            Console.WriteLine(firstNumber);
            break;
        }
        while (secondNumber > firstNumber)
        {
            Console.WriteLine(secondNumber);
            break;
        }
    }
}