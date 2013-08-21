using System;

class Program
{
    static void Main(string[] args)
    {
        bool flag = false;
        int number = 47;
        for (int count = 2; count < number; ++count)
        {
            if (number % count == 0)
            {
                flag = true;
                break;
            }
        }
        if (!flag)
        {
            Console.WriteLine("The number is prime");
                
        }
        else
        {
            Console.WriteLine("The number is not prime");
        }
    }
}
