using System;

public class Variations
{
    public static void VariationsGen(int[] array, int index, int allElements)
    {
        if (array.Length == index)
        {
            PrintVar(array);
        }
        else
        {
            for (int i = 1; i < allElements + 1; i++)
            {
                array[index] = i;
                VariationsGen(array, index + 1, allElements);
            }
        }
    }

    public static void PrintVar(int[] array)
    {
        Console.Write("{ ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }

        Console.Write("}");
        Console.WriteLine();
    }

    public static void Main()
    {
        int allElements = 3;
        int variationElements = 2;
        int[] vars = new int[variationElements];
        VariationsGen(vars, 0, allElements);
    }
}
