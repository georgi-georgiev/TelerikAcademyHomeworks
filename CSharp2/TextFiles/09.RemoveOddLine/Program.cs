using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static List<string> ReadEvenLines()
    {
        List<string> lines = new List<string>();

        int n = 1;

        using (StreamReader input = new StreamReader("../../input.txt"))
            for (string line; (line = input.ReadLine()) != null; n++)
                if (n % 2 == 0) lines.Add(line);

        return lines;
    }

    static void WriteLines(List<string> lines)
    {
        using (StreamWriter output = new StreamWriter("../../input.txt"))
            foreach (string line in lines)
                output.WriteLine(line);
    }

    static void Main()
    {
        WriteLines(ReadEvenLines()); // TODO: Do it without storing the lines in the memory
    }
}