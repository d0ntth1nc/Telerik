using System;

namespace _03.Last_digit_as_word
{
    //Write a method that returns the last digit of given integer as an English word.
    //Examples: 512  "two", 1024  "four", 12309  "nine"
    class LastDigit
    {
        static void Main(string[] args)
        {
            Console.Write("Enter integer: ");
            int givenInt = int.Parse(Console.ReadLine());
            Console.WriteLine(LastDigitAsWord(givenInt));
        }

        static string LastDigitAsWord(int givenInteger)
        {
            string word = string.Empty;
            int lastDigit = givenInteger % 10;
            switch(lastDigit)
            {
                case 0: word = "Zero"; break;
                case 1: word = "One"; break;
                case 2: word = "Two"; break;
                case 3: word = "Three"; break;
                case 4: word = "Four"; break;
                case 5: word = "Five"; break;
                case 6: word = "Six"; break;
                case 7: word = "Seven"; break;
                case 8: word = "Eight"; break;
                case 9: word = "Nine"; break;
            }
            return word;
        }
    }
}
