using System;

namespace _02.OrderedMultiDictionaryImplementation
{
    public class Article : IComparable<Article>
    {
        public string barcode = null;
        public string vendor = null;
        public string title = null;
        public decimal price = 0;

        public Article(string barcode, string vendor, string title, decimal price)
        {
            this.barcode = barcode;
            this.vendor = vendor;
            this.title = title;
            this.price = price;
        }

        public int CompareTo(Article article)
        {
            return string.Compare(this.barcode, article.barcode);
        }
    }
}
