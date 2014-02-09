using System;
using System.Collections.Generic;

namespace _12.CustomStack
{
    class CustomStackTester
    {
        static void Main(string[] args)
        {
            Stack<int> ss = new Stack<int>();
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(8);
            stack.Push(3);
            stack.Push(1);
            stack.Push(44);
            int[] stackArray = stack.ToArray();
            Console.Write("Stack array: ");
            foreach (var item in stackArray)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("CustomStack.Peek() -> {0}", stack.Peek());
            Console.WriteLine("CustomStack.Pop() -> {0}", stack.Pop());
            Console.WriteLine("CustomStack.Contains(44) -> {0} //Note that we used .Pop()", stack.Contains(44));
            Console.WriteLine("CustomStack.Count() -> {0}", stack.Count);
            stack.Clear();
            Console.WriteLine("Elements count after CustomStack.Clear() -> {0}", stack.Count);
        }
    }
}
