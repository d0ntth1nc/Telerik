using _05.Element_is_bigger_than_its_neighbours;
using System;

namespace _06.First_element_bigger_than_its_neighbours
{
    //Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
    class FirstElementBiggerThanNeighbours
    {
        static int GetIndexOfFirstElementBiggerThanNeighbours(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                bool isBiggerThanItsNeighbours = ElementChecker.IsBiggerThanNeighbours(i, inputArray);
                if (isBiggerThanItsNeighbours)
                {
                    return i;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int[] givenArray = { 1, 2, 3, 1, 4, 5, 1, 5, 1, 3, 1 };
            Console.WriteLine("Our array: {0}", string.Join(", ", givenArray));
            Console.WriteLine("Index = {0}", GetIndexOfFirstElementBiggerThanNeighbours(givenArray));
        }
    }
}
