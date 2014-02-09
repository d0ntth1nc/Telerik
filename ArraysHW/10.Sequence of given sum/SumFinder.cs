using System;

namespace _10.Sequence_of_given_sum
{
    //Write a program that finds in given array of integers a sequence of given sum S (if present).
    //Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}
    class SumFinder
    {
        static void Main(string[] args)
        {
            int[] myArray = { 4, 3, 1, 4, 2, 5, 8 };
            int sum = 11;

            int startPos = 0;
            int currentSum = 0;
            int currentPos = 0;
            bool sequenceExists = false;
            do //My favourite loop
            {
                currentSum += myArray[currentPos];
                if (currentSum < sum) //Keep calculating
                {
                    currentPos++;
                }
                else if (currentSum > sum) //Start over
                {
                    currentSum = 0;
                    startPos++;
                    currentPos = startPos;
                }
                if (currentSum == sum)
                {
                    sequenceExists = true;
                    break;
                }
            }
            while (startPos < myArray.Length);

            if (sequenceExists)
            {
                int[] foundSequence = new int[currentPos - startPos + 1]; //+1 because we include elements at startPos and currentPos
                Console.Write("S = {0} ", sum);
                Console.Write("-> { ");
                for (int i = 0; i < foundSequence.Length; i++)
                {
                    foundSequence[i] = myArray[i + startPos];
                    Console.Write("{0}, ", foundSequence[i]);
                }
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                Console.Write(" ");
                Console.WriteLine("}");
            }
            else
            {
                Console.WriteLine("There is no sequence with this sum");
            }
        }
    }
}
