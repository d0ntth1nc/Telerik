using System;
using System.Collections.Generic;
using System.IO;

namespace DataStructuresEfficiency
{
    /*A text file students.txt holds information about students and their courses in the following format:
    Kiril  | Ivanov   | C#
    Stefka | Nikolova | SQL
    Stela  | Mineva   | Java
    Milena | Petrova  | C#
    Ivan   | Grigorov | C#
    Ivan   | Kolev    | SQL

	Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints 
    the students ordered by family and then by name:
    C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
    Java: Stela Mineva
    SQL: Ivan Kolev, Stefka Nikolova
    */
    class Implementation
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> textFileDictionary = new SortedDictionary<string, SortedSet<string>>();
            List<string[]> namesAndCourses = GetNamesAndCoursesArray();
            foreach (var textPart in namesAndCourses)
            {
                if (textFileDictionary.ContainsKey(textPart[1]))
                {
                    textFileDictionary[textPart[1]].Add(textPart[0]);
                }
                else
                {
                    SortedSet<string> sortedNames = new SortedSet<string>();
                    sortedNames.Add(textPart[0]);
                    textFileDictionary.Add(textPart[1], sortedNames);
                }
            }
            foreach (var element in textFileDictionary)
            {
                Console.Write("{0}: ", element.Key);
                foreach (var name in element.Value)
                {
                    Console.Write("{0}  ", name);
                }
                Console.WriteLine();
            }
        }

        private static List<string[]> GetNamesAndCoursesArray()
        {
            StreamReader textFileReader = new StreamReader("students.txt");
            List<string[]> namesAndCourses = new List<string[]>();
            while (!textFileReader.EndOfStream)
            {
                string textFileLine = textFileReader.ReadLine();
                string[] textLineParts = textFileLine.Split('|');
                for (int i = 0; i < textLineParts.Length; i++)
                {
                    textLineParts[i] = textLineParts[i].Trim();
                }
                namesAndCourses.Add(new string[] { textLineParts[0] + " " + textLineParts[1], textLineParts[2] });
            }
            return namesAndCourses;
        }
    }
}
