using System;
using System.Collections.Generic;

namespace IEnumerable_extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> integers = new int[] { 12, 2, 3, 1111, 3, 2, 7, 8, 1 };
            var sum = integers.Sum();
            var product = integers.Product();
            var min = integers.Min();
            var max = integers.Max();
            var average = integers.Average();
            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine("Product: {0}", product);
            Console.WriteLine("Min: {0}", min);
            Console.WriteLine("Max: {0}", max);
            Console.WriteLine("Average: {0}", average);
        }
    }
}
