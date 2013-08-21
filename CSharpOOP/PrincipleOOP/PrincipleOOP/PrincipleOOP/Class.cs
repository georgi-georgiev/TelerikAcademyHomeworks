using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipleOOP
{
    public class Class
    {
        private string id;
        private List<Teacher> teachers;
        private List<Student> students;
        private int p;

        public Class(string id, List<Teacher> teachers, List<Student> students)
        {
            this.id = id;
            this.teachers = teachers;
            this.students = students;
        }

        public Class(int p, List<Teacher> teachers, List<Student> students)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.teachers = teachers;
            this.students = students;
        }

        public string Id
        {
            get { return this.id; }
        }

        public List<Teacher> Teachers
        {
            get { return this.teachers; }
        }

        public List<Student> Students
        {
            get { return this.students; }
        }
    }
}
