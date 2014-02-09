using System;

namespace _09.Most_frequent_number
{
    //Write a program that finds the most frequent number in an array. Example:
	//{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
    class MostFreqNumberFinder
    {
        static void Main(string[] args)
        {
            int arrayLength = int.Parse(Console.ReadLine());

            int[] myArray = new int[arrayLength];
            int[] numberOccurenceGraph = new int[arrayLength];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
            }

            int occurences = 0;
            int mostFrequentNumber = GetMostFrequentNumber(myArray, out occurences);
            Console.WriteLine(mostFrequentNumber + "({0} times)", occurences);
        }

        static int GetMostFrequentNumber(int[] inputArray, out int biggestValue)
        {
            int[] numberOccurenceGraph = new int[inputArray.Length];
            for (int i = 0; i < numberOccurenceGraph.Length; i++)
            {
                numberOccurenceGraph[i] = 0;
            }

            for (int i = 0; i < inputArray.Length; i++)
            {
                int number = inputArray[i];
                numberOccurenceGraph[number]++;
            }

            biggestValue = numberOccurenceGraph[0];
            int biggestValuePosition = 0;
            for (int i = 0; i < numberOccurenceGraph.Length; i++)
            {
                if (numberOccurenceGraph[i] > biggestValue)
                {
                    biggestValue = numberOccurenceGraph[i];
                    biggestValuePosition = i;
                }
            }
            return biggestValuePosition;
        }
    }
}
