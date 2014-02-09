using System;

namespace _19.Permutations
{
    //Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. Example:
	//n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
    class PermutationsGenerator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbersArray = new int[n];

            for (int i = 1; i <= n; i++)
            {
                numbersArray[i - 1] = i;
            }
            Permute(numbersArray, 0, numbersArray.Length - 1);
        }

        static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int swap = firstNumber;
            firstNumber = secondNumber;
            secondNumber = swap;
        }

        static void Permute(int[] numbersArray, int currentIndex, int length)
        {
            if (currentIndex == length)
            {
                Console.WriteLine(string.Join(", ", numbersArray));
            }
            else
            {
                for (int i = currentIndex; i <= length; i++)
                {
                    Swap(ref numbersArray[i], ref numbersArray[currentIndex]);
                    Permute(numbersArray, currentIndex + 1, length);
                    Swap(ref numbersArray[i], ref numbersArray[currentIndex]);
                }
            }

        }
    }
}
