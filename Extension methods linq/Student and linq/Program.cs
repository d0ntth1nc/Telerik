using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_and_linq
{
    class Program
    {
        #region Make students array
        static List<Student> students = new List<Student>() {
        new Student() { FirstName = "Pesho", LastName = "Petrov",
            FN = 475606213, Email = "pesho@abv.bg", GroupNumber = 1, Tel = "0232423",
            Marks = new List<int>() {2, 2, 3, 3, 3, 2, 3},
            Group = new Group() { DepartmentName = "Economy" }
        },

        new Student() { FirstName = "Jet", LastName = "Li",
            FN = 49385734, Email = "jetli@gmail.bg", GroupNumber = 1, Tel = "02645634",
            Marks = new List<int>() {4, 2, 6, 3, 5, 2, 3},
            Group = new Group() { DepartmentName = "IT" }
        },

        new Student() { FirstName = "Jason", LastName = "Statham",
            FN = 43782423, Email = "statham@yahoo.gr", GroupNumber = 1, Tel = "56464534",
            Marks = new List<int>() {6, 4, 4, 2, 2, 2, 5},
            Group = new Group() { DepartmentName = "IT" }
        },

        new Student() { FirstName = "Victory", LastName = "White",
            FN = 84738875, Email = "victory@abv.bg", GroupNumber = 2, Tel = "0232423",
            Marks = new List<int>() {5, 2, 3, 4, 3, 2, 3},
            Group = new Group() { DepartmentName = "Mathematics" }
        },

        new Student() { FirstName = "Borqna", LastName = "Atanasova",
            FN = 854306432, Email = "boreto@abv.bg", GroupNumber = 2, Tel = "546435",
            Marks = new List<int>() {6, 6, 6, 6, 6, 6, 6},
            Group = new Group() { DepartmentName = "Mathematics" }
        },

        new Student() { FirstName = "Ginka", LastName = "Procesova",
            FN = 546706213, Email = "process@abv.bg", GroupNumber = 2, Tel = "0232423",
            Marks = new List<int>() {5, 5, 5, 5, 5, 5, 5},
            Group = new Group() { DepartmentName = "Mathematics" }
        }};
        #endregion

        static void Main()
        {
            var studentsInSecondGroup = GetStudentsFromSecondGroup(students);
            Console.WriteLine("All students in second group:");
            Print(studentsInSecondGroup);
            Pause();

            var studentsByEmail = GetStudentsByEmail(students);
            Console.WriteLine("All students with abv.bg email:");
            Print(studentsByEmail);
            Pause();

            var studentsByPhone = GetStudentsByPhone(students);
            Console.WriteLine("All students with phones in Sofia:");
            Print(studentsByPhone);
            Pause();

            var studentsByMark = GetStudentsByMark(students);
            Console.WriteLine("All students with at least one mark 6");
            foreach (var student in studentsByMark)
            {
                Console.WriteLine(student.FullName);
            }
            Pause();

            var studentsWithTwoPoorMarks = GetStudentsWithTwoPoorMarks(students);
            Console.WriteLine("All students with two poor marks");
            Print(studentsWithTwoPoorMarks);
            Pause();

            var marksOfStudentsEnrolled2006 = ExtractMarks(students);
            Console.WriteLine("All marks of students that has enrolled 2006");
            foreach (var marks in marksOfStudentsEnrolled2006)
            {
                foreach (var mark in marks)
                {
                    Console.Write(mark);
                }
                Console.WriteLine();
            }
            Pause();

            var studentsMathematics = ExtractStudents(students);
            Console.WriteLine("All students in mathematics department");
            Print(studentsMathematics);
        }

        //Create a class student with properties FirstName, LastName, FN, Tel, Email,
        //Marks (a List<int>), GroupNumber. Create a List<Student> with sample students.
        //Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
        //Implement the previous using the same query expressed with extension methods.
        static IEnumerable<Student> GetStudentsFromSecondGroup(List<Student> students)
        {
            var resultFromQuery = from student in students
                                  where student.GroupNumber == 2
                                  orderby student.FirstName
                                  select student;
            var resultFromMethods = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);
            return resultFromQuery;
        }

        //Extract all students that have email in abv.bg. Use string methods and LINQ.
        static IEnumerable<Student> GetStudentsByEmail(List<Student> students)
        {
            var result = from student in students
                         where student.Email.Contains("abv.bg")
                         select student;
            return result;


        }

        //Extract all students with phones in Sofia. Use LINQ.
        static IEnumerable<Student> GetStudentsByPhone(List<Student> students)
        {
            var result = students.Where(new Func<Student, bool>(
                delegate(Student student)
                {
                    if (student.Tel.Substring(0, 2) == "02")
                        return true;
                    else
                        return false;
                }));
            return result;
        }

        //Select all students that have at least one mark Excellent (6) into
        //a new anonymous class that has properties – FullName and Marks. Use LINQ.
        static IEnumerable<dynamic> GetStudentsByMark(List<Student> students)
        {
            var result = from student in students
                         where student.Marks.Contains(6)
                         select new
                         {
                             FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                             Marks = student.Marks
                         };
            return result;
        }

        //Write down a similar program that extracts the students with exactly two marks "2".
        //Use extension methods.
        static IEnumerable<Student> GetStudentsWithTwoPoorMarks(List<Student> students)
        {
            var result = students.Where(new Func<Student, bool>(
                delegate(Student student)
                {
                    int occurences = student.Marks.Count(x => x == 2);
                    if (occurences == 2)
                        return true;
                    else
                        return false;
                }));
            return result;
        }

        //Extract all Marks of the students that enrolled in 2006.
        //(The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
        static IEnumerable<List<int>> ExtractMarks(List<Student> students)
        {
            var result = students.Where(new Func<Student, bool>(
                delegate(Student student)
                {
                    string fnAsString = Convert.ToString(student.FN);
                    if (fnAsString.Substring(4, 2) == "06")
                        return true;
                    else
                        return false;
                })).Select(x => x.Marks);
            return result;
        }

        //Create a class Group with properties GroupNumber and DepartmentName.
        //Introduce a property Group in the Student class.
        //Extract all students from "Mathematics" department. Use the Join operator.
        static IEnumerable<Student> ExtractStudents(List<Student> students)
        {
            string[] groups = new string[] { "Mathematics" };
            var result = from g in groups
                         join student in students
                         on g equals student.Group.DepartmentName
                         select student;
            return result;
        }

        #region Helpers
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
        #endregion
    }
}
