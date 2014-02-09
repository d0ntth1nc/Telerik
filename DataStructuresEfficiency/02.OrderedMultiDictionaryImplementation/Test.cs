using System;
using System.Linq;

namespace _02.OrderedMultiDictionaryImplementation
{
    /*
     * A large trade company has millions of articles, each described by barcode,
     * vendor, title and price. Implement a data structure to store them that allows
     * fast retrieval of all articles in given price range [x…y]. Hint:
     * use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET.
     */

    class Test
    {
        static void Main(string[] args)
        {
            Implementation myImplementation = new Implementation();

            myImplementation.AddProduct("732473246723", "Aleksandar", "CheeseBurger", 2.00M);
            myImplementation.AddProduct("285156215442", "Gosho", "Fish", 5.34M);
            myImplementation.AddProduct("534655435458", "Aleksandar", "CheeseBurger", 3.98M);
            myImplementation.AddProduct("837467832644", "Joro", "Kartofki", 1.99M);
            myImplementation.AddProduct("978497412849", "Jivko", "BigTasty", 9.19M);

            Console.WriteLine("Executing .FindProductsByPriceRange(1.00M, 3.00M)");
            IOrderedEnumerable<Article> foundArticles = myImplementation.FindProductsByPriceRange(1.00M, 3.00M);
            foreach (var article in foundArticles)
            {
                Console.WriteLine("Barcode: {0}, Vendor: {1}, Title: {2}, Price: {3}", article.barcode, article.vendor, article.title, article.price);
            }
        }
    }
}
