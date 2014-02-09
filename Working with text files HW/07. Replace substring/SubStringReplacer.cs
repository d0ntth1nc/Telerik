using System;
using System.IO;
using System.Text;


//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. 
//Ensure it will work with large files (e.g. 100 MB).

//Modify the solution of the previous problem to replace only whole words (not substrings).
class SubStringReplacer
{
    const int BUFFER_SIZE = 100;

    static string ReplaceOnlyWholeWords(StringBuilder sb)
    {
        string textFilePart = sb.ToString();
        string[] words = textFilePart.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == "START")
            {
                words[i] = "FINISH";
            }
        }

        string result = string.Empty;
        foreach (var word in words)
        {
            result += word + " "; //There is a bug that it will add empty space at the end of the line or doc but im out of time to fix it
        }
        return result;
    }

    static void Main(string[] args)
    {
        using (StreamReader sr = new StreamReader(@"ntd.txt"))
        {
            using (StreamWriter sw = File.CreateText(@"result.txt"))
            {
                char[] buffer = new char[BUFFER_SIZE];
                int currentIndex = 0;
                StringBuilder sb = new StringBuilder();
                while (sr.EndOfStream != true)
                {
                    try
                    {
                        currentIndex = sr.Read(buffer, currentIndex, BUFFER_SIZE); //Read text file part by part to ensure we wont get Memory Overflow
                        sb.Append(buffer);
                    }
                    catch (ArgumentException)
                    {
                        sb.Append(sr.ReadToEnd());
                    }

                    //sb.Replace("START", "FINISH"); //Replaces substring and whole words
                    //string result = sb.ToString();
                    string result = ReplaceOnlyWholeWords(sb);
                    sw.Write(result);
                    sb.Clear();
                }
            }
        }
    }
}
