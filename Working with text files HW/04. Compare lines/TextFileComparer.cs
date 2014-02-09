using System;
using System.IO;


//Write a program that compares two text files line by line and prints the number of
//lines that are the same and the number of lines that are different. 
//Assume the files have equal number of lines
class TextFileComparer
{
    static void Main(string[] args)
    {
        int sameLinesCount = 0;
        int differentLinesCount = 0;
        Compare(ref sameLinesCount, ref differentLinesCount);
        Console.WriteLine("Same lines count: {0}, Different lines count: {1}", sameLinesCount, differentLinesCount);
    }

    private static void Compare(ref int sameLinesCount, ref int differentLinesCount)
    {
        using (StreamReader firstTextFileReader = new StreamReader(@"ntd1.txt"))
        {
            using (StreamReader secondTextFileReader = new StreamReader(@"ntd2.txt"))
            {
                string firstTxtFileLine = firstTextFileReader.ReadLine();
                string secondTxtFileLine = secondTextFileReader.ReadLine();

                while (true)
                {
                    if (firstTxtFileLine == null)
                    {
                        if (secondTxtFileLine == null)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("Text files doesnt have equal lines");
                        }
                    }
                    else
                    {
                        if (secondTxtFileLine == null)
                        {
                            throw new Exception("Text files doesnt have equal lines");
                        }
                        else
                        {
                            if (firstTxtFileLine == secondTxtFileLine)
                            {
                                sameLinesCount++;
                            }
                            else
                            {
                                differentLinesCount++;
                            }
                            firstTxtFileLine = firstTextFileReader.ReadLine();
                            secondTxtFileLine = secondTextFileReader.ReadLine();
                        }
                    }
                }
            }
        }
    }
}