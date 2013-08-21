using System;
using System.Linq;

namespace MinimumEditDistance
{
    class EditDistance
    {
        private enum Operation
        {
            Skip = 0,
            Delete = 1,
            Insert = 2,
            Replace = 3
        }

        private static void PrintSteps(Operation[,] b, string S1, string S2, int i, int j)
        {
            if (i <= 0 && j <= 0)
            {
                return;
            }

            if (b[i, j] == Operation.Delete)
            {
                PrintSteps(b, S1, S2, i - 1, j);
                Console.WriteLine("Delete character '{0}' at position {1} from the first string.", S1[i], i);
            }
            else if (b[i, j] == Operation.Insert)
            {
                PrintSteps(b, S1, S2, i, j - 1);
                Console.WriteLine(
                    "Insert character '{0}' from the second string at position {1}" +
                    " into the first string at position {2}.",
                    S2[j], j, i);
            }
            else if (b[i, j] == Operation.Replace)
            {
                PrintSteps(b, S1, S2, i - 1, j - 1);
                Console.WriteLine(
                    "Replace character '{0}' at position {1} in the first string" +
                    " with character '{2}' at position {3} in the second string.",
                    S1[i], i, S2[j], j);
            }
            else
            {
                PrintSteps(b, S1, S2, i - 1, j - 1);
            }
        }

        private static void FindLevensteinDistance(string word1, string word2, double CD, double CI, double CR)
        {
            int m = word1.Length;
            int n = word2.Length;

            string S1 = "_" + word1;
            string S2 = "_" + word2;

            double[,] M = new double[m + 1, n + 1];
            Operation[,] b = new Operation[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                M[i, 0] = i * CD;
                b[i, 0] = Operation.Delete;
            }

            for (int j = 0; j <= n; j++)
            {
                M[0, j] = j * CI;
                b[0, j] = Operation.Insert;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (S1[i] == S2[j])
                    {
                        M[i, j] = M[i - 1, j - 1];
                        b[i, j] = Operation.Skip;
                    }
                    else
                    {
                        double min = CD + M[i - 1, j];
                        b[i, j] = Operation.Delete;

                        if (CI + M[i, j - 1] < min)
                        {
                            min = CI + M[i, j - 1];
                            b[i, j] = Operation.Insert;
                        }

                        if (CR + M[i - 1, j - 1] < min)
                        {
                            min = CR + M[i - 1, j - 1];
                            b[i, j] = Operation.Replace;
                        }

                        M[i, j] = min;
                    }
                }
            }

            Console.WriteLine("Total cost: " + M[m, n]);
            PrintSteps(b, S1, S2, m, n);
        }

        private static void Main()
        {
            FindLevensteinDistance("developer", "enveloped", 0.9, 0.8, 1);
        }
    }
}
