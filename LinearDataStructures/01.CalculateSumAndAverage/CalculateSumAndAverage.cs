using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearDataStructures
{
    /* Write a program that reads from the console a sequence of positive integer numbers.
     * The sequence ends when empty line is entered.
     * Calculate and print the sum and average of the elements of the sequence.
     * Keep the sequence in List<int>.
     */

    class CalculateSumAndAverage
    {
        static List<int> list = new List<int>();

        static void Main(string[] args)
        {
            string input = String.Empty;
            do
            {
                Console.Write("Enter positive integer: ");
                input = Console.ReadLine();
                try
                {
                    if (input != String.Empty)
                    {
                        uint integer = UInt32.Parse(input);
                        list.Add((int)integer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while(input != String.Empty);

            int sum = list.Sum();
            Console.WriteLine("Sum: {0}", sum);
            double average = list.Average();
            Console.WriteLine("Average: {0}", average);
        }
    }
}
