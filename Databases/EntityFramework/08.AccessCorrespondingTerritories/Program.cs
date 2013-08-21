using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.UsingVSFDesigner;

namespace _08.AccessCorrespondingTerritories
{
    class Program
    {
        public partial class Employee : EntitySet<Territory>
        {
            public EntitySet<Territory> Territory { get; set; }
        }
    }
}
