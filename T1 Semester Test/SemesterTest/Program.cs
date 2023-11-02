// See https://aka.ms/new-console-template for more information
using SemesterTest;

///               Initialising number list         ///
List<int> nums = new List<int>(new int[] { 1, 2, 3, 4});

///  Initialising strategy type as MinMax and DataAnalyser object  ///
SummaryStrategy strategy = new MinMaxSummary();
DataAnalyser analyser = new DataAnalyser(nums, strategy);

/// Calling Summarise function with MinMax strategy ///
Console.WriteLine("MinMax Summary Strategy:");
analyser.Summarise();

/// Mannually adding additional numbers into the list ///
analyser.AddNumber(7);
analyser.AddNumber(9);
analyser.AddNumber(12);

/// Change strategy type from MinMax to Average  ///
strategy = new AverageSummary();
analyser = new DataAnalyser(nums, strategy);

/// Calling Summarise function with Average strategy ///
Console.WriteLine("Average Summary Strategy:");
analyser.Summarise();
