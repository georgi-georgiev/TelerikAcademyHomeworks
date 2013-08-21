using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordsOccurancesInFileWithTrie
{
    public class TrieNode
    {
        public static char[] Separators = { '.', ',', ';', ':', '\'', ' ', '"', '\n', '\r', '!', '?', '#', '(', ')', '[', ']', '{', '}', '\t', '*', '—' };

        public int Occurances { get; private set; }

        public TrieNode()
        {
            this.Children = new Dictionary<char, TrieNode>();
            this.InitializeFinalizerChildren();
            this.IsWord = false;
            this.Occurances = 0;
        }

        public TrieNode(bool isWord)
            : this()
        {
            this.IsWord = isWord;
        }

        public bool IsWord { get; private set; }

        public Dictionary<char, TrieNode> Children { get; private set; }

        public void AddChild(char value, bool isWord)
        {
            if (this.Children.ContainsKey(value))
            {
                if (isWord)
                {
                    this.Children[value].SetIsWord();
                }
            }
            else
            {
                this.Children.Add(value, new TrieNode(isWord));
            }
        }

        public void SetIsWord()
        {
            this.IsWord = true;
            this.Occurances++;
        }

        private void InitializeFinalizerChildren()
        {
            foreach (var sep in TrieNode.Separators)
            {
                AddFinalizerChild(sep);
            }
        }

        private void AddFinalizerChild(char value)
        {
            this.Children.Add(value, null);
        }
    }
}
