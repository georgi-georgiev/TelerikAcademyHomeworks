using System;

class Matrix
{
    private int[,] matrix;
    private int rows;
    private int cols;

    public int Rows
    {
        get { return rows; }
        set { rows = value; }
    }
    public int Cols
    {
        get { return cols; }
        set { cols = value; }
    }
    public int this[int _rows, int _cols]
    {
        get { return matrix[_rows, _cols]; }
        set { matrix[_rows, _cols] = value; }
    }

    public Matrix(int _rows, int _cols)
    {
        matrix = new int[_rows, _cols];
        rows = _rows;
        cols = _cols;
    }

    public static Matrix operator +(Matrix one, Matrix two)
    {
        try
        {
            Matrix res = new Matrix(one.Rows, one.Cols);
            for (int rows = 0; rows < one.Rows; rows++)
            {
                for (int cols = 0; cols < one.Cols; cols++)
                {
                    res[rows, cols] = one[rows, cols] + two[rows, cols];
                }
            }
            return res;
        }
        catch
        {
            throw new System.InvalidOperationException("Use arrays with the same dimensions.");
        }
    }
    public static Matrix operator -(Matrix one, Matrix two)
    {
        try
        {
            Matrix res = new Matrix(one.Rows, one.Cols);
            for (int rows = 0; rows < one.Rows; rows++)
            {
                for (int cols = 0; cols < one.Cols; cols++)
                {
                    res[rows, cols] = one[rows, cols] - two[rows, cols];
                }
            }
            return res;
        }
        catch
        {
            throw new System.InvalidOperationException("Use arrays with the same dimensions.");
        }
    }
    public static Matrix operator *(Matrix one, Matrix two)
    {
        try
        {
            Matrix res = new Matrix(one.Rows, one.Cols);
            for (int rows = 0; rows < one.Rows; rows++)
            {
                for (int cols = 0; cols < one.Cols; cols++)
                {
                    res[rows, cols] += one[rows, cols] * two[cols, rows];
                }
            }
            return res;
        }
        catch
        {
            throw new System.InvalidOperationException("Use arrays with the same dimensions.");
        }
    }
    public override string[,] ToString(Matrix m)
    {
        string[,] res = new string[m.Rows, m.Cols];
        for (int rows = 0; rows < m.Rows; rows++)
        {
            for (int cols = 0; cols < m.Cols; cols++)
            {
                res[rows, cols] = m[rows, cols].ToString();
            }
        }
        return res;
    }
    public static void Print(Matrix m)
    {
         for (int rows = 0; rows < m.Rows; rows++)
        {
            for (int cols = 0; cols < m.Cols; cols++)
            {
                Console.Write("{0,-4}", m[rows, cols]);
            }
            Console.WriteLine();
        }
    }
}


