using System;

//Write a program that prints to the console which day of the week is today. Use System.DateTime.
class Today
{
    static void Main(string[] args)
    {
        var today = DateTime.Now.DayOfWeek;
        Console.WriteLine(Convert.ToString(today));
    }
}
