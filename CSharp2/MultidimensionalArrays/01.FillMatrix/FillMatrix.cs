using System;

class FillMatrix
{
    static int[,] fillMatrixA(int n)
    {
        int count = 1;
        int[,] matrix = new int[n, n];
        for (int rows = 0; rows < n; rows++)
        {
            for (int cols = 0; cols < n; cols++)
            {
                matrix[cols, rows] = count++;
            }
        }
        return matrix;
    }
    static int[,] fillMatrixB(int n)
    {
        int[,] matrix = new int[n, n];
        int count = 1;
        for (int rows = 0; rows < n; rows++)
        {
            if (rows % 2 == 0)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[cols, rows] = count++;
                }
            }
            else
            {
                for (int cols = n-1; cols >= 0; cols--)
                {
                    matrix[cols, rows] = count++;
                }
            }
        }
        return matrix;
    }
    static int[,] FillMatrixC(int n)
    {
        int[,] matrix = new int[n, n];
        int rows = 0;
        int cols = 0;
        int value = 1;

        for (int i = n - 1; i >= 0; i--)
        {
            rows = i;
            cols = 0;
            while (rows < n && cols < n)
            {
                matrix[rows++, cols++] = value++;
            }
        }

        for (int j = 1; j < n; j++)
        {
            rows = j;
            cols = 0;
            while (rows < n && cols < n)
            {
                matrix[cols++, rows++] = value++;
            }
        }
        return matrix;
    }
    static int[,] FillMatrixD(int n)
    {
        int[,] result = new int[n, n];
        int numberToAdd = 1;
        int globalCounter = n;
        int tempValue = -n;
        int sum = -1;

        do
        {
            tempValue = -1 * tempValue / n;
            for (int i = 0; i < globalCounter; i++)
            {
                sum += tempValue;
                result[sum / n, sum % n] = numberToAdd;
                numberToAdd++;
            }
            tempValue *= n;
            globalCounter--;
            for (int i = 0; i < globalCounter; i++)
            {
                sum += tempValue;
                result[sum / n, sum % n] = numberToAdd;
                numberToAdd++;
            }
        } while (globalCounter > 0);

        return result;
    }

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
    static void Main()
    {
        int n = 4;
        int[,] a = FillMatrixC(n);
        PrintMatrix(a);
    }
}
