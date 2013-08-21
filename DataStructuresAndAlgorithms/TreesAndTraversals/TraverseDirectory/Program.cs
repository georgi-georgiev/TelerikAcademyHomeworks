using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TraverseDirectory
{
    class Program
    {
        public static List<string> files = new List<string>();
 
        public static void TraverseDirectory(string currentPath, string fileExtension)
        {
            string[] currentFiles = Directory.GetFiles(currentPath, fileExtension);
            files.AddRange(currentFiles);

            string[] currentDirectories = Directory.GetDirectories(currentPath);
            foreach (var directory in currentDirectories)
            {
                TraverseDirectory(directory, fileExtension);
            }
        }

        public static void Main()
        {
            string rootPath = @"C:\Program Files";
            string fileExtension = "*.jpg";

            TraverseDirectory(rootPath, fileExtension);

            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
