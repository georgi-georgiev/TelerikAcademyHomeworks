using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypeSystem
{
    class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public string Adress { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public ushort Course { get; set; }
        public Specialties Specialty { get; set; }
        public Universities University { get; set; }
        public Faculties Faculty { get; set; }

        public Student(string firstName, string middleName, string lastName, string ssn,
            string adress,string mobilePhone, string email, ushort course,
            Specialties specialty, Universities university, Faculties faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Adress = adress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.FirstName);
            stringBuilder.AppendLine(this.MiddleName);
            stringBuilder.AppendLine(this.LastName);
            stringBuilder.AppendLine(this.Ssn);
            stringBuilder.AppendLine(this.Adress);
            stringBuilder.AppendLine(this.MobilePhone);
            stringBuilder.AppendLine(this.Email);
            stringBuilder.AppendLine(this.Course.ToString());
            stringBuilder.AppendLine(this.Specialty.ToString());
            stringBuilder.AppendLine(this.University.ToString());
            stringBuilder.AppendLine(this.Faculty.ToString());
            

            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            if (student == null)
              return false;

            if (this.FirstName != student.FirstName || this.MiddleName != student.MiddleName
                || this.LastName != student.LastName || this.Ssn != student.Ssn)
              return false;

            return true;

        }

        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(Student.Equals(student1, student2));
        }

        public override int GetHashCode()
        {
            return LastName.GetHashCode() ^ Ssn.GetHashCode();
        }

        public Student Clone()
        {
            Student clone = new Student
                (
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Ssn,
                this.Adress,
                this.MobilePhone,
                this.Email,
                this.Course,
                this.Specialty,
                this.University,
                this.Faculty
                );

            return clone;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student student)
        {
            if (this.FirstName.CompareTo(student.FirstName) != 0)
                return this.FirstName.CompareTo(student.FirstName);
            else if (this.MiddleName.CompareTo(student.MiddleName) != 0)
                return this.MiddleName.CompareTo(student.MiddleName);
            else if (this.LastName.CompareTo(student.LastName) != 0)
                return this.LastName.CompareTo(student.LastName);
            else
            {
                return this.Ssn.CompareTo(student.Ssn);
            }
        }
    }
}
