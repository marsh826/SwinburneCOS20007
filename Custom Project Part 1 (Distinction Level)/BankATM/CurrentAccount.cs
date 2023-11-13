using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankATM
{
    internal class CurrentAccount : Account
    {
        private List<Transaction> _transactions;
        private double _balance;
        private string _typeAccount;

        public CurrentAccount(string id, Customer customer, int pin)
            : base(id, customer, pin)
        {
            _transactions = new List<Transaction>();
            // Balance starts at 0.00 when a new account is initialised
            _balance = 0.00;
            // CurrentAccount has AccountType registered as Spending
            _typeAccount = "Spending";
        }

        /// <summary>
        /// Return all transactions made from this account
        /// </summary>
        /// <returns></returns>
        public override string PrintTransaction()
        {
            List<string> list = new List<string>();

            foreach (Transaction transact in Transactions)
            {
                string item = transact.TransactionSummary();
                list.Add(item);
            }

            string[] array = list.ToArray();
            string result = string.Join("\n", array);
            list.Clear();

            if (result == "")
            {
                return "No transaction was ever recorded in this account.\n";
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Money formatter (US currency)
        /// </summary>
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

        /// <summary>
        /// Checking the account's balance before withdrawing or transfering money
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public override bool BalanceCheck(double amount)
        {
            if (amount <= Balance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Add an amount of money into the account's current balance
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="desc"></param>
        public override void Deposit(double amount, string desc)
        {
            _balance += amount;
            Console.Clear();
            Date currentDate = new Date(DateTime.Now);
            Transaction newDeposit = new Transaction(currentDate, "Deposit", desc, amount);
            Transactions.Add(newDeposit);
        }

        /// <summary>
        /// Substract an amount of money from the account's current balance
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="desc"></param>
        public override void Withdraw(double amount, string desc)
        {
            _balance -= amount;
            Console.Clear();
            Console.WriteLine($"you have successfully withdrawed {amount} from  account {AccountID}");
            Console.WriteLine($"New Account Balance: {Balance.ToString("C", nfi)}\n");
            Date currentDate = new Date(DateTime.Now);
            Transaction newWithdraw = new Transaction(currentDate, "Withdraw", desc, amount);
            Transactions.Add(newWithdraw);
        }

        /// <summary>
        /// Substract an amount from current balance and send it to another existing account 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="desc"></param>
        /// <param name="id"></param>
        public override void Transfer(double amount, string desc, string id)
        {
            _balance -= amount;
            Console.Clear();
            Console.WriteLine($"{amount.ToString("C", nfi)} transferred successfully to account {id}\n");
            Date newDate = new Date(DateTime.Now);
            Transaction newTransfer = new Transaction(newDate, "Transfer", desc, amount);
            Transactions.Add(newTransfer);
        }

        public override string AccountType
        {
            get { return _typeAccount; }
        }

        protected List<Transaction> Transactions
        {
            get { return _transactions; }
        }

        protected double Balance
        {
            get { return _balance; }
        }

        public override string AccountDetails
        {
            get
            {
                return $"Account Details:\n" +
                    $"AccountID: {AccountID}\n" +
                    $"Account Holder: {Customer.Name}\n" +
                    $"Account Type: {AccountType}\n" +
                    $"Balance: {Balance.ToString("C", nfi)}\n";
            }
        }
    }
}
