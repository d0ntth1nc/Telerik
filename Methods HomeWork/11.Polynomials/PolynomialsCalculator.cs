using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Polynomials
{
    //Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
    //	x2 + 5 = 1x2 + 0x + 5 
    //Extend the program to support also subtraction and multiplication of polynomials.
    public static class PolynomialsCalculator
    {
        public static void PrintPolynomials(int[] polynomial)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = polynomial.Length - 1; i >= 0; i--)
            {
                if (polynomial[i] != 0) //We dont print when the coefficient of x is equal to 0
                {
                    bool isNegative = polynomial[i] < 0;
                    int polynomialValue = isNegative ? ~polynomial[i] + 1 : polynomial[i];
                    if (i != 0)
                    {
                        bool isFirstElement = (i == polynomial.Length - 1);
                        bool hasCoefficientEqualToOne = polynomial[i] == 1;
                        if (isNegative)
                        {
                            sb.Append(isFirstElement ? "-" : " - ");
                        }
                        else
                        {
                            sb.Append(isFirstElement ? string.Empty : " + ");
                        }
                        sb.AppendFormat(hasCoefficientEqualToOne ? "x" : "{0}x", polynomialValue);

                        if (i != 1)
                        {
                            sb.AppendFormat("^{0}", i);
                        }
                    }
                    else
                    {
                        sb.AppendFormat(isNegative ? " - {0}" : " + {0}", polynomialValue);
                    }
                }
            }
            Console.WriteLine(sb.ToString());
        }

        public static int[] SumPolynomials(int[] firstPolynomial, int[] secondPolynomial)
        {
            bool firstPolynomialIsBigger = (firstPolynomial.Length > secondPolynomial.Length);
            int maxLength = firstPolynomialIsBigger ? firstPolynomial.Length : secondPolynomial.Length;
            int[] result = new int[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                try
                {
                    result[i] = firstPolynomial[i] + secondPolynomial[i];
                }
                catch
                {
                    result[i] = firstPolynomialIsBigger ? firstPolynomial[i] : secondPolynomial[i];
                    continue;
                }
            }
            return result;
        }

        public static int[] SubstractPolynomials(int[] firstPolynomial, int[] secondPolynomial)
        {
            bool firstPolynomialIsBigger = (firstPolynomial.Length > secondPolynomial.Length);
            int maxLength = firstPolynomialIsBigger ? firstPolynomial.Length : secondPolynomial.Length;
            int[] result = new int[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                try
                {
                    result[i] = firstPolynomial[i] - secondPolynomial[i];
                }
                catch
                {
                    result[i] = firstPolynomialIsBigger ? firstPolynomial[i] : secondPolynomial[i];
                    continue;
                }
            }
            return result;
        }

        public static int[] MultiplyPolynomials(int[] firstPolynomial, int[] secondPolynomial)
        {
            bool firstPolynomialIsBigger = (firstPolynomial.Length > secondPolynomial.Length);
            int maxLength = firstPolynomialIsBigger ? firstPolynomial.Length : secondPolynomial.Length;
            int[] result = new int[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                try
                {
                    result[i] = firstPolynomial[i] * secondPolynomial[i];
                }
                catch
                {
                    result[i] = firstPolynomialIsBigger ? firstPolynomial[i] : secondPolynomial[i];
                    continue;
                }
            }
            return result;
        }
    }
}
