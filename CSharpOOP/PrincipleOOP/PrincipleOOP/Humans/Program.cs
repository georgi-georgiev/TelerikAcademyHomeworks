using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            { 
                new Student( "Student1","Lastname1", 1 ),
                new Student( "Student2","Lastname2", 2 ),
                new Student( "Student3","Lastname3", 3 ),
                new Student( "Student4","Lastname4", 4 ),
                new Student( "Student5","Lastname5", 5 ),
                new Student( "Student6","Lastname6", 6 ),
                new Student( "Student7","Lastname7", 7 ),
                new Student( "Student8","Lastname8", 8 ),
                new Student( "Student9","Lastname9", 9 ),
                new Student( "Student10","Lastname10", 10 )
            };

            var elements = from element in students
                            orderby element.Grade ascending
                            select element;

            foreach (var element in elements)
            {
                Console.WriteLine("{0} {1} {2}", element.FirstName, element.LastName, element.Grade);
            }

            Console.WriteLine();

            List<Worker> workers = new List<Worker>()
            {
                new Worker("Worker1", "Worker1Family", 3000, 9),
                new Worker("Worker2", "Worker2Family", 2000, 8),
                new Worker("Worker3", "Worker3Family", 3500, 7),
                new Worker("Worker4", "Worker4Family", 3600, 7),
                new Worker("Worker5", "Worker5Family", 3700, 6),
                new Worker("Worker6", "Worker6Family", 2900, 8),
                new Worker("Worker7", "Worker7Family", 1500, 9),
                new Worker("Worker8", "Worker8Family", 500, 8),
                new Worker("Worker9", "Worker9Family", 4000, 7),
                new Worker("Worker10", "Worker10Family", 5000, 8)
            };

            var elems = from el in workers
                           orderby el.MoneyPerHour() descending
                           select el;

            foreach (var el in elems)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", el.FirstName, el.LastName, el.WeekSalary, el.WorkHoursPerDay, el.MoneyPerHour());
            }

            Console.WriteLine();

            var mergedlists = workers.Concat<Human>(students).ToList();
            mergedlists = mergedlists.OrderBy(list => list.FirstName).ThenBy(list => list.LastName).ToList();

            foreach (var item in mergedlists)
            {
                Console.WriteLine("{0} {1}",item.FirstName, item.LastName);
            }
        }

    }
}
