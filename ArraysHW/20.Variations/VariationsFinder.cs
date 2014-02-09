using System;

namespace _20.Variations
{
    //Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
	//N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
    class VariationsFinder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] variationsArray = new int[k];
            GetVariations(variationsArray, 0, n);
        }

        static void PrintVariations(int[] variationsArray)
        {
            Console.WriteLine(String.Join(",", variationsArray));
        }

        static void GetVariations(int[] variationsArray, int currentIndex, int n)
        {
            if (currentIndex != variationsArray.Length)
            {
                for (int i = 1; i <= n; i++)
                {
                    variationsArray[currentIndex] = i;
                    GetVariations(variationsArray, currentIndex + 1, n);
                }
            }
            else
            {
                PrintVariations(variationsArray);
            }
        }
    }
}
