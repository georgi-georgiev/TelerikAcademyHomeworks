using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    public class BitArray64 : IEnumerable<ulong>
    {
        private ulong bits;

        public BitArray64(int bits)
        {
            this.bits = (ulong)bits;
        }

        public ulong this[int index]
        {
            set
            {
                if (index < 0 || index >= 64)
                {
                    throw new ArgumentOutOfRangeException("The index must be between 0 and 63");
                }
                if (value == 0)
                {
                    this.bits &= ~(1ul << index);
                }
                else if (value == 1)
                {
                    this.bits |= 1ul << index;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The value must be 1 or 0");
                }
            }
            get
            {
                if (index < 0 || index >= 64)
                {
                    throw new ArgumentOutOfRangeException("The index must be between 0 and 63");
                }
                else
                {
                    return (this.bits >> index) & 1;
                }
            }
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            for (int i = 0; i < 64; ++i)
            {
                yield return (this.bits >> i) & 1;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() 
        { 
            return this.GetEnumerator(); 
        }

        public override bool Equals(object obj)
        {
            BitArray64 bitArray = obj as BitArray64;

            if (bitArray == null)
                return false;
            else if (bits == bitArray.bits)
                return true;
            else
                return false;
        }

        public static bool operator ==(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return BitArray64.Equals(bitArray1, bitArray2);
        }

        public static bool operator !=(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return !(BitArray64.Equals(bitArray1, bitArray2));
        }

        public override int GetHashCode()
        {
            //
            return 0;
        }

        public override string ToString()
        {
            //Show bits descending
            StringBuilder result = new StringBuilder();
            for (int i = 63; i >= 0; --i)
            {
                result.Append((this.bits >> i) & 1);
            }
            return result.ToString();
        }
    }
}
