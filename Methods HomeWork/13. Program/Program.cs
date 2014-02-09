using System;

namespace _13.Program
{
    /*
     * Write a program that can solve these tasks:
        *Reverses the digits of a number
        *Calculates the average of a sequence of integers
        *Solves a linear equation a * x + b = 0
	 * Create appropriate methods.
	 * Provide a simple text-based menu for the user to choose which task to solve.
	 * Validate the input data:
        *The decimal number should be non-negative
        *The sequence should not be empty
        *a should not be equal to 0
     */
    class Program
    {
        static long Reverse(long inputNumber)
        {
            if (inputNumber < 0)
            {
                throw new FormatException("The decimal number must not be negative!");
            }
            long leftDigits = inputNumber;
            long reversed = 0;
            while (leftDigits > 0)
            {
                long lastDigit = leftDigits % 10;
                reversed = reversed * 10 + lastDigit;
                leftDigits = leftDigits / 10;
            }
            return reversed;
        }

        static double Average(int[] inputArray)
        {
            if (inputArray.Length == 0)
            {
                throw new FormatException("The sequence must not be empty!");
            }
            int currentSum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                currentSum += inputArray[i];
            }
            return currentSum / inputArray.Length;
        }

        static double SolveLinearEquation(int a, int b)
        {
            if (a == 0)
            {
                throw new FormatException("A must not be equal to 0!");
            }
            return -b / a;
        }

        static void Main()
        {
            Console.WriteLine("1.Reverses the digits of a number");
            Console.WriteLine("2.Calculates the average of a sequence of integers");
            Console.WriteLine("3.Solves a linear equation a * x + b = 0");
            Console.Write("Enter your choice: ");
            byte choice = byte.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1: OnReverseSelected(); break;
                case 2: OnAverageOfSequenceSelected(); break;
                case 3: OnSolveLinearEquationSelected(); break;
                default: Main(); break;
            }
        }

        private static void OnSolveLinearEquationSelected()
        {
            Console.Write("Enter a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter b: ");
            int b = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine("x = {0}", SolveLinearEquation(a, b));
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.ReadKey();
                OnSolveLinearEquationSelected();
            }
        }

        private static void OnAverageOfSequenceSelected()
        {
            Console.Write("Enter sequence length: ");
            try
            {
                int length = int.Parse(Console.ReadLine());
                int[] array = new int[length];
                for (int i = 0; i < length; i++)
                {
                    Console.Write("arr[{0}] = ", i);
                    array[i] = int.Parse(Console.ReadLine());
                }
                double average = Average(array);
                Console.WriteLine("Average -> {0}", average);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("I cannot accept empty values!");
                Console.ReadKey();
                OnAverageOfSequenceSelected();
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.ReadKey();
                OnAverageOfSequenceSelected();
            }
            
        }

        private static void OnReverseSelected()
        {
            Console.Write("Enter number: ");
            long number = long.Parse(Console.ReadLine());
            try
            {
                number = Reverse(number);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.ReadKey();
                OnReverseSelected();
            }
            Console.WriteLine("Result -> {0}", number);
        }      
    }
}
