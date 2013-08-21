namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name)
            : base(name)
        {
        }

        public OffsiteCourse(string name, string teacherName)
            : base(name, teacherName)
        {
        }

        public OffsiteCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
        }

        public OffsiteCourse(string name, string teacherName, IList<string> students, string town)
            : base(name, teacherName, students)
        {
            if (town != null)
            {
                this.Town = town;
            }
            else
            {
                throw new ArgumentNullException("Town could not be null!");
            }
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (value != null)
                {
                    this.town = value;
                }
                else
                {
                    throw new ArgumentNullException("Town cannot be null!");
                }
            }
        }

        public override string ToString()
        {
            if (this.Town != null)
            {
                string result = base.ToString() + string.Format("; Town = {0}", this.Town) + " }";
                return result;
            }
            else
            {
                return base.ToString() + " }";
            }
        }
    }
}