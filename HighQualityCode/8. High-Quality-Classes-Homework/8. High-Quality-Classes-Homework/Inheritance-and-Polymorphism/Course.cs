namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students = new List<string>();

        protected Course(string name)
        {
            if (name != null)
            {
                this.Name = name;
            }
            else
            {
                throw new ArgumentNullException("Name of the course cannot be null!");
            }
        }

        protected Course(string name, string teacherName)
            : this(name)
        {
            if (teacherName != null)
            {
                this.TeacherName = teacherName;
            }
            else
            {
                throw new ArgumentNullException("Name of if the teacher cannot be null!");
            }
        }

        protected Course(string name, string teacherName, IList<string> students)
            : this(name, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value != null)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (value != null)
                {
                    this.teacherName = value;
                }
                else
                {
                    throw new ArgumentNullException("Teacher name cannot be null!");
                }
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value != null)
                {
                    this.students = value;
                }
                else
                {
                    throw new ArgumentNullException("Students list cannot be null!");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append(" { Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}