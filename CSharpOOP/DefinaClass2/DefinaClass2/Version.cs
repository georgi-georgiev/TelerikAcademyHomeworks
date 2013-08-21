using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefinaClass2
{
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct |
                    AttributeTargets.Interface |
                    AttributeTargets.Enum |
                    AttributeTargets.Method)
    ]
    public class Version : Attribute
    {
        private int minorVersion;
        private int majorVersion;

        public Version(int majorVersion, int minorVersion)
        {
            this.minorVersion = minorVersion;
            this.majorVersion = majorVersion;
        }

        public string Versions
        {
            get
            {
                return string.Format("{0}.{1}", this.majorVersion, this.minorVersion);
            }
        }
    }
}
