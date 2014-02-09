using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _09.Float
{
    //Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float). 
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number(it must be float!): ");
            string number = Console.ReadLine();
            FloatToBinaryConverter.ShowBinaryRepresentation(number);
        }
    }
}
