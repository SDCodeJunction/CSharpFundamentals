using System;
using System.Collections;
using System.Collections.Generic;

namespace array_example1
{
    class MyClass
    {

    }

    class Program
    {
        static void Main(string[] args)
        {

            ArrayList arlist1 = new ArrayList()
                {
                    100, 200, 600
                };

            ArrayList arlist2 = new ArrayList()
                {
                    500, 400, 300
                };
            arlist1.InsertRange(2, arlist2);

            foreach (var item in arlist1)
                Console.Write(item + ", "); //output: 100, 200, 300, 400, 500, 600, 


            #region


            //DataStoreConstraint<string> store = new DataStoreConstraint<string>(); // valid
            //DataStoreConstraint<MyClass> storemyclass = new DataStoreConstraint<MyClass>(); // valid

            //DataStoreConstraint<int> intstoremyclass = new DataStoreConstraint<int>(); // non valid


            //DataStore<string> strStore = new DataStore<string>();
            //strStore.Data = "Hello World!";
            ////strStore.Data = 123; // compile-time error

            //DataStore<int> intStore = new DataStore<int>();
            //intStore.Data = 100;
            ////intStore.Data = "Hello World!"; // compile-time error

            //KeyValuePair<int, string> kvp1 = new KeyValuePair<int, string>();
            //kvp1.Key = 100;
            //kvp1.Value = "Hundred";

            //KeyValuePair<string, string> kvp2 = new KeyValuePair<string, string>();
            //kvp2.Key = "IT";
            //kvp2.Value = "Information Technology";

            #endregion


            /*
                        C# Generic & Non-generic Collections

            C# includes specialized classes that store series of values or objects are called collections.

            There are two types of collections available in C#: non-generic collections and generic collections.

            The System.Collections namespace contains the non-generic collection types and System.Collections.Generic namespace includes generic collection types.


            //Generic Collections	Description 
List<T>	Generic List<T> contains elements of specified type. It grows automatically as you add elements in it.
Dictionary<TKey,TValue>	Dictionary<TKey,TValue> contains key-value pairs.
SortedList<TKey,TValue>	SortedList stores key and value pairs. It automatically adds the elements in ascending order of key by default.
Queue<T>	Queue<T> stores the values in FIFO style (First In First Out). It keeps the order in which the values were added. It provides an Enqueue() method to add values and a Dequeue() method to retrieve values from the collection.
Stack<T>	Stack<T> stores the values as LIFO (Last In First Out). It provides a Push() method to add a value and Pop() & Peek() methods to retrieve values.
Hashset<T>	Hashset<T> contains non-duplicate elements. It eliminates duplicate elements.

// Non-generic Collections
Non-generic Collections	Usage
ArrayList	ArrayList stores objects of any type like an array. However, there is no need to specify the size of the ArrayList like with an array as it grows automatically.
SortedList	SortedList stores key and value pairs. It automatically arranges elements in ascending order of key by default. C# includes both, generic and non-generic SortedList collection.


                        */


            // ArrayList
            ArrayList arrayList = new ArrayList()
            {
                2,
                "Bill2"
            };

            ArrayList arlist = new ArrayList()
                {
                    1,  //int
                    "Bill",  // string
                    300,
                    4.5f,  // Float
                    300,
                    arrayList
                };

            Console.WriteLine(arlist.Contains(300)); // true
            Console.WriteLine(arlist.Contains("Bill")); // true
            Console.WriteLine(arlist.Contains(10)); // false
            Console.WriteLine(arlist.Contains("Steve")); // false


            //Access individual item using indexer
            //int firstElement = (int)arlist[0]; //returns 1
            //string secondElement = (string)arlist[1]; //returns "Bill"
          //int secondElement = (int) arlist[1]; //Error: cannot cover string to int

            //using var keyword without explicit casting
            var firstElement = arlist[0]; //returns 1
            var secondElement = arlist[1]; //returns "Bill"
                                           //var fifthElement = arlist[5]; //Error: Index out of range

            //update elements
            arlist[0] = "Steve";
            arlist[1] = 100;
            //arlist[5] = 500; //Error: Index out of range


        }

        #region 
        class DataStore<T>   // Datestore TypeName   T Type parameter
        {
            public T Data { get; set; }
        }


        //Example: Generic Class with Multiple Type Parameters
        class KeyValuePair<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }


        //C# Generic Constraints
        class DataStoreConstraint<T>   // 
        {
            public T Data { get; set; }
        }

        #endregion



    }
}



