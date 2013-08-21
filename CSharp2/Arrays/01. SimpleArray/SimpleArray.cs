using System;

public class SimpleArray
{
    public static void Main()
    {
        int[] indexArray = new int[20];
        for (int i = 0; i < indexArray.Length; i++)
        {
            indexArray[i] = i * 5;
        }

        for (int i = 0; i < indexArray.Length; i++)
        {
            Console.Write(indexArray[i]);
            Console.WriteLine();
        }

        
    }
}
