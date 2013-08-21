using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTestExample
{
    class Program
    {
        static List<KeyValuePair<char, string>> encoding = new List<KeyValuePair<char, string>>();
        static string secretMessage;

        static void Main(string[] args)
        {
            secretMessage = Console.ReadLine();
            string chiper = Console.ReadLine();
            
            char letter = '\0';
            StringBuilder encode = new StringBuilder();
            for (int i = 0; i < chiper.Length; i++)
            {
                
                if (chiper[i] >= 'A' && chiper[i] <= 'Z')
                {
                    if (letter != '\0')
                    {
                        encoding.Add(new KeyValuePair<char, string>(letter, encode.ToString()));
                        encode.Clear();
                    }
                    letter = chiper[i];
                    
                }
                else
                {
                    encode.Append(chiper[i]);
                }
            }
            encoding.Add(new KeyValuePair<char, string>(letter, encode.ToString()));

            FindEncoding(0, new StringBuilder());

            Console.WriteLine(answers.Count);
            answers.Sort();
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }

        static List<string> answers = new List<string>();

        static void FindEncoding(int secretMessageIndex, StringBuilder result)
        {
            if (secretMessageIndex == secretMessage.Length)
            {
                answers.Add(result.ToString());
                return;
            }
            foreach(var enc in encoding)
            {
                if (secretMessage.Substring(secretMessageIndex).StartsWith(enc.Value))
                {
                    result.Append(enc.Key);
                    FindEncoding(secretMessageIndex+enc.Value.Length, result);
                    result.Length--;
                }
            }
        }
    }
}
