using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordsOccurancesInFileWithTrie
{
    class Program
    {
        const string wordsfile = "words.txt";
        const string words2file = "words2.txt";

        static void Main()
        {
            var trie = BuildTrie();

            var words = GetWords();

            SortedDictionary<string, int> wordsAndOccurances = new SortedDictionary<string, int>();
            foreach (var word in words)
            {
                int occurances = 0;
                trie.ContainsWord(word, out occurances);
                if (!wordsAndOccurances.ContainsKey(word))
                {
                    wordsAndOccurances.Add(word, occurances);
                }
            }

            Console.WriteLine(wordsAndOccurances.Count);

            PrintWordOccurances(wordsAndOccurances);
        }

        private static void PrintWordOccurances(SortedDictionary<string, int> wordsAndOccurances)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in wordsAndOccurances.OrderBy(x => x.Value))
            {
                sb.AppendFormat("{0} -> {1}\n", item.Key, item.Value);
            }

            Console.WriteLine(sb.ToString());
        }

        private static string[] GetWords()
        {
            var wordsText = ReadFile(words2file);
            var words = wordsText.Split(TrieNode.Separators, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        private static Trie BuildTrie()
        {
            var trie = new Trie();
            var text = ReadFile(words2file);
            trie.BuildTrie(text);
            return trie;
        }

        private static string ReadFile(string fileLocation)
        {
            var reader = new StreamReader(fileLocation);
            string content;
            using (reader)
            {
                content = reader.ReadToEnd();
            }

            return content;
        }

        private static void MultiplyFileHundredTimes(string fileloc)
        {
            var reader = new StreamReader(fileloc);
            string content = null;
            using (reader)
            {
                content = reader.ReadToEnd();
            }

            var writer = new StreamWriter(fileloc);
            using (writer)
            {
                for (int i = 0; i < 100; i++)
                {
                    writer.Write(content);
                }
            }
        }
    }
}
