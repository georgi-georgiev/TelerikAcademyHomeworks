using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{
    public class Mark
    {
        private ICollection<Student> students;
        public Mark()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public int Value { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }
    }
}
