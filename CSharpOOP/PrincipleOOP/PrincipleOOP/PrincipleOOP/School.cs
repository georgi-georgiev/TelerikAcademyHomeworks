using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipleOOP
{
    public class School
    {
        private List<Class> classes;
        private bool p;

        public School(List<Class> classes)
        {
            this.classes = classes;
        }

        public School(bool p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public List<Class> Classes
        {
            get
            {
                return this.classes;
            }
        }
    }
}
