using System;

//Write a program that reads a text file and prints on the console its odd lines.
class OddLinesPrinter
{
    static void Main(string[] args)
    {
        using (System.IO.StreamReader sr = new System.IO.StreamReader(@"ntd.txt"))
        {
            string textFileLine = sr.ReadLine();
            int currentLineNumber = 1;
            while (textFileLine != null)
            {
                if (currentLineNumber % 2 == 0)
                {
                    Console.WriteLine(textFileLine);
                }
                textFileLine = sr.ReadLine();
                currentLineNumber++;
            }
        }
    }
}
