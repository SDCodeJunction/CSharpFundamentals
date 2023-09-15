using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExample
{

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassName { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Example : C# - SortedList<TKey, TValue>
            //  Example: SortedList Elements Default Sorting Order
            SortedList<int, string> numberNames = new SortedList<int, string>()
                                    {
                                        {3, "Three"},
                                        {5, "Five"},
                                        {1, "One"}
                                    };

            Console.WriteLine("---Initial key-values--");

            foreach (KeyValuePair<int, string> kvp in numberNames)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);

            numberNames.Add(6, "Six");
            numberNames.Add(2, "Two");
            numberNames.Add(4, "Four");

            Console.WriteLine("---After adding new key-values--");

            foreach (var kvp in numberNames)
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);





            // Example: LINQ Query on List
            var students = new List<Student>() {
                new Student(){ Id = 1, Name="Bill", ClassName = 10},
                new Student(){ Id = 2, Name="Steve",  ClassName = 10},
                new Student(){ Id = 3, Name="Ram",  ClassName = 10},
                new Student(){ Id = 4, Name="Abdul",  ClassName = 10}
            };

            DataSet dataSet = new DataSet();



            //get all students whose name is Bill
            var result = from s in students
                         where s.Name == "Bill"
                         select s;

            var billname = students.Where(num => num.Id == 1 && num.Name == "Bill");





            foreach (var student in result)
                Console.WriteLine(student.Id + ", " + student.Name);




            List<int> numbers = new List<int>() { 1, 2, 5, 7, 8, 10 };
            Console.WriteLine(numbers[0]); // prints 1
            Console.WriteLine(numbers[1]); // prints 2
            Console.WriteLine(numbers[2]); // prints 5
            Console.WriteLine(numbers[3]); // prints 7

            int val = 10;
            val = val.extmethod(11);

            // using foreach LINQ method
            numbers.ForEach(num => Console.WriteLine(num + ", "));//prints 1, 2, 5, 7, 8, 10,'

            var filterval = numbers.Where(num => num == 2);


            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

            // using for loop
            for (int i = 0; i < numbers.Count; i++)
                Console.WriteLine(numbers[i]);






            List<int> primeNumbers = new List<int>();
            primeNumbers.Add(1); // adding elements using add() method
            primeNumbers.Add(3);
            primeNumbers.Add(5);
            primeNumbers.Add(7);

            foreach (var item in primeNumbers)
            {
                Console.WriteLine(item);
            }

            var cities = new List<string>();

            cities.Add("New York");
            cities.Add("London");
            cities.Add("Mumbai");
            cities.Add("Chicago");
            cities.Add(null);// nulls are allowed for reference type list

            //adding elements using collection-initializer syntax
            var bigCities = new List<string>()
                    {
                        "New York",
                        "London",
                        "Mumbai",
                        "Chicago"
                    };


        }



    }

    public static class ExtensionMethodExample
    {
        public static int extmethod(this int i, int val)
        {
            return val + i;
        }
    }
}
