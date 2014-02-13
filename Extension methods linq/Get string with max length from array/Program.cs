using System;
using System.Linq;

namespace Get_string_with_max_length_from_array
{
    class Program
    {
        //17. Write a program to return the string with maximum length from an array of strings. Use LINQ
        static void Main()
        {
            string[] strings = new string[]
            {
                "first", "second", "third", "longeststring"
            };
            var result = strings.First(x => x.Length == strings.Max(y => y.Length));
            Console.WriteLine(result);
        }
    }
}
