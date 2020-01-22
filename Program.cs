using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customerList = new List<Customer>();
            
            while (true)
            {
                Console.Clear();
                header();
                try
                {
                    Console.Write("\n1.New Customer\n2.Existing Customer\n3.Exit\n\t\t\t\tEnter your choice:");
                    int ch1 = int.Parse(Console.ReadLine());
                    switch (ch1)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Enter name: ");
                            var name = Console.ReadLine();
                            var customerObj = new Customer(name);
                            Console.WriteLine($"\t\t\t\tYour Customer ID is : {customerObj.Id}");
                            Console.WriteLine("Enter contact details : ");
                            customerObj.SetContactDetails();
                            customerObj.Deposit();
                            customerList.Add(customerObj);
                            Console.WriteLine("\t\t\t\tDetails Saved!\n\t\t\t\tThanks for creating an account with us!\n");
                            pressToContinue();
                            break;
                        case 2:
                            Console.Clear();
                            Console.Write("\n1.View User Details\n2.Deposit\n3.Withdraw\n4.Calculate Interest\n5.Edit Details\n6.Delete Account\n\t\t\t\tEnter your choice:");
                            int ch2 = int.Parse(Console.ReadLine());
                            Console.Clear();
                            Console.Write("Enter your customer ID: ");
                            int id = int.Parse(Console.ReadLine());

                            var customerDetail = customerList.Where(a => a.Id == id).ToList();
                            if(customerDetail.Count == 0 || customerDetail == null)
                            {
                                Console.WriteLine("\nCustomer not found\nInvalid Customer ID\n");
                                pressToContinue();
                                continue;
                            }
                            switch (ch2)
                            {
                                case 1:
                                        DisplayContactDetails(customerDetail[0]);
                                        pressToContinue();
                                        break;
                                case 2:
                                        customerDetail[0].Deposit();
                                        pressToContinue();
                                        break;

                                case 3:
                                        customerDetail[0].Withdraw();
                                        pressToContinue();
                                        break;
                                case 4:
                                        customerDetail[0].CalculateInterest();
                                        pressToContinue();
                                        break;
                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("\nCurrent Details are :-\n");
                                    DisplayContactDetails(customerDetail[0]);
                                    Console.WriteLine("\nEnter the details you want to change :-\n");
                                    customerDetail[0].EditContactDetails();
                                    Console.Clear();
                                    Console.WriteLine("\nChanges have been saved!\n");
                                    pressToContinue();
                                    break;
                                case 6:
                                    Console.WriteLine("\nAre you sure(y/n)?\nDeleting account will permanently remove all details!");
                                    char ch = char.Parse(Console.ReadLine());
                                    if (ch == 'y')
                                    {
                                        customerList.Remove(customerList[0]);
                                        Console.WriteLine("\nAccount has been deleted permanently");
                                        pressToContinue();
                                    }
                                    else
                                        continue;
                                    break;
                                default:
                                    Console.WriteLine("Enter a valid option\n");
                                    pressToContinue();
                                    break;
                            }
                            break;
                        case 3:
                            System.Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("Enter a valid choice\n");
                            break;
                    }
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                } 
            }
        }
        private static void DisplayContactDetails(Customer customer)
        {
            var contact = customer.GetContactDetails();
            Console.WriteLine($"Customer ID       : {customer.Id}");
            Console.WriteLine($"Customer Name     : {customer.Name}");
            Console.WriteLine($"Phone number      : {contact._phone_number}");
            Console.WriteLine($"Address           : {contact._address}");
            Console.WriteLine($"City              : {contact._city}");
            Console.WriteLine($"State             : {contact._state}");
            Console.WriteLine($"PIN               : {contact._pin}");
            Console.WriteLine($"Country           : {contact._country}\n");
            Console.WriteLine($"Balance           : {customer.CurrentBalance}\n\n");
        }
        public static void header()
        {
            Console.WriteLine("========================================================================================");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("****************************************************************************************");
            Console.WriteLine("--------------------------------  WELCOME TO SUREBANK!  --------------------------------");
            Console.WriteLine("****************************************************************************************");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("========================================================================================");
        }
        public static void pressToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
