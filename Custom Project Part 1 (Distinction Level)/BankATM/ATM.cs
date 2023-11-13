using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BankATM
{
    /// <summary>
    /// Keep tracks of what account type is currently in used
    /// </summary>
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
        private Customer? _currentUser;
        private AccountType _accountType;

        public ATM(Bank bank, string location)
        {
            _location = location;
            _bank = bank;
            // CurrentUser and CurrentAccount are initialised with no values
            _currentUser = null;
            _currentAccount = null;
            // AccountType is set to None before and after user first login, until customer change account type
            _accountType = AccountType.None;
        }

        public bool ValidatePin(int pin)
        {
            // Look through each account in the bank for matching PIN
            foreach (var acc in _bank.Accounts)
            {
                if (pin == acc.PIN)
                {
                    // Assign current customer that is using the ATM
                    _currentUser= acc.Customer;
                    return true;
                }
            }  
            return false;
        }

        public void SelectAccountType(int type, string name)
        {
            string typeAcc;
            // Select account type for when the customer selects an option
            if (type == 1)
            {
                _accountType = AccountType.Spending;
            }

            if (type == 2)
            {
                _accountType = AccountType.Saving;
            }

            if(type != 1 || type != 2)
            {
                Console.WriteLine("Invalid Account Type\n");
            }

            typeAcc = _accountType.ToString();

            // Assign CurrentAccount with account that matches name and type
            foreach (var acc in _bank.Accounts)
            {
                if (acc.AccountType == typeAcc && acc.Customer.Name == name)
                {
                    CurrentAccount = acc;
                }
            }

            Console.Clear();

            //Display AccountID and which account type is selected
            Console.WriteLine($"Account: {CurrentAccount.AccountID}\n" +
                $"Type: {typeAcc}\n");
        }

        /// <summary>
        /// Money formatter (US currency)
        /// </summary>
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

        /// <summary>
        /// Uses a switch to process the customer's selection from ATM's options that has different functions
        /// </summary>
        /// <param name="command"></param>
        /// <param name="account"></param>
        public void OptionProcessing(string command, Account account)
        {
            double amount;
            string desc;

            ///// Processing the "command" parameter, based on the selection the user
            ///// made in the UI from Program.cs
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
                        Console.WriteLine("Important Note: Please use ',' for decimals [Example: 250,50]");
                        Console.Write("How much would you like to withdraw?: ");
                        amount = double.Parse(Console.ReadLine());
                        Console.Write("Description: ");
                        desc = Console.ReadLine();
                        if (CurrentAccount.BalanceCheck(amount))
                        {
                            CurrentAccount.Withdraw(amount, desc);
                        }
                        else
                        {
                            Console.WriteLine("\nWarning: Insufficient fund\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Account not found\n");
                    }
                    break;

                case "Deposit":
                    if (_bank.AccountExist(account.AccountID)) {
                        Console.WriteLine("Important Note: Please use ',' for decimals [Example: 250,50]");
                        Console.Write("How much would you like to deposit?: ");
                        amount = double.Parse(Console.ReadLine());
                        Console.Write("Description: ");
                        desc = Console.ReadLine();
                        CurrentAccount.Deposit(amount, desc);
                        Console.WriteLine($"You have successfully deposited {amount.ToString("C", nfi)} into account {CurrentAccount.AccountID}\n");
                    }
                    else
                    {
                        Console.WriteLine("Account not found\n");
                    }
                    break;

                case "Transfer":
                    Console.Write("Who would you like to transfer to?: ");
                    string id = Console.ReadLine();

                    if (_bank.AccountExist(id))
                    {
                        Console.WriteLine("Important Note: Please use ',' for decimals [Example: 250,50]");
                        Console.Write("Enter amount: ");
                        amount = double.Parse(Console.ReadLine());
                        if (CurrentAccount.BalanceCheck(amount))
                        {
                            CurrentAccount.Transfer(amount, desc: $"Transfer to {id}", id);
                            foreach(var acc in _bank.Accounts)
                            {
                                if(acc.AccountID == id)
                                {
                                    acc.Deposit(amount, desc: $"Transfer from {CurrentAccount.AccountID}");
                                    Console.WriteLine($"{amount.ToString("C", nfi)} has been successfully transferred to {id}\n");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nWarning: Insufficient fund\n");
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
                        Console.WriteLine("Error: Account not found\n");
                    }
                    break;

                case "Check Personal Info":
                    Console.WriteLine(CurrentUser.CheckInfo()+ "\n");
                    break;

                case "Update Personal Info":
                    Console.WriteLine("Note: Type 'Cancel' to abort ongoing operation.");

                    // After each input field, there is an if statement to check if 
                    // the user has decided to cancel this operation by typing 'Cancel',
                    // which are checked with case insensitive

                    Console.Write("Update First Name:");
                    string newFirstName = Console.ReadLine();
                    if (String.Equals(newFirstName, "Cancel", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine();
                        break;
                    }
                    else 
                    {
                        char[] chars = newFirstName.ToCharArray();
                        for (int i = 0; i < chars.Length; i++)
                        {
                            if (chars[i] >= 'a' && chars[i] <= 'z' || chars[i] >= 'A' && chars[i] <= 'Z')
                            {
                                i++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect Name format");
                                break;
                            }
                        }
                    }

                    Console.Write("Update Last Name:");
                    string newLastName = Console.ReadLine();
                    if (String.Equals(newLastName, "Cancel", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        char[] chars = newLastName.ToCharArray();
                        for (int i = 0; i < chars.Length; i++)
                        {
                            if (chars[i] >= 'a' && chars[i] <= 'z' || chars[i] >= 'A' && chars[i] <= 'Z')
                            {
                                i++;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect Name format");
                                break;
                            }
                        }
                    }

                    Console.Write("Update Phone:");
                    string newPhone = Console.ReadLine();
                    if (String.Equals(newPhone, "Cancel", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < newPhone.ToCharArray().Length; i++)
                        {
                            if (newPhone[i] <= '9' || newPhone[i] >= '0' && newPhone.ToCharArray().Length == 11 && newPhone[0] == '0')
                            {
                                Console.WriteLine($"Phone: {newPhone}");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect Phone format");
                                break;
                            }
                        }
                    }

                    Console.Write("Update Email:");
                    string newEmail = Console.ReadLine();
                    if (String.Equals(newEmail, "Cancel", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

                        if (Regex.IsMatch(newEmail, regex))
                        {
                            Console.WriteLine($"Email: {newEmail}");
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Email format");
                            break;
                        }
                    }

                    Console.Write("Update Address:");
                    string newAddress = Console.ReadLine();
                    if (String.Equals(newAddress, "Cancel", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine();
                        break;
                    }
                    else
                    {

                        for (int i = 0; i < newAddress.ToCharArray().Length; i++)
                        {
                            int countNum = 0;
                            if (newAddress[i] <= '9' && newAddress[i] >= '0')
                            {
                                countNum++;
                                i++;
                                
                                if(countNum >= 10)
                                {
                                    Console.WriteLine("Incorrect Address format");
                                    break;
                                }
                            }
                        }
                    }

                    string newName = $"{newFirstName} {newLastName}";

                    if (newName != null && newPhone != null && newEmail != null && newAddress != null)
                    {
                        CurrentUser.UpdateInfo(newName, newPhone, newEmail, newAddress);
                        Console.Clear();
                        Console.WriteLine("Personal Info Updated\n");
                    }
                    else
                    {
                        Console.WriteLine("Personal Info Not Updated\n");
                    }

                    break;
            }
        }

        public string DetailsATM
        {
            get 
            { 
                return $"Location: {_location}\n" +
                    $"Owned by Bank: {_bank.BankName}\n"; 
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
