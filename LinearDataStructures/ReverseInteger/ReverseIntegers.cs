using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseInteger
{
    //Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.
    class ReverseIntegers
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string input = String.Empty;
            int arraySize = 0;
            try
            {
                Console.Write("Array size: ");
                input = Console.ReadLine();
                arraySize = Int32.Parse(input);
                for (int i = 0; i < arraySize; i++)
                {
                    Console.Write("Enter integer: ");
                    input = Console.ReadLine();
                    int number = Int32.Parse(input);
                    stack.Push(number);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            stack.Reverse();
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
