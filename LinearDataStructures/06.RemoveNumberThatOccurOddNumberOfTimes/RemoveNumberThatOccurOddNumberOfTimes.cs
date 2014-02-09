using System;
using System.Collections.Generic;

namespace _06.RemoveNumberThatOccurOddNumberOfTimes
{
    //Write a program that removes from given sequence all numbers that occur odd number of times. 
    class RemoveNumberThatOccurOddNumberOfTimes
    {
        static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Stack<int> removedElements = new Stack<int>();
            int currentElementIndex = 0;
            do
            {
                int currentElement = sequence[currentElementIndex];
                int elementOccurence = 0;
                for (int i = 0; i < sequence.Count; i++)
                {
                    if (currentElement == sequence[i])
                    {
                        elementOccurence++;
                    }
                }
                if (elementOccurence % 2 == 0)
                {
                    sequence.RemoveAll(x => x == currentElement);
                    removedElements.Push(currentElement);
                }
                else
                {
                    currentElementIndex++;
                }
            }
            while(currentElementIndex < sequence.Count);

            foreach (int element in removedElements)
            {
                Console.WriteLine("Element \"{0}\" removed", element);
            }
        }
    }
}
