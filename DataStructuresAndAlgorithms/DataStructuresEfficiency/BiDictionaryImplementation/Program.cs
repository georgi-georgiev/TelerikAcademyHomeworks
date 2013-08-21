using System;
using System.Linq;

namespace BiDictionaryImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            BiDictionary<string, int, string> bidictionary = new BiDictionary<string, int, string>(true);

            bidictionary.Add("Nasko", 4, "PHP");
            bidictionary.Add("Joro", 3, "C#");
            bidictionary.Add("Petar", 4, "C++");
            bidictionary.Add("Raicho", 1, "PERL");
            bidictionary.Add("Filip", 4, "Java");
            bidictionary.Add("Sasho", 2, "Listy");

            Console.WriteLine(string.Join(" ", bidictionary.GetByFirstKey("Joro")));
            Console.WriteLine(string.Join(" ", bidictionary.GetBySecondKey(3)));
            Console.WriteLine(string.Join(" ", bidictionary.GetByFirstAndSecondKey("Sasho", 2)));

            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveByFirstKey("Raicho");
            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveBySecondKey(2);
            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveByFirstAndSecondKey("Nasko", 4);
        }
    }
}
