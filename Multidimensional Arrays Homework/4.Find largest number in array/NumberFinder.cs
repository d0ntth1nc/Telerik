using System;

namespace _4.Find_largest_number_in_array
{
    //Write a program, that reads from the console an array of N integers and an integer K,
    //sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
    class NumberFinder
    {
        static void Main(string[] args)
        {
            Console.Write("Array length: ");
            int n = int.Parse(Console.ReadLine());
            int[] inputArray = new int[n];

            for (int i = 0; i < n; i++)
			{
                inputArray[i] = int.Parse(Console.ReadLine());
			}

            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Array.Sort(inputArray);

            int foundIndex = Array.BinarySearch(inputArray, k);

            if (foundIndex > 0)
            {
                Console.WriteLine("Found the same element at index = {0}", foundIndex);
            }
            else
            {
                Console.WriteLine("Max element = {0} < k at index = {0}", inputArray[~foundIndex - 1], ~foundIndex - 1);
            }
        }
    }
}
