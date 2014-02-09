using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
    public static class Converter
    {
        private static string ConvertDecimalToAny(uint inputNumber, byte inputNumeralBase = 16)
        {
            if (inputNumber == 0)
            {
                return "0";
            }
            string numberRepresentedAsGivenBase = string.Empty;

            uint result = inputNumber;
            while (result > 0)
            {
                uint reminder = result % inputNumeralBase;
                if (reminder <= 9)
                {
                    numberRepresentedAsGivenBase += reminder;
                }
                else //Lets represent the digit as char
                {
                    numberRepresentedAsGivenBase += (char)(55 + reminder);
                }
                result = result / inputNumeralBase;
            }

            char[] numberAsCharArray = numberRepresentedAsGivenBase.ToCharArray();

            Array.Reverse(numberAsCharArray);
            numberRepresentedAsGivenBase = new string(numberAsCharArray);
            return numberRepresentedAsGivenBase;
        }

        private static uint ConvertAnyToDecimal(string inputNumber, byte inputNumeralBase = 2)
        {
            char[] numberAsCharArray = inputNumber.ToCharArray();
            uint result = 0;
            Array.Reverse(numberAsCharArray);
            for (int i = 0; i < numberAsCharArray.Length; i++)
            {
                uint currentDigit = (uint)Char.GetNumericValue(numberAsCharArray[i]);
                if (currentDigit < 0)
                {
                    result += (uint)(numberAsCharArray[i] - 55) * Convert.ToUInt32(Math.Pow(inputNumeralBase, i));
                }
                else
                {
                    result += currentDigit * Convert.ToUInt32(Math.Pow(inputNumeralBase, i));
                }
            }
            return result;
        }

        public static string ConvertAnyToAny(string inputNumber, byte inputNumeralBase, byte outputNumeralBase)
        {
            if (inputNumeralBase < 2 || outputNumeralBase > 16)
            {
                throw new ArgumentOutOfRangeException("2 ≤ s, d ≤  16");
            }

            uint numberInDecimal = ConvertAnyToDecimal(inputNumber, inputNumeralBase);
            return ConvertDecimalToAny(numberInDecimal, outputNumeralBase);
        }
    }
}
