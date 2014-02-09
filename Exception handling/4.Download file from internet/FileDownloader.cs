using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _4.Download_file_from_internet
{
    //Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg)
    //and stores it the current directory. Find in Google how to download files in C#.
    //Be sure to catch all exceptions and to free any used resources in the finally block.
    class FileDownloader
    {
        static string fileName = string.Empty;

        static void DownloadFile(string urlAsString)
        {
            using (WebClient Client = new WebClient())
            {
                try
                {
                    System.Uri url = new Uri(urlAsString);
                    string fileName = Path.GetFileName(url.LocalPath); ;
                    Client.DownloadFile(url, fileName);
                    Console.WriteLine("File download completed!");

                }
                catch (UriFormatException)
                {
                    Console.WriteLine("Please enter valid url!");
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine("Requested url is not supported!");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter url: ");

            string url = Console.ReadLine();
            DownloadFile(url);
        }
    }
}
