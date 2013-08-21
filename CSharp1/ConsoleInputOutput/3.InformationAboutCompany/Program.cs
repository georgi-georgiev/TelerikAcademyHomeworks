using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.InformationAboutCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Company name: ");
            string companyName = Console.ReadLine();
            Console.Write("Company address: ");
            string companyAddress = Console.ReadLine();
            Console.Write("Company phone number: ");
            string companyPhoneNumber = Console.ReadLine();
            Console.Write("Company fax number: ");
            string companyFaxNumber = Console.ReadLine();
            Console.Write("Company web site: ");
            string companyWebSite = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Manager first name: ");
            string managerFirstName = Console.ReadLine();
            Console.Write("Manager last name: ");
            string managerLastName = Console.ReadLine();
            Console.Write("Manager age: ");
            string managerAge = Console.ReadLine();
            Console.Write("Manager phone number: ");
            string managerPhoneNumber = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Company name: {0}\nCompany address: {1}\nCompany phone number: {2}\nCompany fax number: {3}\nCompany web site: {4}",
                companyName, companyAddress, companyPhoneNumber, companyFaxNumber, companyWebSite);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Manager first name: {0}\nManager last name: {1}\nManager age: {2}\nManager phone number: {3}",
                managerFirstName, managerLastName, managerAge, managerPhoneNumber);
        }
    }
}
