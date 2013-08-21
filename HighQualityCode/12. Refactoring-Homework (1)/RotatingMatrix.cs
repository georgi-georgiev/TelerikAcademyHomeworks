using System;

namespace GameFifteen
{
    public class RotatingMatrix
    {
        private static int valueIncrementer = 1;
        private readonly static int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private readonly static int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        private static int[,] GenerateMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            int row = 0, col = 0;

            FillMatrix(matrix, ref row, ref col);
            FindFirstFreeCell(matrix, out row, out col);
            valueIncrementer++;

            if (n > 3)
            {
                FillMatrix(matrix, ref row, ref col);
            }
            return matrix;
        }

        private static void FillMatrix(int[,] matrix, ref int row, ref int col)
        {
            int currentDirectionX = 1;
            int currentDirectionY = 1;

            while (true)
            {
                matrix[row, col] = valueIncrementer;

                if (!IsCollusionWithBorderDetected(matrix, row, col))
                {
                    return;
                }

                while ((row + currentDirectionX >= matrix.GetLength(0) || row + currentDirectionX < 0 ||
                        col + currentDirectionY >= matrix.GetLength(0) || col + currentDirectionY < 0) ||
                       (matrix[row + currentDirectionX, col + currentDirectionY] != 0))
                {
                    ChangeCurrentDirection(ref currentDirectionX, ref currentDirectionY);
                }

                row += currentDirectionX;
                col += currentDirectionY;
                valueIncrementer++;
            }
        }

        private static void ChangeCurrentDirection(ref int currentDirectionX, ref int currentDirectionY)
        {
            int currentDirection = 0;
            for (int count = 0, len = directionX.Length; count < len; count++)
            {
                if (directionX[count] == currentDirectionX &&
                    directionY[count] == currentDirectionY)
                {
                    currentDirection = count;
                    break;
                }
            }

            if (currentDirection == directionX.Length - 1)
            {
                currentDirectionX = directionX[
                    (currentDirection + 1) % directionX.Length];
                currentDirectionY = directionY[
                    (currentDirection + 1) % directionX.Length];
            }
            else
            {
                currentDirectionX = directionX[currentDirection + 1];
                currentDirectionY = directionY[currentDirection + 1];
            }
        }

        private static bool IsCollusionWithBorderDetected(int[,] arr, int x, int y)
        {
            int[] collisionDetectionX = (int[])directionX.Clone();
            int[] collisionDetectionY = (int[])directionY.Clone();

            for (int i = 0; i < collisionDetectionX.Length; i++)
            {
                if ((x + collisionDetectionX[i] >= arr.GetLength(0)) ||
                    (x + collisionDetectionX[i] < 0))
                {
                    collisionDetectionX[i] = 0;
                }

                if ((y + collisionDetectionY[i] >= arr.GetLength(0)) ||
                    (y + collisionDetectionY[i] < 0))
                {
                    collisionDetectionY[i] = 0;
                }
            }

            for (int i = 0; i < collisionDetectionX.Length; i++)
            {
                if (arr[(x + collisionDetectionX[i]),
                    (y + collisionDetectionY[i])] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void FindFirstFreeCell(int[,] matrix, out int emptyCellAtXPos, out int emptyCellAtYPos)
        {
            emptyCellAtXPos = 0;
            emptyCellAtYPos = 0;

            for (int row = 0, rowLen = matrix.GetLength(0); row < rowLen; row++)
            {
                for (int col = 0, colLen = matrix.GetLength(1); col < colLen; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        emptyCellAtXPos = row;
                        emptyCellAtYPos = col;
                        return;
                    }
                }
            }
        }

        private static void PrintMatrix(int[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0}{1}", matrix[row, col], new string(' ',
                        ((size * size).ToString().Length) - matrix[row, col].ToString().Length + 1));
                }

                Console.WriteLine();
            }
        }

        public static void InitializeMatrix(string input)
        {
            int size = 0;
            bool isValidInput = int.TryParse(input, out size);

            if (isValidInput && (0 < size && size < 101))
            {
                int[,] matrix = GenerateMatrix(size);

                PrintMatrix(matrix, size);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Valid Range is [1..100].");
            }
        }

        static void Main(string[] args)
        {
            InitializeMatrix(Console.ReadLine());
        }
    }
}