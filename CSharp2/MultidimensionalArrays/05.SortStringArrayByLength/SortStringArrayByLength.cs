using System;
using System.Collections.Generic;
using System.Linq;

class SortStringArrayByLength
{
    static List<string> SortByLength(string[] str)
    {
        var sorted = from s in str
                              orderby ((string)s).Length ascending
                              select s;
        List<string> res = new List<string>(sorted);
        return res;
    }
    static void Main()
    {
        string[] input = { "artertqweb", "ccdt", "aga", "bbe", "dderssa" };

        List<string> sorted = SortByLength(input);
        foreach (var item in sorted)
        {
            Console.WriteLine(item);
        }
    }
}

