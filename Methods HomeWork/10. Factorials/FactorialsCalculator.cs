using _08.Adds_numbers_represented_as_array;
using System;

namespace _10.Factorials
{
    class FactorialsCalculator
    {
        static void Main(string[] args)
        {
            int[][] factorials = new int[100][];
            factorials[0] = new int[] { 1 };
            for (int i = 1; i < factorials.Length; i++)
            {
                factorials[i] = Multiply(factorials[i - 1], i);
            }
            PrintFactorials(factorials);
        }

        static int[] Multiply(int[] inputArray, int index)
        {
            int[] result = { 0 };

            for (int i = 0; i < index; i++)
            {
                result = ArrayCalculator.Add(result, inputArray);
            }
            return result;
        }

        static void PrintFactorials(int[][] factorials)
        {
            foreach (var factorialAsArray in factorials)
            {
                foreach (var digit in factorialAsArray)
                {
                    Console.Write(digit);
                }
                Console.WriteLine();
            }
        }
    }
}
