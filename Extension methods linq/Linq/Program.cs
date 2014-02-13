using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]
            {
                new Student{ FirstName = "Petur", LastName = "Georgiev", Age = 12},
                new Student{ FirstName = "Aleksandur", LastName = "Cyrus", Age = 18},
                new Student{ FirstName = "Zet", LastName = "Li", Age = 23},
                new Student{ FirstName = "Bill", LastName = "Gates", Age = 120},
            };

            var selectedByName = ByName(students);
            Console.WriteLine("Selected by first name then by last name");
            Print(selectedByName);
            Pause();

            var selectedByAge = ByAge(students);
            Console.WriteLine("Age between 18 and 24");
            Print(selectedByAge);
            Pause();

            var sortedByNames = SortByNames(students);
            Console.WriteLine("Sorted by first name then by last name");
            Print(sortedByNames);
            Pause();

            int[] array = new int[] { 1, 2, 3, 21, 5, 6, 7, 8, 9};
            var result = ExtractDivisibleBySevenAndThree(array);
            Console.WriteLine("Divisible by 7 and 3");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        //Write a method that from a given array of students finds all students
        //whose first name is before its last name alphabetically. Use LINQ query operators
        private static IEnumerable<Student> ByName(Student[] students)
        {
            var validResults = from student in students
                               where student.FirstName.CompareTo(student.LastName) < 0
                               select student;
            return validResults;
        }

        //Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
        private static IEnumerable<Student> ByAge(Student[] students)
        {
            var validResults = from student in students
                               where student.Age >= 18 && student.Age <= 24
                               select student;
            return validResults;
        }

        //Using the extension methods OrderBy() and ThenBy() with
        //lambda expressions sort the students by first name and last name in
        //descending order. Rewrite the same with LINQ
        private static IEnumerable<Student> SortByNames(Student[] students)
        {
            var sortedByMethods = students.OrderByDescending(
            student => student.FirstName).ThenBy(student => student.LastName);

            var sortedByQuery = from student in students
                         orderby student.FirstName, student.LastName descending
                         select student;

            return sortedByQuery;
        }

        //Write a program that prints from given array of integers all numbers that
        //are divisible by 7 and 3. Use the built-in extension methods and
        //lambda expressions. Rewrite the same with LINQ.
        private static IEnumerable<Int32> ExtractDivisibleBySevenAndThree(int[] array)
        {
            var result = array.Where(x => (x % 3 == 0) && (x % 7 == 0));
            var resultByQuery = from integer in array
                                where (integer % 3 == 0) && (integer % 7 == 0)
                                select integer;
            return resultByQuery;
        }

        private static void Pause()
        {
            Console.ReadKey();
            Console.Clear();
        }

        private static void Print(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}
