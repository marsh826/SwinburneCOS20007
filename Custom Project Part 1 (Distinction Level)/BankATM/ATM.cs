using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    enum AccountType
    {
        Saving,
        Spending,
        None
    }

    internal class ATM
    {
        private string _location;
        private Bank _bank;
        private Account? _currentAccount;
        private Customer _currentUser;
        private AccountType _accountType;

        public ATM(Bank bank, string location)
        {
            _location = location;
            _bank = bank;
            ///CurrentUser and CurrentAccount are initialised with no values
            _currentUser = null;
            _currentAccount = null;
            ///AccountType is set to None before and after user first login, until customer change account type
            _accountType = AccountType.None;
        }

        public bool ValidatePin(int pin)
        {
            ///Look through each account in the bank for matching PIN
            foreach (var acc in _bank.Accounts)
            {
                if (pin == acc.PIN)
                {
                    ///Assign current customer that is using the ATM
                    _currentUser= acc.Customer;
                    return true;
                }
            }  
            return false;
        }

        public void SelectAccountType(string type, string name)
        {
            //Select account type for when the customer selects an option
            if (type == "Spending")
            {
                _accountType = AccountType.Spending;
            }

            if (type == "Saving")
            {
                _accountType = AccountType.Saving;
            }

            //Assign CurrentAccount with account that matches name and type
            foreach (var acc in _bank.Accounts)
            {
                if (acc.AccountType == type && acc.Customer.Name == name)
                {
                    CurrentAccount = acc;
                }
            }
        }

        /// <summary>
        /// Uses a switch to process the customer's selection from ATM's options that has different functions
        /// </summary>
        /// <param name="command"></param>
        /// <param name="account"></param>
        public void OptionProcessing(string command, Account account)
        {
            double amount;
            string desc;

            switch (command)
            {
                case "View Transactions":
                    Console.Clear();
                    Console.Write($"Transaction History of Account: {CurrentAccount.AccountID}\n");
                    Console.WriteLine(CurrentAccount.PrintTransaction());
                    break;

                case "Withdraw":
                    if (_bank.AccountExist(account.AccountID))
                    {
                        Console.Write("How much would you like to withdraw?: ");
                        amount = Double.Parse(Console.ReadLine());
                        Console.Write("Description: ");
                        desc = Console.ReadLine();
                        CurrentAccount.Withdraw(amount, desc);
                    }
                    else
                    {
                        Console.WriteLine("Error: Account not found");
                    }
                    break;

                case "Deposit":
                    if (_bank.AccountExist(account.AccountID)) {
                        Console.Write("How much would you like to deposit?: ");
                        amount = Double.Parse(Console.ReadLine());
                        Console.Write("Description: ");
                        desc = Console.ReadLine();
                        CurrentAccount.Deposit(amount, desc);
                    }
                    else
                    {
                        Console.WriteLine("Error: Account not found");
                    }
                    break;

                case "Transfer":
                    Console.Write("Who would you like to transfer to?: ");
                    string id = Console.ReadLine();

                    if (_bank.AccountExist(id))
                    {
                        Console.Write("Enter amount: ");
                        amount = Double.Parse(Console.ReadLine());
                        if (CurrentAccount.BalanceCheck(amount))
                        {
                            CurrentAccount.Transfer(amount, desc: $"Transfer to {id}", id);
                            foreach(var acc in _bank.Accounts)
                            {
                                if(acc.AccountID == id)
                                {
                                    acc.Deposit(amount, desc: $"Transfer from {CurrentAccount.AccountID}");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Insufficient fund\n");

                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nCannot find Account ID: {id} in the system.\n");
                    }
                    break;

                case "View Account Details":
                    if(_bank.AccountExist(account.AccountID))
                    {
                        Console.WriteLine(CurrentAccount.AccountDetails);
                    }
                    else
                    {
                        Console.WriteLine("Error: Account not found");
                    }
                    break;

                case "Check Personal Info":
                    Console.WriteLine(CurrentUser.CheckInfo()+ "\n");
                    break;

                case "Update Personal Info":
                    Console.WriteLine("Update Name:");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Update Phone:");
                    string newPhone = Console.ReadLine();
                    Console.WriteLine("Update Email:");
                    string newEmail = Console.ReadLine();
                    Console.WriteLine("Update Address:");
                    string newAddress = Console.ReadLine();
                    CurrentUser.UpdateInfo(newName, newPhone, newEmail, newAddress);
                    break;
            }
        }

        public string DetailsATM
        {
            get 
            { 
                return $"Location: {_location}\n" +
                    $"Owned by Bank: {_bank.BankName}"; 
            }
        }

  
        public Account CurrentAccount
        {
            get { return _currentAccount; }
            set { _currentAccount = value; }
        }

        public Customer CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public AccountType AccountType 
        { 
            get { return _accountType; } 
            set { _accountType = value; } 
        }
    }
}
