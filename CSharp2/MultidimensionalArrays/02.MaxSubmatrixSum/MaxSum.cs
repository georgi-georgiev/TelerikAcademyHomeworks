using System;

class MaxSum
{
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0, -4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    static int[] FindMaxSum(int[,] matrix)
    {
        int[] res = new int[2];
        int currentSum = 0;
        int columnMaxSum = 0;
        int maxSum = 0;
        int startingRowIndex = 0;
        int startingColIndex = 0;
        for (int rows = 0; rows <= matrix.GetLength(0) - 3; rows++)
        {
            for (int cols = 0; cols <= matrix.GetLength(1) - 3; cols++)
            {
                currentSum += matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows, cols + 1] +
                   matrix[rows + 1, cols] + matrix[rows + 1, cols + 1] + matrix[rows + 1, cols + 2] +
                   matrix[rows + 2, cols] + matrix[rows + 2, cols + 1] + matrix[rows + 2, cols + 2];
                if (currentSum > columnMaxSum)
                {
                    columnMaxSum = currentSum;
                    startingColIndex = cols;
                }
            }
            if (columnMaxSum > maxSum)
            {
                maxSum = columnMaxSum;
                startingRowIndex = rows;
            }
        }
        res[0] = startingRowIndex;
        res[1] = startingColIndex;
        return res;
    }


    static void Main()
    {
        int n = 4;
        int m = 4;

        int[,] matrix = {{1, 2, 3, 4},
                         {1, 2, 3, 4},
                         {1, 2, 3, 4},
                         {1, 2, 3, 4}};
        PrintMatrix(matrix);
        int[] res = FindMaxSum(matrix);
        Console.WriteLine(res[0] + " " + res[1]);
    }
}
