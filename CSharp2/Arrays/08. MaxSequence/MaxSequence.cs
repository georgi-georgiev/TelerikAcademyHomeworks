﻿using System;
using System.Text;

public class MaxSequence
{
    public static void Main()
    {
        int[] myArray = { 2, 3, -6, 36, -7, -1, -2, 4, -8, 8 };
        int currentSum = 0;
        int bestSum = 0;
        StringBuilder bestSequenceBuild = new StringBuilder();
        string bestSequnce = string.Empty;
        for (int i = 0; i < myArray.Length; i++)
        {
            currentSum = currentSum + myArray[i];
            bestSequenceBuild.AppendFormat("{0}, ", myArray[i]);
            if (currentSum > bestSum)
            {
                bestSum = currentSum;
                bestSequnce = bestSequenceBuild.ToString();
            }

            if (currentSum < 0)
            {
                currentSum = 0;
                bestSequenceBuild.Clear();
            }
        }

        Console.WriteLine("The best sequence is: \" {0} \" ", bestSequnce);
        Console.WriteLine("The best sum is: {0} ", bestSum);
    }
}
