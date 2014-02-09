using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.Exercise
{
    class ThirdExercise
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Building dir tree...");
            var rootFolder = new Folder("C:\\Windows");
            rootFolder = BuildTree(rootFolder);
            Console.WriteLine("Directory tree is ready!");

            char splash = '\u005C';
            Console.Write("Enter the path to subdir to sum the file size (use {0} or enter empty line for root dir): ", splash);
            string selectedDir = Console.ReadLine();
            Folder selectedFolder = rootFolder;
            if (selectedDir != string.Empty)
            {
                string[] folders = selectedDir.Split('\\');
                foreach (var folder in folders)
                {
                    selectedFolder = selectedFolder.childFolders.Single(x => x.name == selectedFolder.name + "\\" + folder);
                }
            }
            Console.WriteLine("Calculating files size sum...");
            long sum = CalculateFileSizesOfSubTree(selectedFolder);
            Console.WriteLine("Files size sum in bytes: {0} bytes", sum);
            Console.ReadLine();
        }

        static Folder BuildTree(Folder rootFolder)
        {
            rootFolder = SearchForSubFiles(rootFolder);
            rootFolder = SearchForSubDirectories(rootFolder);

            try
            {
                for (int i = 0; i < rootFolder.childFolders.Length; i++)
                {
                    rootFolder.childFolders[i] = BuildTree(rootFolder.childFolders[i]);
                }
            }
            catch
            {

            }
            return rootFolder;
        }

        static Folder SearchForSubFiles(Folder rootFolder)
        {
            string[] files = null;
            try
            {
                files = Directory.GetFiles(rootFolder.name, "*", SearchOption.TopDirectoryOnly);
            }
            catch
            {

            }

            try
            {
                List<File> filesList = new List<File>();
                foreach (var file in files)
                {
                    File newFile = new File();
                    newFile.name = file;
                    FileInfo fileInfo = new FileInfo(file);
                    newFile.size = (int)fileInfo.Length;
                    filesList.Add(newFile);
                }
                rootFolder.files = filesList.ToArray();
            }
            catch
            {

            }
            
            return rootFolder;
        }

        static Folder SearchForSubDirectories(Folder rootFolder)
        {
            string[] subDirs = null;
            try
            {
                subDirs = Directory.GetDirectories(rootFolder.name, "*", SearchOption.TopDirectoryOnly);
            }
            catch
            {

            }
            try
            {
                List<Folder> folderList = new List<Folder>();
                foreach (var folder in subDirs)
                {
                    Folder newFolder = new Folder(folder);
                    folderList.Add(newFolder);
                }
                rootFolder.childFolders = folderList.ToArray();
            }
            catch
            {

            }

            return rootFolder;
        }

        static Int64 CalculateFileSizesOfSubTree(Folder subFolder)
        {
            long sum = 0;
            try
            {
                foreach (var file in subFolder.files)
                {
                    sum += file.size;
                }

                foreach (var folder in subFolder.childFolders)
                {
                    sum += CalculateFileSizesOfSubTree(folder);
                }
            }
            catch
            {

            }
            return sum;
        }
    }
}
