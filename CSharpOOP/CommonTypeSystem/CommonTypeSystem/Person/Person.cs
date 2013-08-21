using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name;
        private int? age;

        public string Name
        {
            get { return this.name; }
        }

        public int? Age
        {
            get { return this.age; }
        }

        public Person(string name)
            : this(name, null)
        {
        }

        public Person(string name, int? age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.name, this.age.ToString());
        }
    }
}
