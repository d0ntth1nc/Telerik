using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;

namespace _09.Float
{
    //Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float). 
    public static class FloatToBinaryConverter
    {
        private static string GetExponentBytes(int exponent)
        {
            exponent += 127;
            string exponentBytesAsString = Converter.ConvertAnyToAny(exponent.ToString(), 10, 2);
            while (exponentBytesAsString.Length < 8)
            {
                exponentBytesAsString = exponentBytesAsString.Insert(0, "0");
            }
            return exponentBytesAsString;
        }

        private static string GetMantissaBytes(string[] floatNumberParts, out int exponent)
        {
            string firstMantissaPart = Converter.ConvertAnyToAny(floatNumberParts[0], 10, 2);
            floatNumberParts[1] = floatNumberParts[1].Insert(0, "0.");
            string secondMantissaPart = string.Empty;
            while ((firstMantissaPart.Length + secondMantissaPart.Length) < 23)
            {
                double currentNumber = Convert.ToDouble(floatNumberParts[1]);
                currentNumber *= 2;
                secondMantissaPart += Math.Truncate(currentNumber);
                string helper = Convert.ToString(currentNumber);
                try
                {
                    helper = helper.Remove(0, 2);
                }
                catch
                {
                    break;
                }
                floatNumberParts[1] = "0." + helper;
            }
            string mantissaBytes = firstMantissaPart + "." + secondMantissaPart;

            int firstOne = mantissaBytes.IndexOf('1');

            exponent = GetExponent(mantissaBytes, firstOne);

            mantissaBytes = mantissaBytes.Substring(firstOne + 1); //Normalize
            mantissaBytes = mantissaBytes.Replace(".", string.Empty);
            while (mantissaBytes.Length < 23)
            {
                mantissaBytes += 0;
            }
            return mantissaBytes;
        }

        private static int GetExponent(string mantissaBytes, int firstOne)
        {
            int floatPointPosition = mantissaBytes.IndexOf('.');
            int exponent = 0;
            if (floatPointPosition > firstOne)
            {
                exponent = floatPointPosition - firstOne - 1;
            }
            else
            {
                exponent = floatPointPosition - firstOne;
            }
            return exponent;
        }

        public static void ShowBinaryRepresentation(string inputNumber)
        {
            bool isNegative = Convert.ToDecimal(inputNumber) < 0;
            string floatNumberAsString = Convert.ToString(inputNumber);
            if (isNegative)
            {
                floatNumberAsString = floatNumberAsString.Remove(0, 1);
                Console.Write("{0} ", 1);
            }
            else
            {
                Console.Write("{0} ", 0);
            }

            string[] floatNumberParts = floatNumberAsString.Split('.');

            string mantissaAsByteString = string.Empty;
            string exponentAsByteString = string.Empty;
            int exponent;
            mantissaAsByteString = GetMantissaBytes(floatNumberParts, out exponent);
            exponentAsByteString = GetExponentBytes(exponent);
            Console.Write(exponentAsByteString + " ");
            Console.WriteLine(mantissaAsByteString);
        }
    }
}
