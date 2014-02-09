using System.Collections.Generic;
using System.IO;


//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file
class Sorter
{
    static void Main(string[] args)
    {
        List<string> txtFileLines = new List<string>();
        using (StreamReader sr = new StreamReader(@"ntd.txt"))
        {
            string currentLine = sr.ReadLine();
            while (currentLine != null)
            {
                txtFileLines.Add(currentLine);
                currentLine = sr.ReadLine();
            }
        }
        txtFileLines.Sort();

        using (StreamWriter sw = File.CreateText(@"result.txt"))
        {
            foreach (var _string in txtFileLines)
            {
                sw.WriteLine(_string);
            }
        }
    }
}
