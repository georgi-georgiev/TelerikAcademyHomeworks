using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipleOOP
{
    class Program
    {
        public static void Main()
        {
            List<Discipline> disc1 = new List<Discipline>();
            disc1.Add(new Discipline("math", 2, 5));

            List<Discipline> disc2 = new List<Discipline>();
            disc2.Add(new Discipline("math", 2, 5));

            Teacher teacher1 =  new Teacher("Gosho", disc1);
            Teacher teacher2 = new Teacher("Pesho", disc2);

            Student student1 = new Student("Emo", 1);
            Student student2 = new Student("Dimo", 2);

            Class class1 = new Class("1",
                new List<Teacher>() { teacher1, teacher2 },
                new List<Student>() { student1, student2});

            School school = new School(new List<Class>() { class1 });

            Console.WriteLine(school.Classes[0].Id);
            Console.WriteLine(school.Classes[0].Teachers[0].Name);
            Console.WriteLine(school.Classes[0].Teachers[0].Disciplines[0].Name);
            Console.WriteLine(school.Classes[0].Teachers[0].Disciplines[0].NumberOfLectures);
            Console.WriteLine(school.Classes[0].Teachers[0].Disciplines[0].NumberOfExcercises);
            
        }
    }
}
