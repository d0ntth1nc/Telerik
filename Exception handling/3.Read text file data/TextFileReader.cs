using System;
using System.IO;

namespace _3.Read_text_file_data
{
    //Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
    //reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…).
    //Be sure to catch all possible exceptions and print user-friendly error messages.
    class TextFileReader
    {
        private static string GetFileData(string inputPath)
        {
            string fileData = string.Empty;
            try
            {
                fileData = File.ReadAllText(inputPath);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Please enter path!");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The path is too long!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("There is no such directory!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("There is no such file in this directory!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("I have no rights to read the file!");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The type of the file is not supported!");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("Cannot read the file because of security");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }

            return fileData;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string inputPath = Console.ReadLine();
            string fileData = GetFileData(inputPath);
            if (fileData != string.Empty)
            {
                Console.WriteLine(fileData);
            }
        } 
    }
}
