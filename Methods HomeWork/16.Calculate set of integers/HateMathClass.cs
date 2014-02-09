using System;

namespace _16.Calculate_set_of_integers
{
    //14.Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
    //Use variable number of arguments.
    //15.* Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.).
    //Use generic method (read in Internet about generic methods in C#)
    class HateMathClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input array is 4, 5.9999, 3, -1.1, 7.5");
            Console.WriteLine("Min value -> {0}", HateMath.MinValue(4, 5.9999, 3, -1.1, 7.5));
            Console.WriteLine("Max value -> {0}", HateMath.MaxValue(4, 5.9999, 3, -1.1, 7.5));
            Console.WriteLine("Average -> {0}", HateMath.Average(4, 5.9999, 3, -1.1, 7.5));
            Console.WriteLine("Sum -> {0}", HateMath.Sum(4, 5.9999, 3, -1.1, 7.5));
            Console.WriteLine("Product -> {0}", HateMath.Product(4, 5.9999, 3, -1.1, 7.5));
        }
    }

    public static class HateMath
    {
        public static T MinValue<T>(params T[] inputArray)
        {
            dynamic minValue = inputArray[0];
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] < minValue)
                {
                    minValue = inputArray[i];
                }
            }
            return minValue;
        }

        public static T MaxValue<T>(params T[] inputArray)
        {
            dynamic maxValue = inputArray[0];
            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] > maxValue)
                {
                    maxValue = inputArray[i];
                }
            }
            return maxValue;
        }

        public static T Average<T>(params T[] inputArray)
        {
            dynamic sum = Sum<T>(inputArray);
            return  sum / inputArray.Length;
        }

        public static T Sum<T>(params T[] inputArray)
        {
            dynamic currentSum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                currentSum += inputArray[i];
            }
            return currentSum;
        }

        public static T Product<T>(params T[] inputArray)
        {
            dynamic currentProduct = inputArray[0];
            for (int i = 1; i < inputArray.Length; i++)
            {
                currentProduct *= inputArray[i];
            }
            return currentProduct;
        }
    }
}
