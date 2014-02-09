using System;

namespace _11.Polynomials
{
    //Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
    //	x2 + 5 = 1x2 + 0x + 5 
    //Extend the program to support also subtraction and multiplication of polynomials.
    class Sample
    {
        static void Main()
        {
            int[] first = new int[] { 5, 2, 2 };
            int[] second = new int[] { 10, -5, 6 };
            Console.Write("First polynomial:  ");
            PolynomialsCalculator.PrintPolynomials(first);
            Console.Write("Second polynomial: ");
            PolynomialsCalculator.PrintPolynomials(second);

            Console.Write("Sum:               ");
            PolynomialsCalculator.PrintPolynomials(PolynomialsCalculator.SumPolynomials(first, second));

            Console.Write("Substraction:      ");
            PolynomialsCalculator.PrintPolynomials(PolynomialsCalculator.SubstractPolynomials(first, second));
            
            Console.Write("Multiply:          ");
            PolynomialsCalculator.PrintPolynomials(PolynomialsCalculator.MultiplyPolynomials(first, second));
        }
    }
}
