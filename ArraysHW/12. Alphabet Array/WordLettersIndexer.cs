using System;

namespace _12.Alphabet_Array
{
    /*Write a program that creates an array containing all letters from the alphabet (A-Z). 
     * Read a word from the console and print the index of each of its letters in the array.
     */
    class WordLettersIndexer
    {
        static void Main(string[] args)
        {
            char[] alphaBetArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string word = Console.ReadLine();
            char[] wordAsArray = word.ToUpper().ToCharArray();

            foreach (var letter in wordAsArray)
            {
                for (int i = 0; i < alphaBetArray.Length; i++)
                {
                    if (letter == alphaBetArray[i])
                    {
                        Console.WriteLine("Letter:{0}, index:{1}", letter, i);
                    }
                }
            }
        }
    }
}
