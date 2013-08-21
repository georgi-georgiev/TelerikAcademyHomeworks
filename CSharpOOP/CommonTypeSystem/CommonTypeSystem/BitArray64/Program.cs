using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 bitArray1 = new BitArray64(2);
            

            foreach (var bit in bitArray1)
            {
                Console.WriteLine(bit);
            }

            //Console.WriteLine();
            //Console.WriteLine(bitArray1.GetHashCode());

            BitArray64 bitArray2 = new BitArray64(5);

            //Console.WriteLine(bitArray2.GetHashCode());
            //Console.WriteLine();

            Console.WriteLine("Are bitArray1 equal with bitArray2: {0}", bitArray1 == bitArray2);
        }
    }
}
