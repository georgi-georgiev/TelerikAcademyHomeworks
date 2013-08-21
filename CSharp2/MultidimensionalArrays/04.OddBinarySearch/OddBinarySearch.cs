using System;
using System.Collections.Generic;

class OddBinarySearch
{
    static void Merge(int[] arr, int left, int middle, int middle1, int right)
    {
        int originalStartPosition = left;
        int size = right - left + 1;
        int[] temp = new int[size];
        int i = 0;

        while (left <= middle && middle1 <= right)
        {
            if (arr[left] <= arr[middle1])
                temp[i++] = arr[left++];
            else
                temp[i++] = arr[middle1++];
        }

        if (left > middle)
        {
            for (int j = middle1; j <= right; j++)
            {
                temp[i++] = arr[middle1++];
            }
        }
        else
        {
            for (int j = left; j <= middle; j++)
            {
                temp[i++] = arr[left++];
            }
        }

        Array.Copy(temp, 0, arr, originalStartPosition, size);
    }
    static void MergeSortAlg(int[] arr, int left, int right)
    {
        int middle;
        if (right > left)
        {
            middle = (right + left) / 2;
            MergeSortAlg(arr, left, middle);
            MergeSortAlg(arr, middle + 1, right);
            Merge(arr, left, middle, middle + 1, right);
        }
    }


    static void Main()
    {
        int valueToSearch = 5;
        int[] input = {3, 2, 5, 6, 1, 3};
        
        MergeSortAlg(input, 0, input.Length-1);


        int index = Array.BinarySearch(input, valueToSearch);

        if (input[index] == valueToSearch)
        {
            Console.WriteLine(index);
        }
        else
        {
            Console.WriteLine(-index - 1);
        }
    }
}

