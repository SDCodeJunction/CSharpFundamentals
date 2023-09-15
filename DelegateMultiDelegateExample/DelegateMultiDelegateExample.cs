using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMultiDelegateExample
{
    //<Access Modifier> delegate <Return Type> <Delegate Name> (Parameter List);
    //In reality, a delegate is a blueprint for the method, which is going to dump the data into the event handler. 

    /*
       1) Declare a Delegate
       2) Instantiating a Delegate
       3) Invoking a Delegate

    Delegates are used to invoke the call-back functions.


    How many ways we can call a method in C#?
    =========================================

In C#, we can call a method that is defined in a class in two ways. They are as follows:

We can call the method using the object of the class if it is a non-static method or we can call the method through the class name if it is a static method.
We can also call a method in C# by using delegates. Calling a C# method using delegate will be faster in execution as compared to the first process i.e. either by using an object or by using the class name.
The example that we discussed in this article is of type Single Cast Delegate because the delegate points to a single function. In the next article, I am going to discuss the Multicast Delegate in C# with Examples. Here, in this article, I try to explain Delegates in C# with examples. I hope you understood the need and use of delegates in C#.


    Where do we use Delegates in C#?
    ================================
Delegates are used in the following cases:

Event Handlers
Callbacks
Passing Methods as Method Parameters
LINQ
Multithreading

    What are the Types of Delegates in C#?
    ======================================
The Delegates in C# are classified into two types as

Single Cast Delegate
Multicast Delegate

    Rules of using Delegates in C#:
    ===============================
A delegate in C# is a user-defined type and hence before invoking a method using a delegate, we must have to define that delegate first.
The signature of the delegate must match the signature of the method, the delegate points to otherwise we will get a compiler error. This is the reason why delegates are called type-safe function pointers
     */

    
    

    public delegate void CallbackMethodHandler(string message); // Declared method
    public delegate void WorkPerformedHandler(int hours, Books books); // declared delegate


    public delegate void DoSomeMethodHandler(string message);  // Declare

    class DelegateMultiDelegateExample
    {
        static void Main(string[] args)
        {
            
            #region delegate1

            WorkPerformedHandler del1 = new WorkPerformedHandler(Manager_WorkPerformed);
            del1(10, Books.Maths);
            del1.Invoke(50, Books.Science);
            Console.ReadKey();

            #endregion

            #region delegate2
            
            SomeClass obj = new SomeClass();

            DoSomeMethodHandler del2 = new DoSomeMethodHandler(obj.DoSomework); // object for delegate

            MethodInfo Method = del2.Method;
            object Target = del2.Target;
            Delegate[] InvocationList = del2.GetInvocationList();


            Console.WriteLine($"Method Property: {Method}");
            Console.WriteLine($"Target Property: {Target}");

            foreach (var item in InvocationList)
            {
                Console.WriteLine($"InvocationList: {item}");
            }

            Console.ReadKey();
            #endregion

            #region delegate3

            DelegateMultiDelegateExample delobj = new DelegateMultiDelegateExample();
            delobj.CallbackMethod2("test");


            CallbackMethodHandler del3 = new CallbackMethodHandler(delobj.CallbackMethod2);  // Instance
            del3 += new CallbackMethodHandler(delobj.CallbackMethod2);

            del3.Invoke("Test");

            //Here, I am calling the DoSomework function and I want the 
            //DoSomework function to call the delegate at some point of time
            //which will invoke the CallbackMethod method
            DoSomework(del3);
            Console.ReadKey();
            #endregion

        }
        public void CallbackMethod2(string message)
        {
            Console.WriteLine("CallbackMethod2 Executed");
            Console.WriteLine($"Hello: {message}, Good Morning");
        }


        #region 
        public static void Manager_WorkPerformed(int workHours, WorkType wType)
        {
            Console.WriteLine("Work Performed by Event Handler");
            Console.WriteLine($"Work Hours: {workHours}, Work Type: {wType}");
        }

        public static void DoSomework(CallbackMethodHandler del)
        {
            Console.WriteLine("Processing some Task");
            del("Employee1");
        }

        public static void Class1(Books class1books)
        {

        }
        #endregion
    }

    

    public enum Books
    {
        Maths = 0,
        Science = 1,
        Geography = 2

    }


    // Example 2:
    public class SomeClass
    {
        public void DoSomework(string message)
        {
            Console.WriteLine("DoSomework Executed");
            Console.WriteLine($"Hello: {message}, Good Morning");

        }
    }
}
