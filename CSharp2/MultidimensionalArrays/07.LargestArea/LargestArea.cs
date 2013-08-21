﻿using System;

class LargestArea
{

    static bool[,] visited = new bool[100, 100];
    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };
    static int newX;
    static int newY;

    static int dfs(int[,] matrix, int x, int y, int value)
    {
        if (visited[x, y])
        {
            return 0;
        }
        else
        {
            visited[x, y] = true;
            int best = 0;
            int bestX = x, bestY = y;
            for (int i = 0; i < 4; i++)
            {

                int modx = dx[i] + x;
                int mody = dy[i] + y;

                if (modx == -1 || modx >= matrix.GetLength(0) ||
                    mody == -1 || mody >= matrix.GetLength(1))
                {
                    continue;
                }

                if (matrix[modx, mody] == value)
                {
                    int v = dfs(matrix, modx, mody, value);
                    best += v;
                }
                newX = bestX;
                newY = bestY;
            }

            return best + 1;
        }
    }
    static void Main()
    {
        int[,] matrix = {{1, 3, 2, 1, 2, 1},
                         {3, 1, 3, 2, 2, 1},
                         {4, 1, 1, 2, 4, 3},
                         {3, 3, 2, 3, 3, 1},
                         {4, 3, 3, 3, 1, 3}};

        int current = 0;
        int max = 0;
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                if (visited[rows, cols] == false)
                {
                    current = dfs(matrix, rows, cols, matrix[rows, cols]);
                    if (current > max)
                    {
                        max = current;
                    }
                }
            }
        }
        Console.WriteLine(max);
    }
}

