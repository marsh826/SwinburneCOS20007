using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankATM
{
    internal abstract class Account : IBalance
    {
        private string _id;
        private Customer _customer;
        private string _typeAccount;

        private int _pin;

        public Account(string id, Customer customer, int pin)
        {
            _id = id;
            _customer = customer;
            _pin = pin;
            _typeAccount = "";
        }

        public string AccountID
        {
            get { return _id; }
        }

        public Customer Customer 
        { 
            get { return _customer; } 
        }

        public int PIN 
        {
            get { return _pin; }
        }

        public virtual string AccountDetails
        {
            get { return "Details of an Account"; }
        }

        public virtual string AccountType
        {
            get { return _typeAccount; }
        }

        public abstract string PrintTransaction();

        public abstract bool BalanceCheck(double amount);

        public abstract void Deposit(double amount, string desc);

        public abstract void Withdraw(double amount, string desc);

        public abstract void Transfer(double amount, string desc, string id);
    }
}
