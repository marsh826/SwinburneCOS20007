using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    internal class Deposit : TransactionType
    {
        private double _balance;

        public Deposit(double balance)
        {
            _balance = balance;
        }

        public double Balance
        {
            get { return _balance; }
        }

        public override string PrintTransaction()
        {
            string result = Balance.ToString();
            return $"Amount: {result}";
        }
    }
}
