using System;

namespace _05.Element_is_bigger_than_its_neighbours
{
    //Write a method that checks if the element at given position in given array of integers is bigger than
    //its two neighbors (when such exist)Write a method that checks if the element at given position in given array of
    //integers is bigger than its two neighbors (when such exist)
    public class ElementChecker
    {
        static void Main(string[] args)
        {
            int[] givenArray = { 1, 2, 3, 1, 4, 5, 1, 5, 1, 3, 1 };
            Console.WriteLine("Our array: {0}", string.Join(", ", givenArray));
            Console.WriteLine("Is element at index 2 bigger than its two neighbours? - > {0}", IsBiggerThanNeighbours(2, givenArray));
        }

        public static bool IsBiggerThanNeighbours(int index, int[] inputArray)
        {
            bool isBigger = false;

            if (index > 0 && index < inputArray.Length - 1)
            {
                isBigger = (inputArray[index] > inputArray[index - 1]) && (inputArray[index] > inputArray[index + 1]);
            }

            return isBigger;
        }
    }
}
