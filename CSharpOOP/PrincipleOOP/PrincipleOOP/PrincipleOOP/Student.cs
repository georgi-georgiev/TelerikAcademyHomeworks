using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipleOOP
{
    public class Student : Person, ICommentable
    {
        public Student(string name, int uniqueClassNumber) : base(name)
        {
            this.UniqueClassNumber = uniqueClassNumber;
        }

        public int UniqueClassNumber{ get; private set;}

        public List<string> Comments { get; set; }

        public void AddComment(string comment)
        {
            Comments.Add(comment);
        }
    }
}
