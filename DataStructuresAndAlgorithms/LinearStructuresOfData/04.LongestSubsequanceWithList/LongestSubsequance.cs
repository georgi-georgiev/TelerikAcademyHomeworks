using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.LongestSubsequanceWithList
{
    public class LongestSubsequance
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();//Split by space
            List<int> numbers = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(int.Parse(input[i]));
            }
            Console.WriteLine(String.Join("", GetLongestSubSequance(numbers)));
        }

        public static List<int> GetLongestSubSequance(List<int> numbers)
        {
            
            List<int> seq = new List<int>();
            int maxSubsequance = 0;
            int subsequanceNumber = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int countSubsequance = 0;
                for (int j = i; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        countSubsequance++;

                        if ((j == (numbers.Count - 1)) && (countSubsequance > maxSubsequance))
                        {
                            maxSubsequance = countSubsequance;
                            subsequanceNumber = numbers[i];
                        }
                    }
                    else
                    {
                        if (countSubsequance > maxSubsequance)
                        {
                            maxSubsequance = countSubsequance;
                            subsequanceNumber = numbers[i];
                        }
                        break;
                    }
                }

                if (numbers.Count == countSubsequance)
                {
                    return numbers;
                }
                
            }

            for (int i = 0; i < maxSubsequance; i++)
            {
                seq.Add(subsequanceNumber);
            }

            return seq;
        }
    }
}
