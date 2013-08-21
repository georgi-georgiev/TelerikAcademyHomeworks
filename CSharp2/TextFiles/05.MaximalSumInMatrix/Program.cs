using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the size of the matrix");
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];
        int[,] newMatrix = new int[size, size];

        StreamWriter writer = new StreamWriter("..//..//Matrix.txt");

        using (writer)
        {
            writer.WriteLine(size);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.WriteLine("Enter Element matrix[{0},{1}]", row, col);
                    matrix[row, col] = int.Parse(Console.ReadLine());
                    writer.Write(matrix[row, col] + " ");

                }
                writer.WriteLine();
            }
        }

        StreamReader matrixOutput = new StreamReader("..//..//Matrix.txt");

        using (matrixOutput)
        {
            string reader = matrixOutput.ReadLine();

            while (reader != null)
            {
                reader = matrixOutput.ReadLine();
                int length = int.Parse(reader);
                for (int p = 0; p < length; p++)
                {
                    for (int q = 0; q < length; q++)
                    {
                        for (int i = 0; i < reader.Length; i++)
                        {
                            if (reader[i] != ' ')
                            {
                                newMatrix[p, q] = reader[i] - '0';
                                q++;
                            }
                        }
                        reader = matrixOutput.ReadLine();
                    }
                }
            }
        }
        StreamWriter result = new StreamWriter("..//..//Result.txt");
        using (result)
        {
            result.WriteLine("The Biggest Sum is: {0}", BestSum(newMatrix));
        }

    }

    static int BestSum(int[,] matrix)
    {
        int sum = 0;
        int bestSum = 0;
        for (int row = 0; row < matrix.GetLongLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLongLength(1) - 1; col++)
            {
                sum = 0;
                for (int i = 0; i < 2; i++)
                {
                    for (int p = 0; p < 2; p++)
                    {
                        sum += matrix[row + i, col + p];
                    }
                }
                if (sum > bestSum)
                {
                    bestSum = sum;
                }
            }
        }
        return bestSum;
    }
}
