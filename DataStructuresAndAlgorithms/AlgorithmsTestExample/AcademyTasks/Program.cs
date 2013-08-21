using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbersOfPleasantness = Console.ReadLine();
            int variety = int.Parse(Console.ReadLine());
            string[] pleasantnessParts = numbersOfPleasantness.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            int[] pleasantness = new int[pleasantnessParts.Length];
            for (int i = 0; i < pleasantnessParts.Length; i++)
            {
                pleasantness[i] = int.Parse(pleasantnessParts[i]);   
            }
            

            Console.WriteLine(minNumber(pleasantness, variety));
        }

        static int minNumber(int[] pleasantness, int variety)
        {
            int result = pleasantness.Length;
            for (int i = 0; i < pleasantness.Length; i++)
            {
                for (int j = i + 1; j < pleasantness.Length; j++)
                {
                    int difference = Math.Abs(pleasantness[i] - pleasantness[j]);
                    if (difference < variety)
                    {
                        continue;
                    }
                    int actual = (i + 3) / 2;
                    int k = (j - i);
                    actual += (k + 1) / 2;
                    result = Math.Min(result, actual);
                }
            }
            return result;
        } 
    }
}
