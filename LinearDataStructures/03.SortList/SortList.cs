using System;
using System.Collections.Generic;

namespace _03.SortList
{
    /* Write a program that reads a sequence of integers (List<int>)
     * ending with an empty line and sorts them in an increasing order.
     */

    class SortList
    {
        static List<int> list = new List<int>();
        static void Main(string[] args)
        {
            string input = String.Empty;
            do
            {
                Console.Write("Enter integer: ");
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

            list.Sort();
            foreach (var integer in list)
            {
                Console.WriteLine(integer);
            }
        }
    }
}
