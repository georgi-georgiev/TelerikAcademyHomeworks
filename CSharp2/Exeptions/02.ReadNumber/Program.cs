using System;

class Program
{
    static void Main(string[] args)
    {
        int start = 20;
        int end = 80;
        ReadNumber(start, end);

    }

    static void ReadNumber(int start, int end)
    {
        int temp;
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Enter Number {0}",i+1);
            try
            {
                temp = int.Parse(Console.ReadLine());
                if (temp < start || temp > end)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number or number out of range");
            }
        }
    }
}
