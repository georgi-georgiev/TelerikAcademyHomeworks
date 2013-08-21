using System;

public class Hello
{
    public static string NameGreeter(string name)
    {
        string greeting = "Hello, " + name + "!";
        return greeting;
    }

    public static void Main()
    {
        string name = Console.ReadLine();
        Console.WriteLine(NameGreeter(name));
    }
}
