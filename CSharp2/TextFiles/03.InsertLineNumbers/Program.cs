using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string fileOne = @"C:\Users\Georgi\Desktop\Telerik\Homeworks\file.txt";
        string fileTwo = @"C:\Users\Georgi\Desktop\Telerik\Homeworks\writefile.txt";
        Encoding win1251 = Encoding.GetEncoding("Windows-1251");
        try
        {
            StreamReader reader = new StreamReader(fileOne, win1251);
            StreamWriter writer = new StreamWriter(fileTwo, false, win1251);
            string line;
            int lineNum = 0;
            using (reader)
            {
                line = reader.ReadLine();
                using (writer)
                {
                    while (line != null)
                    {
                        lineNum++;
                        line = "Line " + lineNum + ": " + line;
                        writer.WriteLine(line);
                        line = reader.ReadLine();
                    }
                }
            }
            Console.WriteLine("Successesful line numbering!");
        }
        catch (Exception)
        {
            Console.WriteLine("Error!");
        }
    }
}
