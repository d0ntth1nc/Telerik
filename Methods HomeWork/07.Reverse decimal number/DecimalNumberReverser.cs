using System;

namespace _07.Reverse_decimal_number
{
    //Write a method that reverses the digits of given decimal number
    class DecimalNumberReverser
    {
        static int Reverse(int number)
        {
            int leftDigits = number;
            int reversed = 0;
            while (leftDigits > 0)
            {
                int lastDigit = leftDigits % 10;
                reversed = reversed * 10 + lastDigit;
                leftDigits = leftDigits / 10;
            }
            return reversed;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter digit to reverse: ");
            int inputDigit = int.Parse(Console.ReadLine());
            Console.WriteLine("{0} -> {1}", inputDigit, Reverse(inputDigit));
        }
    }
}
