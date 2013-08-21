using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.CountWordsInTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("words.txt");
            Dictionary<string, int> values = new Dictionary<string, int>();
            string line = sr.ReadToEnd();
            string[] words = line.Split(new char[] {' '});

            for (int i = 0; i <words.Length; i++)
            {
                string lowerWord = words[i].ToLower();
                lowerWord = Regex.Replace(lowerWord, "[^A-Za-z0-9 _]", String.Empty);

                if (lowerWord != "")
                {
                    if (values.ContainsKey(lowerWord))
                    {

                        values[lowerWord] = values[lowerWord] + 1;
                    }
                    else
                    {
                        values.Add(lowerWord, 1);
                    }
                }
            }

            foreach (var word in values)
            {
                Console.WriteLine("{0} -> {1}",word.Key, word.Value);
            }
        }
    }
}
