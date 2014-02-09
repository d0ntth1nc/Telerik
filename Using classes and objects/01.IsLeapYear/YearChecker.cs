using System;

class YearChecker
{
    static void Main(string[] args)
    {
        int year = int.Parse(Console.ReadLine());
        bool isLeap = DateTime.IsLeapYear(year);
        Console.WriteLine("{0} is leap? -> {1}", year, isLeap);
    }
}
