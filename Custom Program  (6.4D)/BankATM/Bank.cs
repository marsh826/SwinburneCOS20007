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

        public List<Account> Accounts
        {
            get { return _listAccount; }
        }

        public string BankName
        {
            get { return _bankName; }
        }

        /// <summary>
        /// Associate newly created account with Bank object
        /// </summary>
        /// <param name="account"></param>
        public void AddAccount(Account account)
        {
            _listAccount.Add(account);
        }

        /// <summary>
        /// Verify that account does exist with account id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AccountExist(string id)
        {
            foreach(Account acc in _listAccount)
            {
                if(id == acc.AccountID) return true;
            }
            return false;
        }
    }
}
