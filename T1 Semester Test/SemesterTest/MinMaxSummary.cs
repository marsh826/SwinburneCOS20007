using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTest
{
    public class MinMaxSummary : SummaryStrategy
    {
        /// <summary>
        /// Algorithm that caluclate the lowest value in List<int>numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private int Minimum(List<int> numbers)
        {
            int lowest = numbers[0];
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < lowest) 
                    lowest = numbers[i];
            }
            return lowest;
        }

        /// <summary>
        /// Algorithm that caluclate the highest value in List<int>numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private int Maximum(List<int> numbers)
        {
            int highest = numbers[0];
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > highest)
                    highest = numbers[i];
            }
            return highest;
        }

        /// <summary>
        /// Responsible for displaying the output in Program.cs
        /// </summary>
        /// <param name="numbers"></param>
        public void PrintMinMax(List<int> numbers)
        {
            int max = Maximum(numbers);
            int min = Minimum(numbers);

            Console.WriteLine($"The highest value in the list is: {max}");
            Console.WriteLine($"The lowest value in the list is: {min}");
        }

        /// <summary>
        /// Called from DataAnalyser class through the abstract class SummaryStrategy
        /// </summary>
        /// <param name="numbers"></param>
        public override void PrintSummary(List<int> numbers)
        {
            PrintMinMax(numbers);
        }
    }
}
