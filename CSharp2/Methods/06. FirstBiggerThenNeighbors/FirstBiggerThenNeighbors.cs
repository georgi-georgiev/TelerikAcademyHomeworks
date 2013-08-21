using System;

public class FirstBiggerThenNeighbors
{
    public static int BiggerNeighborFinder(int[] array)
    {
        int index = 0;
        for (int i = 1; i < array.Length - 1; i++)
        {
            if ((array[i] > array[i + 1]) && (array[i] > array[i - 1]))
            {
                index = i;
                break;
            }
            else
            {
                index = -1;
            }
        }

        return index;
    }

    public static void Main()
    {
        int[] myArray = { 8, 2, 3, 4, 5, 6, 7, 10 };
        Console.WriteLine(BiggerNeighborFinder(myArray));
    }
}
