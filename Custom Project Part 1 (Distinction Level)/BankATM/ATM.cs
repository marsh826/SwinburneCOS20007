using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    internal class ATM : Bank
    {
        private string _location;

        public ATM(string name, string location) : base(name)
        {
            _location = location;
        }

        public bool ValidatePin(int pin)
        {
            return false;
        }

        public void OptionProcessing()
        {

        }

        public string Location
        {
            get { return _location; }
        }
    }
}
