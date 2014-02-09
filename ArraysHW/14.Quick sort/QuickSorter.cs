using System;

namespace _14.Quick_sort
{
    //Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
    class QuickSorter
    {
        static void Main(string[] args)
        {
            int[] numbersArray = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };

            Sort(numbersArray, 0, numbersArray.Length - 1);
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(numbersArray[i]);
            }
        }

        static int Partition(int[] numbersArray, int leftPoint, int rightPoint)
        {
            int pivot = numbersArray[leftPoint];
            while (true)
            {
                while (numbersArray[leftPoint] < pivot)
                {
                    leftPoint++;
                }
                while (numbersArray[rightPoint] > pivot)
                {
                    rightPoint--;
                }

                if (leftPoint < rightPoint)
                {
                    int swapper = numbersArray[rightPoint];
                    numbersArray[rightPoint] = numbersArray[leftPoint];
                    numbersArray[leftPoint] = swapper;
                }
                else
                {
                    return rightPoint;
                }
            }
        }

        static public void Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Sort(arr, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    Sort(arr, pivot + 1, right);
                }
            }
        }
    }
}
