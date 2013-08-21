using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresEfficiency
{
    public class Students : IComparable<Students>
    {
        public Students(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }

        public string Firstname
        {
            get;
            private set;
        }

        public string Lastname
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return this.Firstname+" "+this.Lastname;
        }

        public int CompareTo(Students other)
        {
            return string.Compare(this.Lastname, other.Lastname) +
            string.Compare(this.Firstname, other.Lastname);
        }
    }
}
