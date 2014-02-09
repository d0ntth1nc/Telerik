using System;
using System.Collections.Generic;

namespace _05.RemoveAllNegativeNumbers
{
    //Write a program that removes from given sequence all negative numbers.
    class RemoveAllNegativeNumbers
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Console.WriteLine("Break with empty line");
            string input = String.Empty;
            do
            {
                Console.Write("Enter number: ");
                input = Console.ReadLine();
                try
                {
                    if (input != String.Empty)
                    {
                        int integer = Int32.Parse(input);
                        list.Add(integer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (input != String.Empty);

            list.RemoveAll(x => x < 0);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
