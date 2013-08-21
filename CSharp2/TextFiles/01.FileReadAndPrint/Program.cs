using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\Georgi\Desktop\Telerik\Homeworks\file.txt";
        Encoding utf8 = Encoding.GetEncoding("UTF-8");
        Encoding win1251 = Encoding.GetEncoding("Windows-1251");
        try
        {
            StreamReader fileReader = new StreamReader(path, win1251);
            using (fileReader)
            {
                int lineNum = 0;
                string line = fileReader.ReadLine();
                while (line != null)
                {
                    lineNum++;
                    if (lineNum % 2 != 0)
                    {
                        Console.WriteLine("Line {0}: {1}", lineNum, line);
                    }
                    line = fileReader.ReadLine();
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Error!");
        }
    }
}
