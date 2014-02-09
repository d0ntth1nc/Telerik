using System;

namespace _11.Binary_search
{
    //Write a program that finds the index of given element in a sorted array of
    //integers by using the binary search algorithm (find it in Wikipedia).
    class BinarySearcher
    {
        static void Main(string[] args)
        {
            int[] inputArray = new int[] { 1, 2, 3, 4, 5, 6, 7};
            int foundKey = Search(inputArray, 3);
            Console.WriteLine("Found key at position {0}", foundKey);
        }

        public static int Search(int[] inputArray, int key)
        {
            return BinarySearch(inputArray, key, 0, inputArray.Length - 1);
        }

        static int BinarySearch(int[] inputArray, int key, int leftPoint, int rightPoint)
        {
            if (leftPoint <= rightPoint)
            {
                int middlePoint = (leftPoint / 2) + (rightPoint / 2);
                if (key == inputArray[middlePoint])
                {
                    return middlePoint;
                }
                else if (key > inputArray[middlePoint])
                {
                    return BinarySearch(inputArray, key, middlePoint + 1, rightPoint);
                }
                else
                {
                    return BinarySearch(inputArray, key, leftPoint, middlePoint - 1);
                }
            }
            return -1;
        }
    }
}
