using System;

namespace _04.Maximum_sequence
{
    /*Write a program that finds the maximal sequence of equal elements in an array.
		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}.
     */
    class MaximumSequenceFinder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] myArray = new int[n];
            int currentSequenceLength = 1;
            int biggestSequenceLength = 1;
            int dominateNumber = 0;

            myArray[0] = int.Parse(Console.ReadLine());
            dominateNumber = myArray[0];
            for (int i = 1; i < myArray.Length; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
                if (myArray[i - 1] == myArray[i])
                {
                    currentSequenceLength++;
                }
                else
                {
                    currentSequenceLength = 1;
                }
                if (currentSequenceLength > biggestSequenceLength)
                {
                    biggestSequenceLength = currentSequenceLength;
                    dominateNumber = myArray[i];
                }
            }

            Console.Write("{0} -> ", string.Join(", ", myArray));
            Console.Write("{");
            for (int i = 0; i < biggestSequenceLength; i++)
            {
                Console.Write(dominateNumber + ", ");
            }
            Console.WriteLine("}");
        }
    }
}
