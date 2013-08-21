namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : base(name)
        {
        }

        public LocalCourse(string name, string teacherName)
            : base(name, teacherName)
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
        }

        public LocalCourse(string name, string teacherName, IList<string> students, string lab)
            : base(name, teacherName, students)
        {
            if (lab != null)
            {
                this.Lab = lab;
            }
            else
            {
                throw new ArgumentNullException("Lab cannot be null!");
            }
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (value != null)
                {
                    this.lab = value;
                }
                else
                {
                    throw new ArgumentNullException("Lab cannot be null!");
                }
            }
        }

        public override string ToString()
        {
            if (this.Lab != null)
            {
                string result = base.ToString() + string.Format("; Lab = {0}", this.Lab) + " }";
                return result;
            }
            else
            {
                return base.ToString() + " }";
            }
        }
    }
}