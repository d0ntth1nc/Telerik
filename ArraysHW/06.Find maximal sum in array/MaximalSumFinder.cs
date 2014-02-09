using System;
using System.Linq;

namespace _06.Find_maximal_sum_in_array
{
    /*Write a program that reads two integer numbers N and K and an array of N elements from the console. 
     * Find in the array those K elements that have maximal sum.
     */
    class MaximalSumFinder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] myArray = new int[n];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
            }

            var sortedArray = myArray.OrderByDescending(i => i).ToArray(); //Maximal sum have the biggest numbers (simple logic)
            Console.WriteLine("K elements that have maximal sum:");
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine(sortedArray[i]);
            }
        }
    }
}
