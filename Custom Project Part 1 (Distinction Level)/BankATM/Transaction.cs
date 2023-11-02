using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    internal class Transaction
    {
        private Date _transactionDate;
        private TransactionType _type;
        private string _description;

        public Transaction(Date transactionDate, TransactionType type, string description)
        {
            _transactionDate = transactionDate;
            _type = type;
            _description = description;
        }   

        public string TransactionSummary()
        {
            string joinedSummary = "";
            return _type.PrintTransaction();
        }

        public TransactionType TransactionType 
        { 
            get { return _type; } 
        }

        public Date TransactionDate 
        { 
            get { return _transactionDate; } 
        }

        public string TransactionDescription
        {
            get { return _description; }
        }
    }
}
