using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Namespace
// Nested Namespace

#region NestedNamespace

namespace India
{

    namespace Tamilnadu
    {
        class Chennai
        {
        }
    }
    class Kochi
    {
        Tamilnadu.Chennai chennai; // Legal; Chennai means Tamilnadu.Chennai when inside India
    }
}

namespace NewIndia
{
    using India;
    class NewChennai
    {
        // Illegal; merely using India does not bring Tamilnadu into scope
        India.Tamilnadu.Chennai chennai;
    }
}
#endregion

#region Using Alias directives

namespace SmartIndia
{
    using SmartIndiaUsingKeyword = India.Tamilnadu;

    class SmartCity : SmartIndiaUsingKeyword.Chennai { }
}

#endregion

#region externalias
namespace N1.N2
{
    class B
    {
        public void N1N2BMethod()
        {
            Console.WriteLine("N1N2BMethod");
        }
    }
}

namespace N3
{
    class A { }
    class B : A { }
}

namespace N3
{
    using A = N1.N2;
    using B = N1.N2.B;

    //class W : B { } // Error: B is ambiguous
    //class X : A.B { } // Error: A is ambiguous
    class Y : A::B { } // Ok: uses N1.N2.B
    class Z : N3.B { } // Ok: uses N3.B
}
#endregion 

#region Ambiguous Type name

namespace N1
{
    class A
    {
    }
}
class C
{
    public static int A;
}

namespace N2
{
    using N1;
    using static C;

    class B
    {
        void M()
        {
            A a = new A();   // Ok, A is unambiguous as a type-name
            
            C.A = 2;

            C.A.Equals(2);
            
            //A.Equals(2);     // Error, A is ambiguous as a simple-name
        }
    }
}
#endregion


