using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat[] cats = 
            {
                new Cat(5, "Cat1", "Male"),
                new Cat(6, "Cat2", "Female")
            };

            Dog[] dogs =
            {
                new Dog(5, "Dog1", "Male"),
                new Dog(6, "Dog2", "Female")
                
            };

            Frog[] frogs =
            {
                new Frog(5, "Frog1", "Male"),
                new Frog(6, "Frog2", "Female")
                
            };

            Kitten[] kittens =
            {
                new Kitten(5, "Kitten1"),
                new Kitten(6, "Kitten2")
                
            };

            TomCat[] tomCats =
            {
                new TomCat(5, "TomCat1"),
                new TomCat(6, "TomCat2")
                
            };

            cats[0].ProduceSound();
            Console.WriteLine(cats[0].Name);
            Console.WriteLine(cats[1].Name);
            Console.WriteLine(Animal.CalculateAverage(cats));

            Console.WriteLine();

            dogs[0].ProduceSound();
            Console.WriteLine(dogs[0].Name);
            Console.WriteLine(dogs[1].Name);
            Console.WriteLine(Animal.CalculateAverage(dogs));

            Console.WriteLine();

            frogs[0].ProduceSound();
            Console.WriteLine(frogs[0].Name);
            Console.WriteLine(frogs[1].Name);
            Console.WriteLine(Animal.CalculateAverage(frogs));

            Console.WriteLine();

            kittens[0].ProduceSound();
            Console.WriteLine(kittens[0].Name);
            Console.WriteLine(kittens[1].Name);
            Console.WriteLine(Animal.CalculateAverage(kittens));

            Console.WriteLine();

            tomCats[0].ProduceSound();
            Console.WriteLine(tomCats[0].Name);
            Console.WriteLine(tomCats[1].Name);
            Console.WriteLine(Animal.CalculateAverage(tomCats));
            
        }
    }
}
