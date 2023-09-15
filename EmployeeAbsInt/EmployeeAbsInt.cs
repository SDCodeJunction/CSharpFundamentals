using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAbsInt
{
    public abstract class Employee
    {
        public string Name { get; set; }   // non abstract property
        public abstract string EmployeeId { get; }  // abstract property

        public abstract double Salary();    // abstract method
        public double MedicalCoverage()   // non abstract method
        {
            return 300000;
        }
        public Employee(string Name)   // constructor
        {
            this.Name = Name;
        }
        public override string ToString()  // Overriding inbuit MS method
        {
            return $"Name={Name} ,Id={EmployeeId},Salary={Salary()},Medical Allowance={MedicalCoverage()}";
        }
    }
    public class PermanentEmployee : Employee
    {
        private string Id;
        public double MonthlySalary { get; }
        public override string EmployeeId { get { return Id; } }
        //override to provide Monthly Salary
        public override double Salary()
        {
            return MonthlySalary;
        }
        public PermanentEmployee(string Id, string Name, double MonthlySalary) : base(Name)
        {
            this.MonthlySalary = MonthlySalary;
            this.Id = Id;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class ContractEmployee : Employee
    {
        private string Id;
        public double HourlyPay { get; }
        public override string EmployeeId { get { return "T" + Id; } }
        public override double Salary()
        {
            return HourlyPay * 10;
        }
        public ContractEmployee(string Id, string Name, double HourlyPay) : base(Name)
        {
            this.HourlyPay = HourlyPay;
            this.Id = Id;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    class Company
    {
        public static void Main(string[] args)
        {
            Employee emp1 = new PermanentEmployee("267543", "Tom", 5000);
            Employee emp2 = new ContractEmployee("953456", "Ketty", 30);
            Console.WriteLine(emp1);
            Console.WriteLine(emp2);
            Console.ReadKey();
        }
    }
}
