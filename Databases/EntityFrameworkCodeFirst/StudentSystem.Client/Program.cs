using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using StudentSystem.Models;
using System.Data.Entity;

namespace StudentSystem.Client
{
    internal class Program
    {
        static void Main()
        {
            Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion
                <StudentSystemContext, Configuration>());

            var db = new StudentSystemContext();
            
            var student = new Student { Name = "Pesho", Number=123456 };
            db.Students.Add(student);

            var course = new Course();
            course.Name = "PHP";
            course.Description = "Course for PHP Dummies";
            course.Materials = "Xampp, Browser";
            course.Students.Add(student);
            student.Courses.Add(course);
            db.Courses.Add(course);

            var homework = new Homework();
            homework.Content = "PHP Homework";
            homework.TimeSent = DateTime.Now;
            homework.Course = course;
            homework.Student = student;
            
            db.Homeworks.Add(homework);

            db.SaveChanges();
        }
    }
}
