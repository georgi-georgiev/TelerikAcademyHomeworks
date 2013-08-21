using System;
using System.IO;

class Program
{
    static void Main()
    {
        using (StreamReader input = new StreamReader("../../input.txt"))
        {
            for (int i; (i = input.Read()) != -1; )
            {
                if (i == '>')
                {
                    string text = String.Empty;

                    while ((i = input.Read()) != -1 && i != '<') text += (char)i;

                    if (!String.IsNullOrWhiteSpace(text)) Console.WriteLine(text.Trim());
                }
            }
        }
    }
}
