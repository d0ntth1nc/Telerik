using System;

namespace _02.Get_max_method
{
    /*Write a method GetMax() with two parameters that returns the bigger of two integers.
     * Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax()
     */
    class GetMaxMethod
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first integer: ");
            int firstVal = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int secondVal = int.Parse(Console.ReadLine());
            Console.Write("Enter third integer: ");
            int thirdVal = int.Parse(Console.ReadLine());

            int biggestValue = GetMax(firstVal, secondVal);
            Console.Write("Biggest value is: ");
            if (biggestValue == firstVal)
            {
                Console.WriteLine(GetMax(firstVal, thirdVal));
            }
            else
            {
                Console.WriteLine(GetMax(secondVal, thirdVal));
            }
        }

        static int GetMax(int firstValue, int secondValue)
        {
            if (firstValue > secondValue)
            {
                return firstValue;
            }
            else
            {
                return secondValue;
            }
        }
    }
}
