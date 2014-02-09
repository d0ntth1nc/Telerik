using System;

namespace Methods_HomeWork
{
    //Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”).
    //Write a program to test this method
    class HelloName
    {
        static void Main(string[] args)
        {
            AskForName();
        }

        static void AskForName()
        {
            Console.Write("Your name is: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, {0}", name);
        }
    }
}
