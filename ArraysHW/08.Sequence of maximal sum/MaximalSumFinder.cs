using System;

namespace _08.Sequence_of_maximal_sum
{
    /*Write a program that finds the sequence of maximal sum in given array. Example:
	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}
	Can you do it with only one loop (with single scan through the elements of the array)?
     */
    class MaximalSumFinder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] myArray = new int[n];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
            }

            int max = myArray[0];
            int maxEnd = myArray[0];
            int longestSequence = 1;
            int currentSequence = 1;
            int startPosition = 0;
            int startTemp = 0;

            for (int i = 1; i < myArray.Length; ++i)
            {
                if (myArray[i] + maxEnd > myArray[i])
                {
                    maxEnd = myArray[i] + maxEnd;
                    currentSequence++;
                }

                else
                {
                    maxEnd = myArray[i];
                    startTemp = i;
                    currentSequence = 1;
                }
                if (maxEnd > max)
                {
                    max = maxEnd;
                    longestSequence = currentSequence;
                    startPosition = startTemp;
                }
            }

            for (int i = startPosition; i < startPosition + longestSequence; ++i)
            {
                Console.Write("{0} ", myArray[i]);
            }
        }
    }
}
