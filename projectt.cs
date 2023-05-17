using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prob
{
    internal class Program
    {
        static void Main(string[] args)
        {






                Console.WriteLine("Enter the number of items:");
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the values of the items:");
                int[] items = new int[n];
                for (int i = 0; i < n; i++)
                {
                    items[i] = int.Parse(Console.ReadLine());
                }

                Array.Sort(items);

                double median = GetMedian(items);
                Console.WriteLine($"Median: {median}");

                int mode = GetMode(items);
                Console.WriteLine($"Mode: {mode}");

                int range = GetRange(items);
                Console.WriteLine($"Range: {range}");

                double firstQuartile = GetQuartile(items, 0.25);
                Console.WriteLine($"First Quartile: {firstQuartile}");

                double thirdQuartile = GetQuartile(items, 0.75);
                Console.WriteLine($"Third Quartile: {thirdQuartile}");

                double p90 = GetPercentile(items, 0.9);
                Console.WriteLine($"P90: {p90}");

                double interquartileRange = thirdQuartile - firstQuartile;
                Console.WriteLine($"Interquartile Range: {interquartileRange}");

                double lowerBound = firstQuartile - 1.5 * interquartileRange;
                double upperBound = thirdQuartile + 1.5 * interquartileRange;
                Console.WriteLine($"Outlier Boundaries: [{lowerBound}, {upperBound}]");

                Console.WriteLine("Enter a value to check if it's an outlier:");
                int value = int.Parse(Console.ReadLine());
                bool isOutlier = IsOutlier(value, lowerBound, upperBound);
                Console.WriteLine($"Is {value} an outlier? {isOutlier}");
            }

            static double GetMedian(int[] items)
            {
                int n = items.Length;
                if (n % 2 == 0)
                {
                    return (items[n / 2 - 1] + items[n / 2]) / 2.0;
                }
                else
                {
                    return items[n / 2];
                }
            }

            static int GetMode(int[] items)
            {
                var groups = items.GroupBy(x => x);
                int maxCount = groups.Max(g => g.Count());
                return groups.First(g => g.Count() == maxCount).Key;
            }

            static int GetRange(int[] items)
            {
                return items.Max() - items.Min();
            }

            static double GetQuartile(int[] items, double percentile)
            {
                int n = items.Length;
                double index = percentile * (n - 1) + 1;
                if (index % 1 == 0)
                {
                    return items[(int)index - 1];
                }
                else
                {
                    int lowerIndex = (int)Math.Floor(index) - 1;
                    int upperIndex = (int)Math.Ceiling(index) - 1;
                    return (items[lowerIndex] + items[upperIndex]) / 2.0;
                }
            }

            static double GetPercentile(int[] items, double percentile)
            {
                int n = items.Length;
                double index = percentile * (n - 1) + 1;
                if (index % 1 == 0)
                {
                    return items[(int)index - 1];
                }
                else
                {
                    int lowerIndex = (int)Math.Floor(index) - 1;
                    int upperIndex = (int)Math.Ceiling(index) - 1;
                    return (items[lowerIndex] + items[upperIndex]) / 2.0;
                }
            }

        static bool IsOutlier(int value, double lowerBound, double upperBound)
        {
            return value < lowerBound || value > upperBound;

        
        Console.ReadKey();


            


        }
        
    }
}
