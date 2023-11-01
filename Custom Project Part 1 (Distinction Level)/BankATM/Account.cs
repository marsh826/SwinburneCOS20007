using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankATM
{
    internal abstract class Account
    {
        private string _id;
        private Customer _customer;
        private Bank _bank;
        private int _pin;

        public Account(string id, Customer customer, Bank bank, int pin)
        {
            _id = id;
            _customer = customer;
            _bank = bank;
            _pin = pin;
        }

        public string DisplayTransaction()
        {
            return "";
        }

        public abstract void Deposit(double amount);

        public abstract void Withdrawl(double amount);

        public abstract void Transfer(double amount);

        public string AccountID
        {
            get { return _id; }
        }

        public Bank Bank 
        { 
            get { return _bank; } 
        }

        public Customer Customer 
        { 
            get { return _customer; } 
        }

        public virtual string AccountDetails
        {
            get { return "Details of an Account"; }
        }

    }
}
