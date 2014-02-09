using System;

namespace _2.Enter_numbers
{
    /*
     * Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
     * If an invalid number or non-number text is entered, the method should throw an exception.
     * Using this method write a program that enters 10 numbers:
			a1, a2, … a10, such that 1 < a1 < … < a10 < 100
     */
    class NumberGetter
    {
        const int NUMBERS_COUNT = 10;

        static int CheckForValidInteger(string inputInteger, int index, int[] numbers)
        {
            int number = 0;
            try
            {
                number = int.Parse(inputInteger);
            }
            catch
            {
                throw new ArgumentOutOfRangeException("Invalid number!");
            }
            if (number < 2 || number > 99)
            {
                throw new ArgumentOutOfRangeException("Invalid number!");
            }
            else if (index > 0)
            {
                if (numbers[index - 1] >= number)
                {
                    throw new ArgumentOutOfRangeException("Invalid number!");
                }
            }
            return number;
        }

        static void Main(string[] args)
        {
            int[] numbers = new int[NUMBERS_COUNT];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Enter {0} number: ", i + 1);
                int validNumber = 0;
                try
                {
                    validNumber = CheckForValidInteger(Console.ReadLine(), i, numbers);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                numbers[i] = validNumber;
            }

            Console.Write("Valid numbers: ");
            foreach (var number in numbers)
            {
                if (number != 0)
                {
                    Console.Write("{0}, ", number);
                }
            }
        }
    }
}
