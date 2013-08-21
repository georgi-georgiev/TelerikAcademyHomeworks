using System;

class Program
{
    static void Main(string[] args)
    {
        byte p = 2;
        byte q = 3;
        byte k = 3;
        int number = 32;

        for (int count = 0; count < k; ++count)
        {
            byte bitP = (byte)(((1 << p) & number) >> p);
            byte bitQ = (byte)(((1 << q) & number) >> q);
            if (bitP == 1)
            {
                number = (int)((1 << q) | number);
            }
            else
            {
                number = (int)(~(1 << q) & number);
            }
            if (bitQ == 1)
            {
                number = (int)((1 << p) | number);
            }
            else
            {
                number = (int)(~(1 << p) & number);
            }
            p++;
            q++;
        }
        Console.WriteLine(number);
    }
}
