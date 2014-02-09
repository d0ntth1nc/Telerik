using System.IO;
using System.Text;


//Write a program that deletes from given text file all odd lines. The result should be in the same file.
class OddLinesRemover
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        using (StreamReader sr = new StreamReader(@"ntd.txt"))
        {
            int currentLineNumber = 1;
            string currentLine = sr.ReadLine();
            while (currentLine != null)
            {
                if (currentLineNumber % 2 == 0)
                {
                    sb.AppendLine(currentLine);
                }
                currentLineNumber++;
                currentLine = sr.ReadLine();
            }
            sb.Remove(sb.Length - 1, 1);
        }

        using (StreamWriter sw = new StreamWriter(@"ntd.txt", false))
        {
            sw.Write(sb.ToString());
        }
    }
}
