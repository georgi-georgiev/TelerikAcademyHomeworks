using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Include
{
    class Program
    {
        static void Main()
        {
            TelerikAcademyEntities telerikAcademyEntities = new TelerikAcademyEntities();
            PrintCustomersAndRegionsWithQueryProblem(telerikAcademyEntities);
            PrintCustomersAndRegionsWithoutQueryProblem(telerikAcademyEntities);
        }

        static void PrintCustomersAndRegionsWithQueryProblem(TelerikAcademyEntities context)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            foreach (var employee in context.Employees)
            {
                Console.WriteLine("Name: {0}; Town: {1}; Department: {2}",
                    employee.FirstName, employee.Address.Town.Name,
                    employee.Department.Name);
            }
            Console.WriteLine(sp.Elapsed);
            sp.Stop();
        }

        static void PrintCustomersAndRegionsWithoutQueryProblem(TelerikAcademyEntities context)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            foreach (var employee in context.Employees.Include("Address").Include("Address.Town").Include("Department"))
            {
                Console.WriteLine("Name: {0}; Town: {1}; Department: {2}",
                employee.FirstName, employee.Address.Town.Name, employee.Department.Name);
            }
            Console.WriteLine(sp.Elapsed);
            sp.Stop();
            
        }
    }
}
