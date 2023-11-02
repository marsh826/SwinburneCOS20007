using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTest
{
    public class DataAnalyser
    {
        private List<int> _numbers;
        private SummaryStrategy _strategy;

        public DataAnalyser() : this(new List<int>(), new AverageSummary())
        {
            
        }
        public DataAnalyser(List<int> numbers, SummaryStrategy strategy)
        {
            _numbers = numbers;
            _strategy = strategy;
        }

        /// <summary>
        /// Allow user to mannually add any number into List<int> _numbers
        /// </summary>
        /// <param name="number"></param>
        public void AddNumber(int number)
        {
            _numbers.Add(number);
        }

        /// <summary>
        /// Global function used in Program.cs to access hidden functions 
        /// </summary>
        public void Summarise()
        {
            _strategy.PrintSummary(_numbers);
        }

        public SummaryStrategy Strategy 
        { 
            get { return _strategy; } 
        }
    }
}
