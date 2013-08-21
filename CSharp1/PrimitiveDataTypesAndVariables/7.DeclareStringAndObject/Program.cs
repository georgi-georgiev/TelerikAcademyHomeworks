using System;

class Program
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object concatenation = hello +" "+ world;
        string objectString = (string)concatenation;
        Console.WriteLine(objectString);
    }
}
