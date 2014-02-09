using System;
using System.Linq;

//Write a method that calculates the number of workdays between today and given date, passed as parameter. 
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
class Program
{
    static int CalculateWorkDays(DateTime givenDate, DateTime[] publicHolydays)
    {
        int workDays = 0;
        var currentDate = DateTime.Now.Date;
        currentDate = currentDate.AddDays(1);
        while (currentDate.Date < givenDate.Date)
        {
            if (!publicHolydays.Contains(currentDate.Date) && currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
            {
                workDays++;
            }
            currentDate = currentDate.AddDays(1);
        }
        return workDays;
    }

    static void Main(string[] args)
    {
        DateTime[] holydays = new DateTime[] { new DateTime(2014, 1, 15) };
        int workDays = CalculateWorkDays(new DateTime(2014, 1, 20), holydays);
        Console.WriteLine(workDays);
    }
}
