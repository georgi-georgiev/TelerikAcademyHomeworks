using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Pesho");
            Console.WriteLine(person1);

            Console.WriteLine();

            Person person2 = new Person("Tosho", 18);
            Console.WriteLine(person2);
        }
    }
}
