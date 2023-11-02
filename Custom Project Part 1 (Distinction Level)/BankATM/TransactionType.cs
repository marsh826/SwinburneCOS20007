using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    internal abstract class TransactionType
    {
        public abstract string PrintTransaction();
    }
}
