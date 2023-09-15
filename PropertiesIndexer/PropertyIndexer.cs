using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesIndexer
{
    internal class PropertyIndexer
    {
        static void Main(string[] args)
        {

            Console.WriteLine(true);

            // System is namespace
            // Console is class
            // writeline is method
            // It may have parameter or with out paramet 

            #region basicProperty
            Person person = new Person();
            person.Name = "Dhana";  // Set the value

            Console.WriteLine(person.Name);  // get the value
            Console.ReadKey();

            #endregion

            #region levelproperty
            Date date = new Date();
            date.Month = 100;

            Console.WriteLine(date.Month);
            Console.ReadKey();
            #endregion

            #region IndexerOverload
            StringDataStore strStore = new StringDataStore();

            strStore[0] = "One";
            strStore[1] = "Two";
            strStore[2] = "Three";
            strStore[3] = "Four";

            Console.WriteLine(strStore[0]);
            Console.WriteLine(strStore["two"]);
            Console.WriteLine(strStore["Three"]);
            Console.WriteLine(strStore["Four"]);
            Console.ReadKey();

            #endregion
        }
    }

   

    #region basicProperty
    /* 
     Before we start to explain properties, you should have a basic understanding of "Encapsulation".

The meaning of Encapsulation, is to make sure that "sensitive" data is hidden from users. To achieve this, you must:

declare fields/variables as private
provide public get and set methods, through properties, to access and update the value of a private field
     */
    class Person
    {
        private string name; // field

        public string Name   // property
        {
            get { return this.name; }   // get method

            set { this.name = value; }  // set method
        }
    }

    #endregion

    #region levelproperty
    public class Date
    {
        private int _month = 7;  // Backing store

        public int Month   // property Accessor
        {
            get => _month;
            set
            {
                if ((value > 0) && (value < 13))
                {
                    _month = value;
                }
            }
        }
    }
    #endregion

    #region IndexerOverload
    /// <summary>
    /// access_modifier: It can be public, private, protected or internal.
    /// return_type: It can be any valid C# type.
    /// this: It is the keyword which points to the object of the current class.
    ///argument_list: This specifies the parameter list of the indexer.
    /// get { }and set { }: These are the accessors.
    /// </summary>

    class StringDataStore
    {
        private string[] strArr = new string[10]; // internal data storage

        // int type indexer
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= strArr.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                return strArr[index];
            }

            set
            {
                if (index < 0 || index >= strArr.Length)
                    throw new IndexOutOfRangeException("Index out of range");

                strArr[index] = value;
            }
        }

        // string type indexer
        public string this[string name]    // Read only
        {
            get
            {
                foreach (string str in strArr)
                {
                    if (str.ToLower() == name.ToLower())
                        return str;
                }

                return null;
            }
        }
    }

    #endregion

    #region Indexerses
    public class Indexerses
    {
        private int[] data = new int[10];

        // Indexer with multiple parameters
        public int this[int index, bool square]
        {
            get
            {
                if (square)
                    return data[index] * data[index];
                else
                    return data[index];
            }
            set
            {
                if (square)
                    data[index] = (int)Math.Sqrt(value);
                else
                    data[index] = value;
            }
        }

        // Overloaded indexer with string parameter
        public int this[string name]
        {
            
            get
            {
                switch (name.ToLower())
                {
                    case "first":
                        return data[0];
                    case "last":
                        return data[data.Length - 1];
                    default:
                        throw new ArgumentException("Invalid index parameter.");
                }
            }
        }

        // Read-only indexer
        public int this[int index]
        {
            get { return data[index]; }

        }
    }
    #endregion

}
