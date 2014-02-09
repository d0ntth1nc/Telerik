using System;

namespace _07.Sort_array
{
    /*Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
     * Use the "selection sort" algorithm: Find the smallest element, move it at the first position,
     * find the smallest from the rest, move it at the second position, etc.
     */
    class ArraySorter
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] myArray = new int[n];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
            }

            int[] sortedArray = myArray; //Lets keep the original array
            int smallestElement = 0;
            int smallestElementPos = 0;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                smallestElement = sortedArray[i];
                smallestElementPos = i;
                for (int k = i; k < myArray.Length; k++) //Search only the rest of the elements
                {
                    if (sortedArray[k] < smallestElement)
                    {
                        smallestElement = sortedArray[k];
                        smallestElementPos = k;
                    }
                }
                int swapper = sortedArray[i];
                sortedArray[i] = smallestElement;
                sortedArray[smallestElementPos] = swapper;
            }

            Console.WriteLine(string.Join(", ", sortedArray));
        }
    }
}
