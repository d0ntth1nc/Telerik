using System;
using System.Text;

namespace StringBuilderExtension
{
    class Test
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("Tovaesamotest");
            Console.WriteLine(sb.Substring(8, 5));
        }
    }
}
