using System;
using System.Collections.Generic;

namespace _04.LongestSubsequence
{
    class LongestSubsequence
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 4, 7, 9, 3, 3, 3, 4, 4, 1, 1, 2, 0 };
            TestMyMethod(sequence);
        }

        static List<int> FindLongestSubsequence(List<int> inputList)
        {
            int subsequenceCount = 1;
            int currentNumber = inputList[0];
            int longestSubsequenceCount = 1;
            int longestSubsequenceNumber = inputList[0];

            for (int numberIndex = 1; numberIndex < inputList.Count; numberIndex++)
            {
                if (inputList[numberIndex] == currentNumber)
                {
                    subsequenceCount++;
                    if (subsequenceCount > longestSubsequenceCount)
                    {
                        longestSubsequenceCount = subsequenceCount;
                        longestSubsequenceNumber = currentNumber;
                    }
                }
                else
                {
                    currentNumber = inputList[numberIndex];
                    subsequenceCount = 1;
                }
            }

            List<int> outputList = new List<int>();
            for (int i = 0; i < longestSubsequenceCount; i++)
            {
                outputList.Add(longestSubsequenceNumber);
            }
            return outputList;
        }

        static void TestMyMethod(List<int> inputList)
        {
            List<int> longestSubsequence = FindLongestSubsequence(inputList);

            if (longestSubsequence.Count == 3)
            {
                Console.WriteLine("It works!");
            }
            else
            {
                Console.WriteLine("It does not works!");
            }
        }
    }
}
