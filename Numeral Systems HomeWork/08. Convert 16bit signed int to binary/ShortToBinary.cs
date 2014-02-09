using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Convert_16bit_signed_int_to_binary
{
    //Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
    class ShortToBinary
    {
        static byte[] ConvertToBinary(short inputNumber)
        {
            byte[] outputNumberAsByteArray = new byte[16];
            bool isNegative = inputNumber < 0;
            if (isNegative)
            {
                inputNumber = Convert.ToInt16(short.MaxValue + inputNumber);
                for (int i = 0; i < outputNumberAsByteArray.Length; i++)
                {
                    outputNumberAsByteArray[i] = 1;
                }
            }

            short result = inputNumber;
            int counter = 0;
            while (result > 0)
            {
                byte reminder = Convert.ToByte(result % 2);
                outputNumberAsByteArray[counter] = reminder;
                counter++;
                result = Convert.ToInt16(result / 2);
            }

            if (isNegative)
            {
                int bitPosition = 0;
                while (true)
                {
                    if (outputNumberAsByteArray[bitPosition] == 1)
                    {
                        outputNumberAsByteArray[bitPosition] = 0;
                    }
                    else
                    {
                        outputNumberAsByteArray[bitPosition] = 1;
                        break;
                    }
                    bitPosition++;
                }
            }
            Array.Reverse(outputNumberAsByteArray);
            return outputNumberAsByteArray;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number to convert: ");
            short inputNumber = short.Parse(Console.ReadLine());
            var result = ConvertToBinary(inputNumber);
            Console.WriteLine(string.Join("", result));
        }
    }
}
