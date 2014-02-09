using System;

namespace _21.Combinations
{
    //Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
	//N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
    class CombinationsGenerator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] combinationsArray = new int[k];
            GetCombinations(combinationsArray, n, 0, 1);
        }

        private static void GetCombinations(int[] combinationsArray, int n, int currentIndex, int previousIndex)
        {
            if (currentIndex != combinationsArray.Length)
            {
                for (int i = previousIndex; i <= n; i++)
                {
                    combinationsArray[currentIndex] = i;
                    GetCombinations(combinationsArray, n, currentIndex + 1, i + 1);
                }
            }
            else
            {
                PrintCombinations(combinationsArray);
            }
        }

        static void PrintCombinations(int[] combinationsArray)
        {
            Console.WriteLine(String.Join(",", combinationsArray));
        }
    }
}
