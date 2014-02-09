using System;

//You are given a sequence of positive integer values written into a string, separated by spaces.
//Write a function that reads these values from given string and calculates their sum.
class Calculator
{
    static double Calculate(string numbers)
    {
        string[] numbersAsArray = numbers.Split(null);
        double result = 0;
        foreach (var number in numbersAsArray)
        {
            result += Convert.ToDouble(number);
        }
        return result;
    }

    static void Main(string[] args)
    {
        string numbers = "2 3 4 5";
        Console.WriteLine(Calculate(numbers));
    }
}
