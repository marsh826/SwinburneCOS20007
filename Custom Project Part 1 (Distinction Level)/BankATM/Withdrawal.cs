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
        private string _name;

        public Withdrawal(double balance, string type = "Withdrawal")
        {
            _balance = balance;
            _name = type;
        }

        protected double Balance
        {
            get { return _balance; }
        }

        protected string Name
        {
            get { return _name; }
        }

        public override string PrintTransaction()
        {
            string result = Balance.ToString();
            return $"Amount: {result}\n" +
                $"Transaction Type:{Name}";
        }
    }
}
