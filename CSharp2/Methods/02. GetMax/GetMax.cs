using System;

public class GetMaxProgram
{
    public static int GetMax(int first, int second)
    {
        if (first > second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

    public static void Main()
    {
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        int thirdNum = int.Parse(Console.ReadLine());
        int biggest = 0;
        biggest = GetMax(firstNum, secondNum);
        biggest = GetMax(thirdNum, biggest);
        Console.WriteLine(biggest);
    }
}
