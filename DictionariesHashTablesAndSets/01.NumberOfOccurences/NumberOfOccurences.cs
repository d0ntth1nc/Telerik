using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class NumberOfOccurences
    {
        static void Main(string[] args)
        {
            double[] givenValues = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<double, byte> myDictionary = new Dictionary<double, byte>();

            foreach (var value in givenValues)
            {
                byte occurences = 0;
                if (myDictionary.ContainsKey(value))
                {
                    occurences = myDictionary[value];
                }
                myDictionary[value] = (byte)(occurences + 1);
            }

            Console.WriteLine("Array -> { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 }");
            foreach (var item in myDictionary)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}
