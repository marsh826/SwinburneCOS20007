using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankATM
{
    internal class CurrentAccount : Account
    {
        private double _balance;
        private List<Transaction> _transactions;
        public CurrentAccount(string id, Customer customer, Bank bank, int pin, double balance, List<Transaction> transactions)
            : base(id, customer, bank, pin)
        {
            _balance = balance;
            _transactions = transactions;
        }
        public override void Deposit(double amount)
        {

        }

        public override void Transfer(double amount)
        {

        }

        public override void Withdrawl(double amount)
        {

        }

        public List<Transaction> Transactions
        {
            get { return _transactions; }
        }

        public double Balance
        {
            get { return _balance; }
        }
    }
}
