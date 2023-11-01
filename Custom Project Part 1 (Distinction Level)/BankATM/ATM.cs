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
            foreach(var acc in Accounts)
            {
                if (pin == acc.PIN)
                {
                    return true;
                }
            }
                        
            return false;
        }

        public void OptionProcessing(string command)
        {
            if(command == "login")
            {
                string input = Console.ReadLine();
                ValidatePin(Convert.ToInt32(input));
            }

            if (command == "view transaction") ;
        }

        public string Location
        {
            get { return _location; }
        }
    }
}
