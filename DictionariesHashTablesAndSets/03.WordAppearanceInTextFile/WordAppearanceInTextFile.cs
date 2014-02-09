using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordAppearanceInTextFile
{
    class WordAppearanceInTextFile
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"words.txt");
            using (reader)
            {
                string[] splittedWords = reader.ReadToEnd().Split(
                    new char[] { ' ', ',', '.', '?', '!', '-' }, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, byte> dictionary = new Dictionary<string, byte>();
                foreach (var word in splittedWords)
                {
                    byte occurences= 0;
                    if (dictionary.ContainsKey(word))
                    {
                        occurences = dictionary[word];
                    }
                    dictionary[word] = (byte)(occurences + 1);
                }

                var orderedWords = dictionary.OrderBy(key => key.Value);
                foreach (var word in orderedWords)
                {
                    Console.WriteLine("{0} -> {1} times", word.Key, word.Value);
                }
            }
        }
    }
}
