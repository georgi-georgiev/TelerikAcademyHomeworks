using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Ivan", "Georgiev", "Ivanov", "64423", "Sofiq", "5329", "vankata@gmail.com",
                2, Specialties.ComputerScience, Universities.Su, Faculties.Mathematics);


            Console.WriteLine(student1);
            Console.WriteLine(student1.GetHashCode());

            Console.WriteLine();

            Student student2 = new Student("Pesho", "Enev", "Zagariev", "6453", "Plovdiv", "5123", "pesho@gmail.com",
                3, Specialties.Mathematics, Universities.American, Faculties.Mathematics);

            Console.WriteLine(student2);
            Console.WriteLine(student2.GetHashCode());

            Console.WriteLine();

            Console.WriteLine("Are equals? {0}",student1==student2);
        }
    }
}
