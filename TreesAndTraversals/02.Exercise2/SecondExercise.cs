using System;
using System.Collections.Generic;
using System.IO;

namespace _02.Exercise2
{
    /*
     * Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively
     * and to display all files matching the mask *.exe. Use the class System.IO.Directory.
     */

    class SecondExercise
    {
        static List<string> fileList = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Getting files...");
            SearchDirectory("C:\\Windows");
            foreach (var item in fileList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("{0} files found", fileList.Count);
        }

        private static void SearchDirectory(string dir)
        {
            try
            {
                foreach (string directory in Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly))
                {
                    SearchDirectory(directory);
                }
            }
            catch
            {

            }
            try
            {
                foreach (string fileName in Directory.GetFiles(dir, "*.exe", SearchOption.TopDirectoryOnly))
                {
                    fileList.Add(fileName);
                }
            }
            catch
            {

            }
        }
    }
}
