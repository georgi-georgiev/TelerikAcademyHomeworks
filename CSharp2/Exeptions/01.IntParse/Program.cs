using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new Exception();
            }
            else
            {
                Console.WriteLine(Math.Sqrt(number));
            }
        }
        catch(Exception)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
