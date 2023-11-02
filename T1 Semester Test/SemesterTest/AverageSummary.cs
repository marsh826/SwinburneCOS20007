using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTest
{
    public class AverageSummary : SummaryStrategy
    {
        /// <summary>
        /// Algorithm that caluclate the average value in List<int>numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private float Average(List<int> numbers)
        {
            float sum = 0;

            for(int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            return sum / numbers.Count;
        }

        /// <summary>
        /// Responsible for displaying output in Program.cs
        /// </summary>
        /// <param name="numbers"></param>
        public void PrintAverage(List<int> numbers)
        {
            float average = Average(numbers);
            Console.WriteLine($"The average value of the number list is: {average:.0#}");
        }

        /// <summary>
        /// Called from DataAnalyser class through the abstract class SummaryStrategy
        /// </summary>
        /// <param name="numbers"></param>
        public override void PrintSummary(List<int> numbers)
        {
            PrintAverage(numbers);
        }
    }
}
