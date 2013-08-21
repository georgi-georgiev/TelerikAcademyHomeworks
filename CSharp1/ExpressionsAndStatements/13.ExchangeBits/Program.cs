using System;

class Program
{
    static void Main(string[] args)
    {
        uint number = 1001001111;
        sbyte bitThree = (sbyte)(((1 << 3) & number) >> 3);
        sbyte bitTwentyFour = (sbyte)(((1 << 24) & number) >> 24);
        sbyte bitFour = (sbyte)(((1 << 4) & number) >> 4);
        sbyte bitTwentyFive = (sbyte)(((1 << 25) & number) >> 25);
        sbyte bitFive = (sbyte)(((1 << 5) & number) >> 5);
        sbyte bitTwentySix = (sbyte)(((1 << 26) & number) >> 26);

        if (bitThree == 1)
        {
            number = (uint)((1 << 24) | number);
        }
        else
        {
            number = (uint)(~(1 << 24) & number);
        }
        if (bitTwentyFour == 1)
        {
            number = (uint)((1 << 3) | number);
        }
        else
        {
            number = (uint)(~(1 << 3) & number);
        }
        if (bitFour == 1)
        {
            number = (uint)((1 << 25) | number);
        }
        else
        {
            number = (uint)(~(1 << 25) & number);
        }
        if (bitTwentyFive == 1)
        {
            number = (uint)((1 << 4) | number);
        }
        else
        {
            number = (uint)(~(1 << 4) & number);
        }
        if (bitFive == 1)
        {
            number = (uint)((1 << 26) | number);
        }
        else
        {
            number = (uint)(~(1 << 26) & number);
        }
        if (bitTwentySix == 1)
        {
            number = (uint)((1 << 5) | number);
        }
        else
        {
            number = (uint)(~(1 << 5) & number);
        }
        Console.WriteLine(number);
    }
}
