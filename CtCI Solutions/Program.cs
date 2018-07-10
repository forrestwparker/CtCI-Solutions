using CtCI_Solutions.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtCI_Solutions
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var rng = new Random();
            var n = rng.Next(1, 10000000);
            var remove = rng.Next(0, n + 1);
            var array = Enumerable.Range(0, n + 1).ToArray();
            array[remove] = 0;

            var maxBinaryDigit = (int)Math.Log(n, 2);

            var number = 0;
            if ((n ^ 1) == 0) {
                for (int digitPlace = 1; digitPlace <= maxBinaryDigit; digitPlace++)
                {
                    var PowerOf2 = 1 << digitPlace;
                    var nModP2plus1 = n % (PowerOf2 << 1);
                    if (nModP2plus1 >= PowerOf2)
                    {
                        number |= (1 << digitPlace);
                    }
                }
            }

            if (((n + 1) % 4) / 2 == 1)
            {
                number |= 1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                number ^= array[i];
            }

            Console.WriteLine("bound: {0}", n);
            Console.WriteLine("removed: {0}", remove);
            Console.WriteLine("number: {0}", number);
            */
        }
    }
}
