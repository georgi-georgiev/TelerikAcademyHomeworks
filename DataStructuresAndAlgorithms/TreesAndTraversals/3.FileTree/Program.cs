using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FileTree
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryTree directory = new DirectoryTree("C:\\Windows");

            double size = directory.CalculateSizeOfTree();
            Console.WriteLine("{0} megabytes", size);
            Console.WriteLine("{0} gigabytes", size / 1024);
            
            size = directory.CalculateSizeOfFolder("Help");
            Console.WriteLine("{0} megabytes", size);
            Console.WriteLine("{0} gigabytes", size / 1024);
        }
    }
}
