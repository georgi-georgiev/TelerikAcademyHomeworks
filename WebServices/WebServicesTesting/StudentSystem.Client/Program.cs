using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using StudentSystem.Model;

namespace StudentSystem.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();

            var firstMark = new Mark() { Subject = "Math", Value = 6 };
            var secondMark = new Mark() { Subject = "FBS", Value = 5 };
            
            
            var student = new Student() { FirstName = "Peter", LastName = "Petrov", Age = 20, Grade=2};
            student.Marks.Add(firstMark);
            student.Marks.Add(secondMark);

            var school = new School() { Name = "PMG", Location = "Sofia" };
            school.Students.Add(student);

            context.Schools.Add(school);

            context.SaveChanges();
        }
    }
}
