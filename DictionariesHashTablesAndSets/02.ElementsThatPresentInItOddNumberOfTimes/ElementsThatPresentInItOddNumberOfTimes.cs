using System;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    class ElementsThatPresentInItOddNumberOfTimes
    {
        static void Main(string[] args)
        {
            string[] givenValues = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            Dictionary<string, byte> myDictionary = new Dictionary<string, byte>();

            foreach (var value in givenValues)
            {
                byte occurences = 0;
                if (myDictionary.ContainsKey(value))
                {
                    occurences = myDictionary[value];
                }
                myDictionary[value] = (byte)(occurences + 1);
            }

            Console.WriteLine("");
            foreach (var value in myDictionary)
            {
                if (value.Value % 2 == 1)
                {
                    Console.WriteLine(value.Key);
                }
            }
        }
    }
}
