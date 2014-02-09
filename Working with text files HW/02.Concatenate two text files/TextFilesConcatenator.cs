using System.IO;

//Write a program that concatenates two text files into another text file.
class TextFilesConcatenator
{
    static void Main(string[] args)
    {
        string firstTextDocumentData = null;
        using (StreamReader sr = new StreamReader(@"ntd1.txt"))
        {
            firstTextDocumentData = sr.ReadToEnd();
        }

        string secondTextDocumentData = null;
        using (StreamReader sr = new StreamReader(@"ntd2.txt"))
        {
            secondTextDocumentData = sr.ReadToEnd();
        }

        using (StreamWriter sw = File.CreateText(@"result.txt"))
        {
            sw.Write(firstTextDocumentData + secondTextDocumentData);
        }
    }
}
