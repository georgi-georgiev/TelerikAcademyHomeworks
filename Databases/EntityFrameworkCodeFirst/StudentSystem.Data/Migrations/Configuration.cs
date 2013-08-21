namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Models;


    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            context.Students.AddOrUpdate(new Student { Name = "Misho", Number =1234567 });
            context.Students.AddOrUpdate(new Student { Name = "Dobo", Number = 42342132 });

            context.Courses.AddOrUpdate(new Course { Name = "CSS", Description = "CSS Course", Materials="Browser, Notepad++" });
            context.Courses.AddOrUpdate(new Course { Name = "Javascript", Description = "Javascript Course", Materials = "Browser, Notepad++" });

            context.Homeworks.AddOrUpdate(new Homework { Content = "CSS Homework", TimeSent = DateTime.Now, CourseId=1, StudentId=1 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "Javascript Homework", TimeSent = DateTime.Now, CourseId = 2, StudentId = 2 });
        }
    }
}
