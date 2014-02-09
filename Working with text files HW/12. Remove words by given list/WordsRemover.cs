using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


//Write a program that removes from a text file all words listed in given another text file.
//Handle all possible exceptions in your methods
class WordsRemover
{
    static void Main(string[] args)
    {
        HashSet<string> listOfGivenWords = new HashSet<string>();
        StringBuilder output = new StringBuilder();
        GetWordsList(listOfGivenWords);
        RemoveWords(listOfGivenWords, output);
        UpdateFile(output);
    }

    private static void UpdateFile(StringBuilder sb)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(@"textfile.txt", false)) //Update file
            {
                try
                {
                    sw.Write(sb);
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (PathTooLongException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (System.Security.SecurityException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void RemoveWords(HashSet<string> listOfGivenWords, StringBuilder output)
    {
        try
        {
            using (StreamReader textFile = new StreamReader(@"textfile.txt"))
            {
                CheckLines(listOfGivenWords, output, textFile);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void CheckLines(HashSet<string> listOfGivenWords, StringBuilder output, StreamReader textFile)
    {
        HashSet<char> punctiationMarks = new HashSet<char>() { ',', '.', ';', ':', '!', '?' };
        try
        {
            string currentLine = textFile.ReadLine();
            while (currentLine != null)
            {
                string[] splittedLineWords = currentLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in splittedLineWords)
                {
                    if (punctiationMarks.Contains(word[word.Length - 1])) //Check for punctuation mark so we can ignore it
                    {
                        if (!listOfGivenWords.Contains(word.Substring(0, word.Length - 1)))
                        {
                            output.Append(word);
                        }
                    }
                    else
                    {
                        if (!listOfGivenWords.Contains(word))
                        {
                            output.Append(word);
                        }
                    }
                    output.Append(" ");
                }
                output.Remove(output.Length - 1, 1); //Remove the last space from the line
                output.Append(System.Environment.NewLine); //Add new line to the output
                currentLine = textFile.ReadLine(); //Read next line
            }
            output.Remove(output.Length - 1, 1); //Remove the last "new line" from the output
        }
        catch (OutOfMemoryException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void GetWordsList(HashSet<string> listOfGivenWords)
    {
        try
        {
            using (StreamReader sr = new StreamReader(@"wordslist.txt"))
            {
                try
                {
                    string currentLine = sr.ReadLine();
                    while (currentLine != null)
                    {               //I wont check for text, written by "тъпак", since it's not a condition of the task
                        //If i do, the code is going to be 2 times bigger and the main subject is will fly away
                        string[] splittedWords = currentLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var word in splittedWords)
                        {
                            listOfGivenWords.Add(word);
                        }
                        currentLine = sr.ReadLine();
                    }
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}