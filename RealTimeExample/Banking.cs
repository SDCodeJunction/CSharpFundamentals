using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeExample
{
    public class Banking
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Transaction doing SBI Bank");
            

            SBI sbi = new SBI();
            sbi.ValidateCard();
            sbi.WithdrawMoney();
            
            sbi.BankTransfer();
            sbi.MiniStatement();

            Console.WriteLine("\nTransaction doing AXIX Bank");
            AXIX AXIX = new AXIX();
            AXIX.ValidateCard();
            AXIX.WithdrawMoney();
            AXIX.CheckBalanace();
            AXIX.BankTransfer();
            AXIX.MiniStatement();
            Console.Read();

            SBI.CheckBalanace();
        }
    }

    public class SBI
    {
        public void BankTransfer()  // non static method
        {
            Console.WriteLine("SBI Bank Bank Transfer");
        }
        public static void CheckBalanace()
        {
            Console.WriteLine("SBI Bank Check Balanace");
        }
        public void MiniStatement()
        {
            Console.WriteLine("SBI Bank Mini Statement");
        }
        public void ValidateCard()
        {
            Console.WriteLine("SBI Bank Validate Card");
        }
        public void WithdrawMoney()
        {
            Console.WriteLine("SBI Bank Withdraw Money");
        }
    }
    public class AXIX
    {
        public void BankTransfer()
        {
            Console.WriteLine("AXIX Bank Bank Transfer");
        }
        public void CheckBalanace()
        {
            Console.WriteLine("AXIX Bank Check Balanace");
        }
        public void MiniStatement()
        {
            Console.WriteLine("AXIX Bank Mini Statement");
        }
        public void ValidateCard()
        {
            Console.WriteLine("AXIX Bank Validate Card");
        }
        public void WithdrawMoney()
        {
            Console.WriteLine("AXIX Bank Withdraw Money");
        }
    }

    public enum BankType
    {
        SBI,
        AXIX
    }
}
