using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BettingSystem.Services
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ExceptSelect<T, TSelect>(this IEnumerable<T> source,
            IEnumerable<T> exceptions, Func<T, TSelect> selector)
        {
            source.Select(selector).Print();
            Console.WriteLine(" - ");
            var exceptSelections = exceptions.Select(selector);
            exceptSelections.Print();
            Console.WriteLine(" = ");
            var result = source.Where(x => !exceptSelections.Contains(selector(x)));
            result.Select(selector).Print();
            return result;
        }
        
        public static IEnumerable<T> IntersectSelect<T, TSelect>(this IEnumerable<T> first,
            IEnumerable<T> second, Func<T, TSelect> selector)
        {
            var secondSelections = second.Select(selector);
            return first.Where(x => secondSelections.Contains(selector(x)));
        }

        private static void Print<T>(this IEnumerable<T> source)
        {
            Console.WriteLine(string.Join(",",source));
        }

        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            items.ToList().ForEach(source.Add);
        }
        
        public static void RemoveRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            items.ToList().ForEach(x=>source.Remove(x));
        }
    }
}