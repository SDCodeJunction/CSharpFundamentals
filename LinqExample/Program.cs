using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public int StandardID { get; set; }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region where
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", StudentAge = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  StudentAge = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  StudentAge = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , StudentAge = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , StudentAge = 13 }
            };
            var filteredResult = from s in studentList
                                 where s.StudentAge > 12 && s.StudentAge < 20
                                 select s.StudentName;
            #endregion

            #region  ofType

            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill" });

            var stringResult = from s in mixedList.OfType<string>()
                               select s;

            var intResult = from s in mixedList.OfType<int>()
                            select s;

            #endregion

            #region OrderBy
            var orderByResult = from s in studentList
                                orderby s.StudentName descending
                                select s;

            var studentsInDescOrder = studentList.OrderByDescending(s => s.StudentName);

            #endregion

            #region ThenBy

            var thenByDescResult = studentList.OrderBy(s => s.StudentName).ThenByDescending(s => s.StudentAge);

            #endregion

            #region GroupBy & ToLookup

            var groupedResult = from s in studentList
                                group s by s.StudentAge;

            //ToLookup is not supported in the query syntax.
            var lookupResult = studentList.ToLookup(s => s.StudentAge);
            #endregion

            #region Join operator C#
            IList<Student> newstudentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", StudentAge = 13, StandardID =1 },
                new Student() { StudentID = 2, StudentName = "Moin",  StudentAge = 21, StandardID =1 },
                new Student() { StudentID = 3, StudentName = "Bill",  StudentAge = 18, StandardID =2 },
                new Student() { StudentID = 4, StudentName = "Ram" , StudentAge = 20, StandardID =2 },
                new Student() { StudentID = 5, StudentName = "Ron" , StudentAge = 15 }
        };

            IList<Standard> standardList = new List<Standard>() {
                    new Standard(){ StandardID = 1, StandardName="Standard 1"},
                    new Standard(){ StandardID = 2, StandardName="Standard 2"},
                    new Standard(){ StandardID = 3, StandardName="Standard 3"}
                };

            var innerJoin = newstudentList.Join(// outer sequence 
                                  standardList,  // inner sequence 
                                  student => student.StandardID,    // outerKeySelector
                                  standard => standard.StandardID,  // innerKeySelector
                                  (student, standard) => new  // result selector
                                  {
                                      StudentName = student.StudentName,
                                      StandardName = standard.StandardName
                                  });
            #endregion

            #region GroupJoin

            var groupJoin = standardList.GroupJoin(newstudentList,  //inner sequence
                                std => std.StandardID, //outerKeySelector 
                                s => s.StandardID,     //innerKeySelector
                                (std, s) => new // resultSelector 
                                {
                                    Students = s,
                                    StandarFulldName = std.StandardName
                                });


            var groupJoinquery = from std in standardList
                                 join s in newstudentList
                                 on std.StandardID equals s.StandardID
                                 into studentGroup
                                 select new
                                 {
                                     Students = studentGroup,
                                     StandardName = std.StandardName
                                 };

            #endregion

            #region ElemeentAt & First , Last, Single & Sequence


            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { "One", "Two", null, "Four", "Five" };

            Console.WriteLine("1st Element in intList: {0}", intList.ElementAt(0));

            Console.WriteLine("1st Element in intList: {0}", intList.First());
            Console.WriteLine("1st Even Element in intList: {0}", intList.First(i => i % 2 == 0));

            Console.WriteLine("Last Element in intList: {0}", intList.Last());


            Console.WriteLine("The only element which is less than 10 in intList: {0}",
             intList.SingleOrDefault(i => i < 21));



            //bool isEqual = intList.SequenceEqual(strList); // returns false
            // Console.WriteLine(isEqual);


            #endregion


            #region Skip & Take

            IList<string> strListSkip = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var newListSkip = strListSkip.Skip(2);

            foreach (var str in newListSkip)
                Console.WriteLine(str);

            var resultListSkip = strListSkip.SkipWhile(s => s.Length < 4);


            var newListTake = strList.Take(2);

            foreach (var str in newListTake)
                Console.WriteLine(str);


            var result = strList.TakeWhile(s => s.Length > 4);

            #endregion


            #region nestedquery

            var nestedQueries = from s in studentList
                                where s.StudentAge > 18 && s.StandardID ==
                                    (from std in standardList
                                     where std.StandardName == "Standard 1"
                                     select std.StandardID).FirstOrDefault()
                                select s;

            nestedQueries.ToList().ForEach(s => Console.WriteLine(s.StudentName));
            #endregion

        }

    }
}
