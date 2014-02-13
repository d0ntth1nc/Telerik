using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerable_extensions
{
    /*
     * Implement a set of extension methods for IEnumerable<T>
     * that implement the following group functions: sum, product, min, max, average
     */
    static class Extensions
    {
        public static decimal Sum<T>(this IEnumerable<T> iEnumerable)
        {
            decimal result = 0;
            try
            {
                foreach (var item in iEnumerable)
                {
                    result += Convert.ToDecimal(item);
                }
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Cannot find sum of non numeral types");
            }
            catch (InvalidCastException)
            {
                throw new InvalidOperationException("Cannot find sum of non numeral types");
            }
            return result;
        }

        public static decimal Product<T>(this IEnumerable<T> iEnumerable)
        {
            decimal result = 1;
            try
            {
                foreach (var item in iEnumerable)
                {
                    result *= Convert.ToDecimal(item);
                }
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Cannot find product of non numeral types");
            }
            catch (InvalidCastException)
            {
                throw new InvalidOperationException("Cannot find product of non numeral types");
            }
            return result;
        }

        public static T Min<T>(this IEnumerable<T> iEnumerable) where T : IComparable
        {
            var sortedValues = iEnumerable.OrderBy(x => x);
            return sortedValues.ElementAt(0);
        }

        public static T Max<T>(this IEnumerable<T> iEnumerable) where T : IComparable
        {
            var sortedValues = iEnumerable.OrderByDescending(x => x);
            return sortedValues.ElementAt(0);
        }

        public static decimal Average<T>(this IEnumerable<T> iEnumerable)
        {
            decimal result = 0;
            try
            {
                foreach (var item in iEnumerable)
                {
                    result += Convert.ToDecimal(item);
                }
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Cannot find average of non numeral types");
            }
            catch (InvalidCastException)
            {
                throw new InvalidOperationException("Cannot find average of non numeral types");
            }
            return result / 2;
        }
    }
}
