using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
    class TestConverter
    {
        static void Main()
        {
            Console.Write("Enter input numeral base: ");
            byte inputNumeralBase = byte.Parse(Console.ReadLine());
            Console.Write("Enter output numeral base: ");
            byte outputNumeralBase = byte.Parse(Console.ReadLine());
            Console.Write("Enter the number: ");
            string inputNumber = Console.ReadLine();

            Console.WriteLine(Converter.ConvertAnyToAny(inputNumber, inputNumeralBase, outputNumeralBase));
        }
    }
}
