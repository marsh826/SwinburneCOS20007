using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    internal class Customer
    {
        private string _name;
        private string _phone;
        private string _email;
        private string _address;
        public Customer(string name, string phone, string email, string address)
        {
            _name = name;
            _phone = phone;
            _email = email;
            _address = address;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Phone
        {
            get { return _phone; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string Address
        {
            get { return _address; }
        }

        public string CheckInfo()
        {
            string result = $"Name: {Name}\n" +
                $"Phone Number: {Phone}\n" +
                $"Email: {Email}\n" +
                $"Address: {Address}\n";

            return result;
        }

        public void UpdateInfo(string newName, string newPhone, string newEmail, string newAddress)
        {
            _name = newName; 
            _phone = newPhone; 
            _email = newEmail; 
            _address = newAddress;
        }
    }
}
