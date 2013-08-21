using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Include;

namespace _02.ToList
{
    class Program
    {
        static void Main()
        {
            ShowEmployees_Slow();
            ShowEmployees_Fast();
        }

        private static void ShowEmployees_Slow()
        {
            TelerikAcademyEntities telerikAcademyEntities = new TelerikAcademyEntities();
            var employees=
                from employee in telerikAcademyEntities.Employees.ToList()
                join address in telerikAcademyEntities.Addresses.ToList()
                    on employee.AddressID equals address.AddressID
                join town in telerikAcademyEntities.Towns.ToList()
                    on address.TownID equals town.TownID
                where town.Name == "Sofia"
                select new
                {
                    Name = employee.FirstName,
                    Town = town.Name
                };

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1}", employee.Name, employee.Town);
            }
        }

        private static void ShowEmployees_Fast()
        {
            TelerikAcademyEntities telerikAcademyEntities = new TelerikAcademyEntities();
            var employees =
                (from employee in telerikAcademyEntities.Employees
                join address in telerikAcademyEntities.Addresses
                    on employee.AddressID equals address.AddressID
                join town in telerikAcademyEntities.Towns
                    on address.TownID equals town.TownID
                where town.Name == "Sofia"
                select new
                {
                    Name = employee.FirstName,
                    Town = town.Name
                }).ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1}", employee.Name, employee.Town);
            }
        }
    }
}
