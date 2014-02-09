using System;
using System.Collections.Generic;
using System.IO;


/*
 * Write a program that reads a list of words from a file words.txt and finds how many times each of
 * the words is contained in another file test.txt. The result should be written in the file result.txt and
 * the words should be sorted by the number of their occurrences in descending order.
 * Handle all possible exceptions in your methods.
 */
class OccurencesFinder
{
    private static int[] ReadWordsList(Dictionary<string, int> givenWordsAsKeys, Dictionary<int, string> givenWordsAsValues)
    {
        try
        {
            using (StreamReader textFile = new StreamReader(@"words.txt"))
            {
                return ExtractWords(givenWordsAsKeys, givenWordsAsValues, textFile);
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
        return null;
    }

    private static int[] ExtractWords(Dictionary<string, int> givenWordsAsKeys, Dictionary<int, string> givenWordsAsValues, StreamReader textFile)
    {
        try
        {
            int wordIndex = 0;
            string word = textFile.ReadLine();
            while (word != null)
            {
                givenWordsAsKeys.Add(word, wordIndex);
                givenWordsAsValues.Add(wordIndex, word);
                word = textFile.ReadLine();
                wordIndex++;
            }
            return new int[wordIndex];
        }
        catch (OutOfMemoryException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return null;
    }

    private static void CheckFile(Dictionary<string, int> givenWordsAsKeys, int[] occurences)
    {
        try
        {
            using (StreamReader textFile = new StreamReader(@"textfile.txt"))
            {
                CheckLines(givenWordsAsKeys, occurences, textFile);
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

    private static void CheckLines(Dictionary<string, int> givenWordsAsKeys, int[] occurences, StreamReader textFile)
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
                        string trimmedWord = word.Substring(0, word.Length - 1);
                        if (givenWordsAsKeys.ContainsKey(trimmedWord))
                        {
                            occurences[givenWordsAsKeys[trimmedWord]]++;
                        }
                    }
                    else
                    {
                        if (givenWordsAsKeys.ContainsKey(word))
                        {
                            occurences[givenWordsAsKeys[word]]++;
                        }
                    }
                }
                currentLine = textFile.ReadLine(); //Read next line
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

    private static void WriteResultFile(Dictionary<int, string> givenWordsAsValues, int[] occurences)
    {
        try
        {
            using (StreamWriter newTextFile = File.CreateText(@"result.txt"))
            {
                try
                {
                    for (int i = occurences.Length - 1; i >= 0; i--)
                    {
                        //We already know that occurences array is not null
                        string givenWord = givenWordsAsValues[i];
                        newTextFile.WriteLine("{0} -> {1}", givenWord, occurences[i]);
                    }
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
        catch (NotSupportedException ex)
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
    }

    static void Main(string[] args)
    {
        Dictionary<string, int> givenWordsAsKeys = new Dictionary<string, int>();
        Dictionary<int, string> givenWordsAsValues = new Dictionary<int, string>();
        int[] occurences = null;
        occurences = ReadWordsList(givenWordsAsKeys, givenWordsAsValues);
        if (occurences != null)
        {
            CheckFile(givenWordsAsKeys, occurences);
            Array.Sort(occurences);
            WriteResultFile(givenWordsAsValues, occurences);
        }
    }
}
