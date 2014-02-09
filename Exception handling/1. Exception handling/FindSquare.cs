using System;

namespace _1.Exception_handling
{
    //Write a program that reads an integer number and calculates and prints its square root.
    //If the number is invalid or negative, print "Invalid number".
    //In all cases finally print "Good bye". Use try-catch-finally
    class FindSquare
    {
        static double GetSquare(string numberAsString)
        {
            double numberAsDouble = Convert.ToDouble(numberAsString);
            if (numberAsDouble < 0)
            {
                throw new ArgumentException();
            }
            return numberAsDouble;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            try
            {
                string numberAsString = Console.ReadLine();
                Console.WriteLine(GetSquare(numberAsString));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is FormatException)
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
