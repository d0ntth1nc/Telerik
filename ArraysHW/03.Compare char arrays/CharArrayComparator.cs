using _02.Compare_arrays; //Using the method from the previous homework
using System;

namespace _03.Compare_char_arrays
{
    //Write a program that compares two char arrays lexicographically (letter by letter).
    class CharArrayComparator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] firstCharArr = new char[n];
            char[] secondCharArr = new char[n];

            for (int i = 0; i < n; i++)
            {
                firstCharArr[i] = Convert.ToChar(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                secondCharArr[i] = Convert.ToChar(Console.ReadLine());
            }

            bool areEqual = ArrayComparator.CompareArrays(firstCharArr, secondCharArr); //Using the class from the previous HW
            Console.WriteLine(areEqual);
        }
    }
}
