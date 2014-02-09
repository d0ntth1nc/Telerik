using System;

namespace _09.Maximal_value_in_portion_of_array
{
    //Write a method that return the maximal element in a portion of array of integers starting at given index.
    //Using it write another method that sorts an array in ascending / descending order
    class ArraySorter
    {
        static int FindMaximalElement(int startIndex, int[] inputArray)
        {
            int maxValue = int.MinValue;
            int maxElementIndex = 0;
            for (int i = startIndex; i < inputArray.Length; i++)
            {
                if (inputArray[i] > maxValue)
                {
                    maxValue = inputArray[i];
                    maxElementIndex = i;
                }
            }
            return maxElementIndex;
        }

        static void SortArray(int[] inputArray, bool ascending)
        {
            int[] sortedArray = new int[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                int maxElementIndex = FindMaximalElement(i, inputArray);

                int swapper = inputArray[maxElementIndex];
                inputArray[maxElementIndex] = inputArray[i];
                inputArray[i] = swapper;
            }
            if (ascending)
            {
                Array.Reverse(inputArray);
            }
        }

        static void Main(string[] args)
        {
            int[] inputArray = {1, 3, 5, 2, 9, 6, 8, 7, 4 };
            Console.WriteLine("Given Array - > {0}", string.Join(", ", inputArray));
            SortArray(inputArray, true);
            Console.WriteLine("Sorted Array - > {0}", string.Join(", ", inputArray));
        }
    }
}
