using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankATM
{
    internal class Date
    {
        private DateOnly _date;
        private TimeOnly _time;

        public Date(DateTime dateTime)
        {
            //Divide DateTime object into two seperate data: date and time 
            _date = DateOnly.FromDateTime(dateTime);
            _time = TimeOnly.FromDateTime(dateTime);
        }
    

        public string date
        {
            get { return _date.ToString(); }
        }

        public string time 
        { 
            get { return _time.ToString(); } 
        }
    }
}
