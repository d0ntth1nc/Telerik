using System;
using System.IO;
using System.Text;


//Write a program that deletes from a text file all words that start with the prefix "test".
//Words contain only the symbols 0...9, a...z, A…Z, _
class WordRemover
{
    static void Main(string[] args)
    {
        StringBuilder outputString = new StringBuilder();
        using (StreamReader sr = new StreamReader(@"ntd.txt"))
        {
            string currentLine = sr.ReadLine();
            while (currentLine != null)
            {
                currentLine = CheckCurrentLine(outputString, sr, currentLine);
            }
            outputString.Remove(outputString.Length - 3, 3); //Remove the last new lines and spaces that we have added with rebuilding the lines
        }

        using (StreamWriter sw = new StreamWriter(@"ntd.txt", false))
        {
            sw.Write(outputString);
        }
    }

    private static string CheckCurrentLine(StringBuilder outputString, StreamReader sr, string currentLine)
    {
        string[] currentLineWords = currentLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in currentLineWords) // Check for prefix
        {
            if (word.Length > 4)
            {
                if (word.Substring(0, 4).ToLower() != "test")
                {
                    CheckForInvalidCharacter(outputString, word);
                }
            }
            else
            {
                CheckForInvalidCharacter(outputString, word);
            }
        }
        outputString.Append(System.Environment.NewLine);
        currentLine = sr.ReadLine();
        return currentLine;
    }

    private static void CheckForInvalidCharacter(StringBuilder outputString, string word)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var character in word)
        {
            if ((character >= '0' && character <= '9') || (Char.ToLower(character) >= 'a' && Char.ToLower(character) <= 'z')) //Check for invalid characters
            {
                sb.Append(character);
            }
            else
            {
                sb.Clear();
                break;
            }
        }
        if (sb.Length > 0)
        {
            outputString.Append(sb.ToString() + " ");
        }
    }
}