using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    public interface IBalance
    {
        public bool BalanceCheck(double amount);
        public string PrintTransaction();
    }
}
