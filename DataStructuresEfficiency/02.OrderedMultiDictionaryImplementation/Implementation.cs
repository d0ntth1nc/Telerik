using System.Linq;
using Wintellect.PowerCollections;

namespace _02.OrderedMultiDictionaryImplementation
{
    public class Implementation
    {
        public OrderedMultiDictionary<decimal, Article> orderedMultiDictionaryByPrice = new OrderedMultiDictionary<decimal, Article>(true);

        public IOrderedEnumerable<Article> FindProductsByPriceRange(decimal min, decimal max)
        {
            IOrderedEnumerable<Article> articles = orderedMultiDictionaryByPrice.Range(min, true, max, true).Values.OrderBy(p => p.price);

            if (!articles.Any())
            {
                return null;
            }

            return articles;
        }

        public void AddProduct(string barcode, string vendor, string title, decimal price)
        {
            Article article = new Article(barcode, vendor, title, price);
            orderedMultiDictionaryByPrice[price].Add(article);
        }
    }
}
