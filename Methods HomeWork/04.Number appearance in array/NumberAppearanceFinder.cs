using System;

namespace _04.Number_appearance_in_array
{
    //Write a method that counts how many times given number appears in given array.
    //Write a test program to check if the method is working correctly
    class NumberAppearanceFinder
    {
        static int NumberAppearanceInArray(int[] inputArray, int givenNumber)
        {
            int occurences = 0;
            foreach (var number in inputArray)
            {
                if (number == givenNumber)
                {
                    occurences++;
                }
            }
            return occurences;
        }

        static void Main(string[] args)
        {
            int[] givenArray = { 1, 2, 3, 1, 4, 5, 1, 5, 1, 3, 1 };

            Console.WriteLine("Our array: {0}", string.Join(", ", givenArray));
            Console.WriteLine("1 occurs {0} times.", NumberAppearanceInArray(givenArray, 1));
        }
    }
}
