using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClass
{
    private int size;
    private string numberOfColors;

    class Display
    {
        public Display()
        {
        }
        public Display(int size)
        {
            Size = size;
        }
        public Display(int size, string numberOfColors)
        {
            Size = size;
            NumberOfColors = numberOfColors;
        }
    }
}
