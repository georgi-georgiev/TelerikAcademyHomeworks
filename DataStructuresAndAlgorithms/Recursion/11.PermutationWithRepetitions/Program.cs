using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PermutationWithRepetitions
{
    class Program
    {
        private static HashSet<string> allPermCheck = new HashSet<string>();
        private static List<string> allPermutation = new List<string>();
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            Array.Sort(numbers);
            Permutation(numbers, 0, numbers.Length);
            foreach (var item in allPermutation)
            {
                Console.WriteLine(item);
            }
        }

        public static void Permutation(int[] numbers, int start, int last)
        {
            CheckForPermutation(numbers);

            int oldValue = 0;

            if (start < last)
            {
                for (int i = last - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < last; j++)
                    {
                        if (numbers[i] != numbers[j])
                        {
                            oldValue = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = oldValue;

                            Permutation(numbers, i + 1, last);
                        }
                    }

                    oldValue = numbers[i];
                    for (int k = i; k < last - 1; )
                    {
                        numbers[k] = numbers[++k];
                    }
                    numbers[last - 1] = oldValue;
                }
            }
        }
        private static void CheckForPermutation(int[] permutation)
        {
            string perm = string.Join(" ", permutation);
            if (!allPermCheck.Contains(perm))
            {
                allPermCheck.Add(perm);
                allPermutation.Add(perm);
            }
        }
    }
}
