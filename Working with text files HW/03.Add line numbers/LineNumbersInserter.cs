using System.IO;

//Write a program that reads a text file and inserts line numbers in front of each of its lines.
//The result should be written to another text file.
class LineNumbersInserter
{
    static void Main(string[] args)
    {
        using (StreamReader sr = new StreamReader(@"ntd.txt"))
        {
            using (StreamWriter sw = File.CreateText(@"result.txt"))
            {
                string currentLine = sr.ReadLine();
                int lineNumber = 1;
                while (currentLine != null)
                {
                    if (lineNumber != 1)
                    {
                        sw.Write(System.Environment.NewLine);
                    }

                    sw.Write("{0}.{1}", lineNumber, currentLine);
                    lineNumber++;
                    currentLine = sr.ReadLine();
                }
            }
        }
    }
}
