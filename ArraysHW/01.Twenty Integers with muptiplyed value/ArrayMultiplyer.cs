using System;

namespace ArraysHW
{
    //Write a program that allocates array of 20 integers and initializes each element
    //by its index multiplied by 5. Print the obtained array on the console.
    class ArrayMultiplyer
    {
        static void Main(string[] args)
        {
            const int MULTIPLYER = 5;
            const int DEFAULT_INT_COUNT = 20;

            int[] myIntArray = new int[DEFAULT_INT_COUNT];
            for (int i = 0; i < myIntArray.Length; i++)
            {
                myIntArray[i] = i * MULTIPLYER;
            }

            Console.WriteLine(string.Join(", ", myIntArray));
        }
    }
}
