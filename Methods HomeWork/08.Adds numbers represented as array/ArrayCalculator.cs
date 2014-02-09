using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _08.Adds_numbers_represented_as_array
{
    //Write a method that adds two positive integer numbers represented as arrays of digits 
    //(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
    //Each of the numbers that will be added could have up to 10 000 digits
    public class ArrayCalculator
    {
        const int MAX_DIGIT_COUNT = 10000;

        static void Main()
        {
            var watch = Stopwatch.StartNew();
            int[] firstArray = new int[MAX_DIGIT_COUNT];
            int[] secondArray = new int[MAX_DIGIT_COUNT];
            Random rd = new Random();
            for (int i = 0; i < MAX_DIGIT_COUNT; i++)
            {
                firstArray[i] = rd.Next(0, 9);
                secondArray[i] = rd.Next(0, 9);
            }
            

            //string first = Console.ReadLine();
            //int[] firstArray = Array.ConvertAll(first.Split(','), y => int.Parse(y));
            //string second = Console.ReadLine();
            //int[] secondArray = Array.ConvertAll(second.Split(','), y => int.Parse(y));

            dynamic result = null;
            
            result = Add(firstArray, secondArray);
            foreach (var item in result)
            {
                Console.Write(item);
            }

            Console.WriteLine();
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            long memory = GC.GetTotalMemory(true);
            Console.WriteLine("Memory usage => {0}", memory);
            Console.ReadKey();
            Main();
        }

        public static int[] Add(int[] firstNumberAsArray, int[] secondNumberAsArray)
        {
            List<int> result = new List<int>();
            bool isNextItemIncreasingByOne = false;
            if (firstNumberAsArray.Length < secondNumberAsArray.Length)
            {
                isNextItemIncreasingByOne = StartCount(secondNumberAsArray, firstNumberAsArray, result, isNextItemIncreasingByOne);
                if(isNextItemIncreasingByOne == true)
                {
                    secondNumberAsArray[secondNumberAsArray.Length - firstNumberAsArray.Length - 1]++;
                }
                for (int i = secondNumberAsArray.Length - firstNumberAsArray.Length - 1; i >= 0 ; i--)
                {
                    result.Add(secondNumberAsArray[i]);
                }
                
            }
            else if (firstNumberAsArray.Length > secondNumberAsArray.Length)
            {
                isNextItemIncreasingByOne = StartCount(firstNumberAsArray, secondNumberAsArray, result, isNextItemIncreasingByOne);
                if (isNextItemIncreasingByOne == true)
                {
                    int index = secondNumberAsArray.Length + 1;
                    firstNumberAsArray[firstNumberAsArray.Length - index] += 1;
                }
                for (int i = 0; i < firstNumberAsArray.Length - secondNumberAsArray.Length; i++)
                {
                    result.Add(firstNumberAsArray[i]);
                }
            }
            else
            {
                isNextItemIncreasingByOne = StartCount(firstNumberAsArray, secondNumberAsArray, result, isNextItemIncreasingByOne);
                if (isNextItemIncreasingByOne == true)
                {
                    result.Add(1);
                }
            }
            int[] resultAsIntArray = result.ToArray();
            Array.Reverse(resultAsIntArray);
            return resultAsIntArray;
        }

        private static bool StartCount(int[] biggerNumber, int[] smallerNumber, List<int> result, bool isNextItemIncreasingByOne)
        {
            for (int i = 1; i <= smallerNumber.Length; i++)
            {
                int currentValue;
                if (isNextItemIncreasingByOne)
                {
                    currentValue = (1 + biggerNumber[biggerNumber.Length - i] + smallerNumber[smallerNumber.Length - i]);
                }
                else
                {
                    currentValue = (biggerNumber[biggerNumber.Length - i] + smallerNumber[smallerNumber.Length - i]);
                }
                if (currentValue > 9)
                {
                    isNextItemIncreasingByOne = true;
                }
                else
                {
                    isNextItemIncreasingByOne = false;
                }
                result.Add(currentValue % 10);
            }
            return isNextItemIncreasingByOne;
        }
    }
}
