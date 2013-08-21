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
        StringBuilder equal = new StringBuilder();
        StringBuilder notEqual = new StringBuilder();
        equal.Append("Same lines: ");
        notEqual.Append("Different lines: ");
        string lineX = null;
        string lineY = null;
        int lineNum=0;
        try
        {
            StreamReader readerOne = new StreamReader(fileOne, win1251);
            StreamReader readerTwo = new StreamReader(fileTwo, win1251);
            using (readerOne)
            {
                lineX = readerOne.ReadLine();
                using (readerTwo)
                {
                    lineY = readerTwo.ReadLine();
                    while (lineY != null && lineX != null)
                    {
                        lineNum++;
                        if (lineX == lineY)
                        {
                            equal.Append(lineNum + " ");
                        }
                        else
                        {
                            notEqual.Append(lineNum + " ");
                        }
                        lineX = readerOne.ReadLine();
                        lineY = readerTwo.ReadLine();
                    }
                }
            }
            Console.WriteLine(equal.ToString());
            Console.WriteLine(notEqual.ToString());
        }
        catch (Exception)
        {
            Console.WriteLine("Error!");
        }
               
    }
}
