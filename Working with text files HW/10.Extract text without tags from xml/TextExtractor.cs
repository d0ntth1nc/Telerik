using System.IO;
using System.Text;


//Write a program that extracts from given XML file all the text without the tags.
class TextExtractor
{
    static string ExtractTextFromXmlLine(string line)
    {
        string result = string.Empty;
        for (int i = 0; i < line.Length; )
        {
            int indexOfCloseTag = line.IndexOf('>', i);
            int indexOfOpenTag = line.IndexOf('<', indexOfCloseTag);
            if (indexOfCloseTag != indexOfOpenTag - 1 && indexOfCloseTag > -1 && indexOfOpenTag > -1)
            {
                result += line.Substring(indexOfCloseTag + 1, indexOfOpenTag - indexOfCloseTag - 1);
                i = indexOfOpenTag;
            }
            else
            {
                i++;
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        using (StreamReader sr = new StreamReader(@"ntd.xml"))
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                System.Console.WriteLine(ExtractTextFromXmlLine(line));
                line = sr.ReadLine();
            }
        }
    }
}
