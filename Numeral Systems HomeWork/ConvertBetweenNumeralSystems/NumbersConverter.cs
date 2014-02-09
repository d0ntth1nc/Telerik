using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeral_Systems_HomeWork
{
    /*Write a program to convert decimal numbers to their binary representation.
      Write a program to convert binary numbers to their decimal representation.
      Write a program to convert decimal numbers to their hexadecimal representation.
      Write a program to convert hexadecimal numbers to their decimal representation.
      Write a program to convert hexadecimal numbers to binary numbers (directly).
      Write a program to convert binary numbers to hexadecimal numbers (directly).
     */
    class NumbersConverter
    {
        static void Main(string[] args)
        {
            dynamic asd = ConvertDecimalToBinary(5001);
            Console.Write("Decimal converted to binary: ");
            Console.WriteLine(string.Join("", asd));

            Console.Write("Binary converted to decimal: ");
            asd = ConvertBinaryToDecimal(asd);
            Console.WriteLine(asd);

            Console.Write("Decimal converted to hexadecimal: ");
            asd = ConvertDecimalToHexadecimal(asd);
            Console.WriteLine(asd);

            Console.Write("Hexadecimal converted to decimal: ");
            asd = ConvertHexadecimalToDecimal(asd);
            Console.WriteLine(asd);

            Console.Write("Hexadecimal converted to binary: ");
            asd = ConvertDecimalToHexadecimal(asd);
            asd = ConvertHexadecimalToBinary(asd);
            Console.WriteLine(string.Join("", asd));

            Console.Write("Binary converted to hexadecimal: ");
            asd = ConvertBinaryToHexadecimal(asd);
            Console.WriteLine(asd);
        }

        static byte[] ConvertDecimalToBinary(int inputNumberInDecimal)
        {
            List<byte> numberInBinaryRepresentationList = new List<byte>();
            int result = inputNumberInDecimal;
            do
            {
                byte reminder = Convert.ToByte(result % 2);
                result = result / 2;
                numberInBinaryRepresentationList.Add(reminder);
            }
            while (result > 0);

            byte[] numberInBinaryRepresentation = numberInBinaryRepresentationList.ToArray();
            Array.Reverse(numberInBinaryRepresentation);
            return numberInBinaryRepresentation;
        }

        static int ConvertBinaryToDecimal(byte[] inputNumberAsBinaryArray)
        {
            int numberAsDecimal = 0;
            byte[] reversedInputNumberAsArray = inputNumberAsBinaryArray;
            Array.Reverse(reversedInputNumberAsArray);
            for (int i = 0; i < reversedInputNumberAsArray.Length; i++)
            {
                numberAsDecimal += reversedInputNumberAsArray[i] * Convert.ToInt32(Math.Pow(2, i));
            }
            return numberAsDecimal;
        }

        static string ConvertDecimalToHexadecimal(int inputNumberInDecimal)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("0x");
            int result = inputNumberInDecimal;
            do
            {
                byte reminder = Convert.ToByte(result % 16);
                result = result / 16;
                switch(reminder)
                {
                    case 10: sb.Insert(2, "A"); break;
                    case 11: sb.Insert(2, "B"); break;
                    case 12: sb.Insert(2, "C"); break;
                    case 13: sb.Insert(2, "D"); break;
                    case 14: sb.Insert(2, "E"); break;
                    case 15: sb.Insert(2, "F"); break;
                    default: sb.Insert(2, reminder); break;
                }
            }
            while (result > 0);
            return sb.ToString();
        }

        static int ConvertHexadecimalToDecimal(string inputNumberInHexadecimal)
        {
            int number = 0;
            char[] inputNumberValues = inputNumberInHexadecimal.ToCharArray();
            Array.Reverse(inputNumberValues);
            for (int i = 0; i < inputNumberValues.Length - 2; i++)
            {
                switch (inputNumberValues[i])
                {
                    case 'A': number += 10 * Convert.ToInt32(Math.Pow(16, i)); break;
                    case 'B': number += 11 * Convert.ToInt32(Math.Pow(16, i)); break;
                    case 'C': number += 12 * Convert.ToInt32(Math.Pow(16, i)); break;
                    case 'D': number += 13 * Convert.ToInt32(Math.Pow(16, i)); break;
                    case 'E': number += 14 * Convert.ToInt32(Math.Pow(16, i)); break;
                    case 'F': number += 15 * Convert.ToInt32(Math.Pow(16, i)); break;
                    default: number += (int)Char.GetNumericValue(inputNumberValues[i]) * Convert.ToInt32(Math.Pow(16, i)); break;
                }
            }
            return number;
        }

        static byte[] ConvertHexadecimalToBinary(string inputNumberInHexadecimal)
        {
            StringBuilder sb = new StringBuilder();
            char[] inputNumberValues = inputNumberInHexadecimal.ToCharArray();
            //Array.Reverse(inputNumberValues);
            for (int i = 2; i < inputNumberValues.Length; i++)
            {
                switch (inputNumberValues[i])
                {
                    case '0': sb.Append("0000"); break;
                    case '1': sb.Append("0001"); break;
                    case '2': sb.Append("0010"); break;
                    case '3': sb.Append("0011"); break;
                    case '4': sb.Append("0100"); break;
                    case '5': sb.Append("0101"); break;
                    case '6': sb.Append("0110"); break;
                    case '7': sb.Append("0111"); break;
                    case '8': sb.Append("1000"); break;
                    case '9': sb.Append("1001"); break;
                    case 'A': sb.Append("1010"); break;
                    case 'B': sb.Append("1011"); break;
                    case 'C': sb.Append("1100"); break;
                    case 'D': sb.Append("1101"); break;
                    case 'E': sb.Append("1110"); break;
                    case 'F': sb.Append("1111"); break;
                }
            }
            string numberInBinaryAsString = sb.ToString().TrimStart(new char[] { '0' });
            byte[] numberInBinary = new byte[numberInBinaryAsString.Length];
            int counter = 0;
            foreach (var digit in numberInBinaryAsString)
            {
                numberInBinary[counter] = (byte)Char.GetNumericValue(digit);
                counter++;
            }
            return numberInBinary;
        }

        static string ConvertBinaryToHexadecimal(byte[] inputNumberAsBinaryArray)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("0x");
            int reminder = inputNumberAsBinaryArray.Length % 4;
            byte[] inputNumber;
            if (reminder > 0) // Lets insert the first zeroes
            {
                inputNumber = new byte[inputNumberAsBinaryArray.Length + (4 - reminder)];
                for (int i = inputNumberAsBinaryArray.Length - 1; i >= 0; i--)
                {
                    inputNumber[i + 3] = inputNumberAsBinaryArray[i];
                }
            }
            else
            {
                inputNumber = inputNumberAsBinaryArray;
            }
            for (int i = 0; i < inputNumber.Length; i += 4)
            {
                string currentBites = string.Empty;
                for (int k = 0; k < 4; k++)
                {
                    currentBites += inputNumber[i + k];
                }
                switch (currentBites)
                {
                    case "0000": sb.Append("0"); break;
                    case "0001": sb.Append("1"); break;
                    case "0010": sb.Append("2"); break;
                    case "0011": sb.Append("3"); break;
                    case "0100": sb.Append("4"); break;
                    case "0101": sb.Append("5"); break;
                    case "0110": sb.Append("6"); break;
                    case "0111": sb.Append("7"); break;
                    case "1000": sb.Append("8"); break;
                    case "1001": sb.Append("9"); break;
                    case "1010": sb.Append("A"); break;
                    case "1011": sb.Append("B"); break;
                    case "1100": sb.Append("C"); break;
                    case "1101": sb.Append("D"); break;
                    case "1110": sb.Append("E"); break;
                    case "1111": sb.Append("F"); break;
                }
            }
            return sb.ToString();
        }
    }
}
