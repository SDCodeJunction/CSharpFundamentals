using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Sealed classes are used to restrict the inheritance 
 * Sealed Methods and Properties 
 * A sealed class is completely the opposite of an abstract class.
 * The sealed class cannot contain any abstract methods.
 * It should be the bottom-most class within the inheritance hierarchy.
 * A sealed class can never be used as a base class.
 * The sealed class is specially used to avoid further inheritance.
 * The keyword sealed can be used with classes, instance methods, and properties.
 * 
 */
namespace SealedClass
{
    public class Employee
    {
        protected int Eid, Eage;
        protected string Ename, Eaddress;
        public virtual void GetEmployeeData()
        {
            Console.WriteLine("Enter Emplpyee Details:");
            Console.Write("Enter Employee ID:");
            Eid = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee Name:");
            Ename = Console.ReadLine();
            Console.Write("Enter Employee Address:");
            Eaddress = Console.ReadLine();
            Console.Write("Enter Employee Age:");
            Eage = int.Parse(Console.ReadLine());
        }
        public virtual void DisplayEmployeeData()
        {
            Console.WriteLine("\nEmplpyee Details Are:");
            Console.WriteLine($"Employee ID: {Eid}");
            Console.WriteLine($"Employee Name: {Ename}");
            Console.WriteLine($"Employee Address: {Eaddress}");
            Console.WriteLine($"Employee Age: {Eage}");
        }
    }
    public sealed class Manager : Employee
    {
        double Bonus, Salary;
        public sealed override void GetEmployeeData()
        {
            Console.WriteLine("Enter Manager Details:");
            Console.Write("Enter Manager ID:");
            Eid = int.Parse(Console.ReadLine());
            Console.Write("Enter Manager Name:");
            Ename = Console.ReadLine();
            Console.Write("Enter Manager Salary:");
            Salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Manager Bonus:");
            Bonus = double.Parse(Console.ReadLine());
        }
        public override void DisplayEmployeeData()
        {
            Console.WriteLine("\nManager Details Are:");
            Console.WriteLine($"Manager ID: {Eid}");
            Console.WriteLine($"Manager Name: {Ename}");
            Console.WriteLine($"Manager Salary: {Salary}");
            Console.WriteLine($"Manager Bonus: {Bonus}");
        }

        public virtual void CEOMethod1()
        { }

    }

    public class CEO : Manager
    {
        public sealed override void CEOMethod1()
        {

        }
    }


    //Further No Inheritance is Possible as we marked the class as sealed
    //public class TempManager : Manager
    //{
    //}
    class Program
    {
        static void Main(string[] args)
        {
            CEO cEO   = new CEO();
            cEO.GetEmployeeData();

            Employee employee = new Employee();
            employee.GetEmployeeData();
            employee.DisplayEmployeeData();

            Manager m1 = new Manager();
            m1.GetEmployeeData();
            m1.DisplayEmployeeData();
            Console.ReadKey();

            Employee e1 = new Employee();
            e1.GetEmployeeData();
            e1.DisplayEmployeeData();
            Console.ReadKey();
        }
    }
}