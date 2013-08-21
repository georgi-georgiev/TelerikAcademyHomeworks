using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeException
{
    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T start, T end)
            : base(message)
        {
            this.Start = start;
            this.End = end;
        }

        public T Start { get; private set; }
        public T End { get; private set; }
    }
}
