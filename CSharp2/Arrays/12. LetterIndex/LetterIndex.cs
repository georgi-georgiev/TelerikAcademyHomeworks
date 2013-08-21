using System;
public class LetterIndex
{
    public static void Main()
    {
        int[] letterIndexes = new int[53];

        // Lowercase
        for (int i = 1; i < (letterIndexes.Length / 2) + 1; i++)
        {
            letterIndexes[i] = ('a' - 1) + i;
        }

        // Upercase
        for (int i = (letterIndexes.Length / 2) + 1, k = 0; i < letterIndexes.Length; i++, k++)
        {
            letterIndexes[i] = 'A' + k;
        }

        // Letter chercker
        string testWord = "TSYZ";
        for (int i = 0; i < testWord.Length; i++)
        {
            for (int j = 0; j < letterIndexes.Length; j++)
            {
                if (testWord[i] == letterIndexes[j])
                {
                    Console.WriteLine("Leter {0} has index: {1}", testWord[i], j);
                    break;
                }
            }
        }
    }
}
