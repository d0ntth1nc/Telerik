using System;
using System.Linq;

namespace _07.Occurence
{
    //Write a program that finds in given array of integers
    //(all belonging to the range [0..1000]) how many times each of them occurs.
    class Occurence
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            int[] helperArray = new int[array.Max() + 1];
            foreach (var item in array)
            {
                helperArray[item]++;
            }
            for (int i = 0; i < helperArray.Length; i++)
            {
                if (helperArray[i] != 0)
                {
                    Console.WriteLine("{0} -> {1} times", i, helperArray[i]);
                }
            }
        }
    }
}
