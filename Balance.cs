using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class Balance
    {
        private long _current_balance = 0;

        public long CurrentBalance
        {
            get
            {
                return _current_balance;
            }
            private set
            {
                _current_balance += value;
            }
        }
        public void Deposit()
        {
            Console.Clear();
            var end = false;
            while(!end)
            {
                try
                {
                    Console.Write("\nEnter deposit amount : ");
                    long deposit_amt = long.Parse(Console.ReadLine());
                    if(deposit_amt <= 0)
                    {
                        throw new Exception("\nAmount cannot be zero or negative\n");
                    }
                    CurrentBalance = deposit_amt;
                    Console.WriteLine("\t\t\t\tYour amount has been successfully deposited");
                    end = true;
                    viewBalance();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message + "\nEnter a valid amount\n");
                }
            }
           
        }
        public void Withdraw()
        {
            Console.Clear();
            var end = false;
            while (!end)
            {
                try
                {
                    if(CurrentBalance == 0)
                    {
                        Console.WriteLine("Current Balance is 0\n");
                        break;
                    }
                    viewBalance();
                    Console.Write("\nEnter withdrawal amount : ");
                    long withdraw_amt = long.Parse(Console.ReadLine());
                    if (withdraw_amt > CurrentBalance)
                    {
                        throw new Exception("Amount greater than existing balance");
                    }
                    if (withdraw_amt <= 0)
                    {
                        throw new Exception("\nAmount cannot be zero or negative\n");
                    }
                    CurrentBalance = -withdraw_amt;
                    Console.WriteLine("\t\t\t\tYour amount has been successfully withdrawed");
                    end = true;
                    viewBalance();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\nEnter a valid amount\n");
                }
            }

        }
        public void viewBalance()
        {
            Console.WriteLine($"\t\t\t\tYour current balance is : {CurrentBalance}");
        }

        public void CalculateInterest()
        {
            Console.Clear();
            var end = false;
            while (!end)
            {
                try
                {
                    if (CurrentBalance == 0)
                    {
                        Console.WriteLine("Current Balance is 0\n");
                        break;
                    }
                    Console.Write("\t\t\t\tEnter number of months : ");
                    int months = int.Parse(Console.ReadLine());
                    long interest = (long)(CurrentBalance * 10 * months / 12) / 100;
                    Console.WriteLine($"\nInterest amount: {interest}\nYour current balance will amount to : {CurrentBalance + interest}\n");
                    end = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
