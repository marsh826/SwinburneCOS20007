using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    internal class ATM : Bank
    {
        private string _location;

        public ATM(string name, string location) : base(name)
        {
            _location = location;
        }

        public bool ValidatePin(int pin)
        {
            foreach(var acc in Accounts)
            {
                if (pin == acc.PIN)
                {
                    return true;
                }
            }
                        
            return false;
        }

        public void OptionProcessing(string command, Account account)
        {
            double amount;

            switch (command)
            {
                case "Login":
                    Console.Write("Enter you PIN number: ");
                    string input = Console.ReadLine();
                    if(ValidatePin(Convert.ToInt32(input)))
                    {
                        Console.WriteLine($"Welcome {account.Customer.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Authentication Failed: Wrong PIN");
                    }
                    break;

                case "View Transaction":
                    account.DisplayTransaction();
                    break;

                case "Withdrawal":
                    Console.Write("How much would you like to withdraw?: ");
                    amount = Convert.ToDouble(Console.ReadLine());
                    account.Withdrawl(amount);
                    break;

                case "Deposit":
                    Console.Write("How much would you like to deposit?: ");
                    amount = Convert.ToDouble(Console.ReadLine());
                    account.Deposit(amount);
                    break;

                case "Transfer":
                    Console.Write("Who would you like to transfer to?: ");
                    
                    Console.Write("Enter amount: ");
                    amount = Convert.ToDouble(Console.ReadLine());
                    account.Transfer(amount);
                    break;

                case "View Account Details":
                    Console.WriteLine(account.AccountDetails);
                    break;

                default:
                    Console.WriteLine("Please select your option from the list above");
                    break;
            }
        }

        public string Location
        {
            get { return _location; }
        }
    }
}
