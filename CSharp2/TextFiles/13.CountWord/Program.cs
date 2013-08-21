using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] words = File.ReadAllLines("words.txt");
            string[] test = File.ReadAllLines("test.txt");
            string outPut = "";

            foreach (var word in words)
            {
                outPut += "\"" + word + "\" :";
                int count = 0;
                foreach (var item in test)
                {
                    if (item == word)
                    {
                        count++;
                    }
                }
                outPut += count + "\r\n";
            }
            File.WriteAllText("result.txt", outPut);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (SecurityException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
