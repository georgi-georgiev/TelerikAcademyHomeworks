using System;

class Program
{
    static void Main(string[] args)
    {
        int firstInteger = int.Parse(Console.ReadLine());
        int secondInteger = int.Parse(Console.ReadLine());
        int counter = 0;

        while (firstInteger <= secondInteger)
        {
            if (firstInteger % 5 == 0)
            {
                counter++;
            }
            firstInteger++;
        }
        Console.WriteLine(counter);
    }
}
