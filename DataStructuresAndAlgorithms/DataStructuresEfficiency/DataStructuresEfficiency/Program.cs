using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace DataStructuresEfficiency
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("students.txt");
            
            OrderedMultiDictionary<string, Students> students = new OrderedMultiDictionary<string, Students>(true);
            string line;
            while (sr.Peek() >= 0)
            {
                line = sr.ReadLine();
                string[] splittedInput = line.Split(new char[] { '|' });
                students.Add(splittedInput[2].Trim(), new Students(splittedInput[0].Trim(), splittedInput[1].Trim()));
            }
            foreach (var student in students)
            {
                Console.WriteLine("{0}: {1}", student.Key, student.Value.ToString());
            }
        }
    }
}
