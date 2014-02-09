using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _02.Compare_arrays
{
    public class ArrayComparator
    {
        //Write a program that reads two arrays from the console and compares them element by element.
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArr = new int[n];
            int[] secondArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                firstArr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                secondArr[i] = int.Parse(Console.ReadLine());
            }

            var timer = Stopwatch.StartNew();
            bool areEqual = CompareArrays(firstArr, secondArr);
            timer.Stop();
            Console.WriteLine(areEqual + ", Time elapsed: {0}", timer.Elapsed);
        }

        public static bool CompareArrays(dynamic firstArray, dynamic secondArray)
        {
            var arrayType = firstArray.GetType();
            if (arrayType == typeof(List<>))
            {
                if (firstArray.Count == secondArray.Count)
                {
                    for (int i = 0; i < firstArray.Count; i++)
                    {
                        if (firstArray[i] != secondArray[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (firstArray.Length == secondArray.Length)
                {
                    for (int i = 0; i < firstArray.Length; i++)
                    {
                        if (firstArray[i] != secondArray[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
