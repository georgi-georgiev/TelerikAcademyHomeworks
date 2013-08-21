using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string file1 = @"C:\Users\Georgi\Desktop\Telerik\Homeworks\file.txt";
        string file2 = @"C:\Users\Georgi\Desktop\Telerik\Homeworks\file.txt";
        string file3 = @"C:\Users\Georgi\Desktop\Telerik\Homeworks\writefile.txt";
        Encoding win1251 = Encoding.GetEncoding("Windows-1251");
        try
        {
            StreamReader reader1 = new StreamReader(file1, win1251);
            StreamReader reader2 = new StreamReader(file2, win1251);
            StreamWriter write = new StreamWriter(file3, false, win1251);
            using (write)
            {
                string f1;
                string f2;
                using (reader1)
                {
                    f1 = reader1.ReadToEnd();
                }
                using (reader2)
                {
                    f2 = reader2.ReadToEnd();
                }
                write.WriteLine(f1);
                write.WriteLine(f2);
                Console.WriteLine("Successesful concatenation!");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Error!");
        }
    }
}
