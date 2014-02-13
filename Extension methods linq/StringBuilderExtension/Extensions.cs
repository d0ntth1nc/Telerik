using System.Text;

namespace StringBuilderExtension
{
    public static class Extensions
    {
        /// <summary>
        /// 01. Implement an extension method Substring(int index, int length)
        /// for the class StringBuilder that returns new StringBuilder and
        /// has the same functionality as Substring in the class String
        /// </summary>
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = index; i < length + index; i++)
            {
                stringBuilder.Append(sb[i]);
            }
            return stringBuilder;
        }
    }
}
