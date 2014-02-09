using System;

namespace _05.Maximal_increase_sequence
{
    /*Write a program that finds the maximal increasing sequence in an array. Example: 
        {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
     */
    class IncreasingSequenceFinder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] myArray = new int[n];
            int currentSequenceLength = 1;
            int biggestSequenceLength = 1;
            int sequenceStartNumber = 0;

            myArray[0] = int.Parse(Console.ReadLine());
            for (int i = 1; i < myArray.Length; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
                if (myArray[i] == myArray[i - 1] + 1)
                {
                    currentSequenceLength++;
                    if (currentSequenceLength == 2)
                    {
                        sequenceStartNumber = myArray[i - 1];
                    }
                    if (currentSequenceLength > biggestSequenceLength)
                    {
                        biggestSequenceLength = currentSequenceLength;
                    }
                }
                else
                {
                    currentSequenceLength = 1;
                }
            }

            if (biggestSequenceLength != 1)
            {
                Console.Write("{0} -> ", string.Join(", ", myArray));
                Console.Write("{");
                for (int i = 0; i < biggestSequenceLength; i++)
                {
                    Console.Write(sequenceStartNumber + i + ", ");
                }
                Console.WriteLine("}");
            }
            else
            {
                Console.WriteLine("There is no increasing sequence!");
            }
        }
    }
}
