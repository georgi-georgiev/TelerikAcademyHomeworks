using System;

class PrintMyAgeAfterTenYears
{
    static void Main()
    {
        String input = Console.ReadLine();
        int age = Convert.ToInt16(input);
        age += 10;
        Console.WriteLine(age);
    }
}
