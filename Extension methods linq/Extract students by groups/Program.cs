using System;
using System.Collections.Generic;
using System.Linq;

namespace Extract_students_by_groups
{
    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student() { FullName = "Petar Dimitrov", GroupName = "Group1"},
                new Student() { FullName = "Buggs Bunny", GroupName = "Group2"},
                new Student() { FullName = "No Name", GroupName = "Group2"},
                new Student() {FullName = "Smoker King", GroupName = "Group1"}
            };

            var result = GroupStudents(students);
            foreach (var group in result)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("\t" + student);
                }
            }
        }

        // 18. Create a program that extracts all students grouped by GroupName and
        // then prints them to the console. Use LINQ.
        static IEnumerable<IGrouping<string, string>> GroupStudents(List<Student> students)
        {
            var result = from student in students
                         group student.FullName by student.GroupName into g
                         select g;

            //19. using extension methods
            var resultWithExtMethods = students.GroupBy(x => x.GroupName, p => p.FullName);
            return resultWithExtMethods;
        }
    }
}
