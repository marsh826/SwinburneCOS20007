using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    internal class Withdrawal : TransactionType
    {
        private double _balance;

        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public override string PrintTransaction(double amount)
        {
            Balance = amount;
        }
    }
}
