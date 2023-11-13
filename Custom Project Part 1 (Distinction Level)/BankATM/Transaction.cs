using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankATM
{
    internal class Transaction
    {
        private Date _date;
        private string _type;
        private string _description;
        private double _amount;

        public Transaction(Date transactionDate, string type, string description, double amount)
        {
            _date = transactionDate;
            _type = type;
            _description = description;
            _amount = amount;
        }

        /// <summary>
        /// Money formatter (US currency)
        /// </summary>
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

        /// <summary>
        /// Create a collective list of details for one transaction
        /// </summary>
        /// <returns></returns>
        public string TransactionSummary()
        {
            return $"Transaction Type: {Type}\n" +
                $"Date: {Date.date}\n" +
                $"Time: {Date.time}\n" +
                $"Amount: {Amount.ToString("C", nfi)}\n" +
                $"Description: {Description}\n";
        }

        public string Type 
        { 
            get { return _type; } 
        }

        public Date Date 
        { 
            get { return _date; } 
        }

        public string Description
        {
            get { return _description; }
        }

        public double Amount
        {
            get { return _amount; }
        }
    }
}
