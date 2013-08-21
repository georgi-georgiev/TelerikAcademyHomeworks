using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordsOccurancesInFileWithTrie
{
    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            this.root = new TrieNode();
        }

        public void AddWord(string word)
        {
            var wordLen = word.Length;
            TrieNode current = root;
            for (int i = 0; i < wordLen; i++)
            {
                var nextStr = word[i];

                if (i == wordLen - 1)
                {
                    current.AddChild(nextStr, true);
                }
                else
                {
                    current.AddChild(nextStr, false);
                }

                current = current.Children[word[i]];
            }
        }

        public bool ContainsWord(string word, out int occurances)
        {
            occurances = 0;

            bool containsWord = false;

            var wordToLower = word.ToLower();
            var wordLen = word.Length;
            var current = this.root;

            for (int i = 0; i < wordLen; i++)
            {
                var nextChar = wordToLower[i];
                if (current.Children.ContainsKey(nextChar))
                {
                    current = current.Children[nextChar];
                }
                else
                {
                    break;
                }

                if (i == wordLen - 1 && current.IsWord)
                {
                    containsWord = true;
                    occurances = current.Occurances;
                }

            }

            return containsWord;
        }

        public bool ContainsStr(string str)
        {
            bool containsStr = true;
            var strLow = str.ToLower();
            var current = this.root;
            for (int i = 0; i < str.Length; i++)
            {
                var nextChar = strLow[i];
                if (current.Children.ContainsKey(nextChar))
                {
                    current = current.Children[nextChar];
                }
                else
                {
                    containsStr = false;
                    break;
                }
            }

            return containsStr;
        }

        public void BuildTrie(string loongString)
        {
            var current = this.root;

            for (int i = 0; i < loongString.Length; i++)
            {
                var currChar = loongString[i];

                currChar = currChar.ToString().ToLower()[0];

                if (current.Children.ContainsKey(currChar))
                {
                    if (current.Children[currChar] == null)
                    {
                        current.SetIsWord();
                        current = this.root;
                    }
                    else
                    {
                        current = current.Children[currChar];
                    }
                }
                else
                {
                    current.AddChild(currChar, false);
                    current = current.Children[currChar];
                }
            }

        }
    }
}
