using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    internal class Bank
    {
        private string _bankName;
        private List<Account> _listAccount;

        public Bank(string name)
        {
            _bankName = name;
            _listAccount = new List<Account>();    
        }

        public void AddAccount(Account account)
        {
            _listAccount.Add(account);
        }

        public string BankName
        {
            get { return _bankName; }
        }

        protected List<Account> Accounts 
        { 
            get { return _listAccount; } 
        }
    }
}
