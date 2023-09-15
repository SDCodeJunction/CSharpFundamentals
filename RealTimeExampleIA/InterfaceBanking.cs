using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeExampleIA
{
    public class BankingIA
    {
        static void Main(string[] args)
        {


            try
            {
                try
                {
                    Console.WriteLine("Transaction doing SBI Bank");

                    Console.WriteLine("Plesae enter your SBI password to proceed further");
                    string SBIpwd = Console.ReadLine();

                    IBank sbi = BankFactory.GetBankObject("SBI", SBIpwd);
                    sbi.ValidateCard();
                    sbi.WithdrawMoney();
                    sbi.CheckBalanace();
                    sbi.BankTransfer();
                    sbi.MiniStatement();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Exception value : " + ex.Message);
                    Console.WriteLine("Bad SBI credential. Please check your password!");
                }

                try
                {
                    // code clean & compact loosely compled
                    Console.WriteLine("\nTransaction doing AXIX Bank");

                    Console.WriteLine("Plesae enter your AXIX password to proceed further");
                    string AXIXpwd = Console.ReadLine();
                    IBank AXIX = BankFactory.GetBankObject("AXIX", AXIXpwd);
                    AXIX.ValidateCard();
                    AXIX.WithdrawMoney();
                    AXIX.CheckBalanace();
                    AXIX.BankTransfer();
                    AXIX.MiniStatement();
                    Console.Read();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Bad AXIX credential. Please check your password!");
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Exception value : " + ex.Message);
                Console.WriteLine("Bad credential. Please check your password!");
            }
        }
    }
    public interface IBank
    {
        void ValidateCard();
        void WithdrawMoney();
        void CheckBalanace();
        void BankTransfer();
        void MiniStatement();
    }

    // Syntax Error
    // Runtime Error - 
    // Logical Error - 
    public class BankFactory
    {
        public static IBank GetBankObject(string bankType, string pwd)
        {
            IBank BankObject = null;
            if (bankType == "SBI" && pwd == "SBIPassword")
            {
                BankObject = new SBI();
            }
            else if (bankType == "AXIX" && pwd == "AXIXPassword")
            {
                BankObject = new AXIX();
            }
            return BankObject;
        }
    }
    public class SBI : IBank
    {
        public void BankTransfer()
        {
            Console.WriteLine("SBI Bank Bank Transfer");
        }
        public void CheckBalanace()
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
    public class AXIX : IBank
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
}
