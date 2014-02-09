using System;
using System.Linq;

namespace _08.FindMajorant
{
    /*The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
     * Write a program to find the majorant of given array (if exists). Example:
        {2, 2, 3, 3, 2, 3, 4, 3, 3}  3
     */

    class MajorantFinder
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            int[] helperArray = new int[array.Max() + 1];
            foreach (var item in array)
            {
                helperArray[item]++;
            }
            int mostFrequently = helperArray.Max();
            int majorantFormula = array.Length / 2 + 1;
            for (int i = 0; i < helperArray.Length; i++)
            {
                if (helperArray[i] == mostFrequently)
                {
                    if (mostFrequently >= majorantFormula)
                    {
                        Console.WriteLine("Majorant is {0}", i);
                    }
                    else
                    {
                        Console.WriteLine("The majorant does not exists");
                    }
                }
            }
        }
    }
}
