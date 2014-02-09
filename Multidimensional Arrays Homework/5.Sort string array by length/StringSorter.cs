using System;

namespace _5.Sort_string_array_by_length
{
    //You are given an array of strings.
    //Write a method that sorts the array by the length of its elements (the number of characters composing them).
    class StringSorter
    {
        static void Main(string[] args)
        {
            string[] stringArray = {"wqhje", "sdsadas", "sd", "s" };
            Console.WriteLine("Before sorting:");
            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine(stringArray[i]);
            }

            Console.WriteLine("After recursive quicksort: ");
            SortByLength(stringArray);

            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine(stringArray[i]);
            }
        }

        static private int Partition(string[,] inputArray, int left, int right)
        {
            int pivot = Convert.ToInt32(inputArray[0, left]);
            while (true)
            {
                while (Convert.ToInt32(inputArray[0, left]) < pivot)
                {
                    left++;
                }

                while (Convert.ToInt32(inputArray[0, right]) > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    string tempLength = inputArray[0, right];
                    string tempString = inputArray[1, right];

                    inputArray[0, right] = inputArray[0, left];
                    inputArray[1, right] = inputArray[1, left];

                    inputArray[0, left] = tempLength;
                    inputArray[1, left] = tempString;

                }
                else
                {
                    return right;
                }
            }
        }

        static private void QuickSort_Recursive(string[,] inputArray, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(inputArray, left, right);

                if (pivot > 1)
                {
                    QuickSort_Recursive(inputArray, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    QuickSort_Recursive(inputArray, pivot + 1, right);
                }
            }
        }

        static public void SortByLength(string[] inputArray)
        {
            string[,] stringArrayAndRelevantLengths = new string[2, inputArray.Length];
            int counter = 0;
            foreach (var word in inputArray)
            {
                stringArrayAndRelevantLengths[0, counter] = Convert.ToString(word.Length);
                stringArrayAndRelevantLengths[1, counter] = word;
                counter++;
            }

            QuickSort_Recursive(stringArrayAndRelevantLengths, 0, inputArray.Length - 1);
            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = stringArrayAndRelevantLengths[1, i];
            }
        }
    }
}
