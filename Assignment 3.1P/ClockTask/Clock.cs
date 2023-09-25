using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockTask
{
    public class Clock
    {
        private int _hourD1;
        private int _minuteD1;
        private int _secondD1;
        private int _hourD2;
        private int _minuteD2;
        private int _secondD2;
        private Counter[] digit1;
        private Counter[] digit2;

/*        public Clock(int h, int m, int s)
        {
            _hour = h;
            _minute = m;
            _second = s;
        }*/

        public Clock(Counter[] counts1, Counter[] counts2) 
        {
            /*            _hour = hour.Ticks;
                        _minute = minute.Ticks;
                        _second = second.Ticks;
                        counters = new Counter[] {hour, minute, second};*/
            //HH:MM:SS FORMAT

            //First Digit
            _hourD1 = counts1[0].Ticks;
            _minuteD1 = counts1[1].Ticks;
            _secondD1 = counts1[2].Ticks;
            digit1 = counts1;

            //Second Digit
            _hourD2 = counts2[0].Ticks;
            _minuteD2 = counts2[1].Ticks;
            _secondD2 = counts2[2].Ticks;
            digit2 = counts2;

        }

        public void ClockStart()
        {
            //Clock begin at 00:00:00
            //while loop in the main program,

            //Seconds Digit2 increment
            digit2[2].Increment();
            _secondD2 = digit2[2].Ticks;

            //Seconds Digit1 increment
            if (_secondD2 > 9)
            {
                digit2[2].Reset();
                _secondD2 = digit2[2].Ticks;
                digit1[2].Increment();
                _secondD1 = digit1[2].Ticks;
            }

            //Minutes Digit2 increment
            if (_secondD1 == 6)
            {
                digit1[2].Reset();
                _secondD1 = digit1[2].Ticks;
                digit2[1].Increment();
                _minuteD2 = digit2[1].Ticks;
            }

            //Minutes Digit1 increment
            if (_minuteD2 > 9)
            {
                digit2[1].Reset();
                _minuteD2 = digit2[1].Ticks;
                digit1[1].Increment();
                _minuteD1 = digit1[1].Ticks;
            }

            //Hours Digit2 increment
            if (_minuteD1 == 6)
            {
                digit1[1].Reset();
                _minuteD1 = digit1[1].Ticks;
                digit2[0].Increment();
                _hourD2 = digit2[0].Ticks;
            }

            //Hours Digit1 increment
            if (_hourD2 > 9)
            {
                digit2[0].Reset();
                _hourD2 = digit2[0].Ticks;
                digit1[0].Increment();
                _hourD1 = digit1[0].Ticks;
            }

            //Clock reset 
            if (_hourD1 == 2 && _hourD2 == 4)
            {
                ClockReset();
            }
        }

        public string Time
        {
            get { return $"{_hourD1}{_hourD2}:{_minuteD1}{_minuteD2}:{_secondD1}{_secondD2}"; }
        }

        public void ClockReset()
        {
            for (int i = 0; i < 3; i++)
            {
                digit1[i].Reset();
                _hourD1 = digit1[0].Ticks;
                _minuteD1 = digit1[1].Ticks;
                _secondD1 = digit1[2].Ticks;

                digit2[i].Reset();
                _hourD2 = digit2[0].Ticks;
                _minuteD2 = digit2[1].Ticks;
                _secondD2 = digit2[2].Ticks;
            }
            
        }
    }
}
