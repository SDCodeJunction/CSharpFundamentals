
extern alias X;
extern alias Y;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    using System;

    class Program
    {
        static void Main()
        {
            X.A._b = 1;
            Y.A._b = 2;

            Console.WriteLine(X.A._b);
            Console.WriteLine(Y.A._b);
        }
    }
}
