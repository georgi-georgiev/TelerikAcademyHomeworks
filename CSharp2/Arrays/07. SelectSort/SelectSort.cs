using System;

public class SelectSort
{
    public static void Main()
    {
        int[] myArray = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 11, 132, 45, -2, 333 };
        for (int i = 0; i < myArray.Length - 1; i++)
        {
            int elmMin = i;
            for (int j = i + 1; j < myArray.Length; j++)
            {
                if (myArray[j] < myArray[elmMin])
                {
                    elmMin = j;
                }
            }

            if (elmMin != i)
            {
                int temp = 0;
                temp = myArray[i];
                myArray[i] = myArray[elmMin];
                myArray[elmMin] = temp;
            }
        }

        for (int i = 0; i < myArray.Length; i++)
        {
            Console.Write("{0}, ", myArray[i]);
        }

        Console.WriteLine();
    }
}
