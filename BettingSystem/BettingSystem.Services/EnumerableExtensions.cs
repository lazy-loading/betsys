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
            var exceptSelections = exceptions.Select(selector);
            var result = source.Where(x => !exceptSelections.Contains(selector(x)));
            return result;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
        
        public static IEnumerable<T> IntersectSelect<T, TSelect>(this IEnumerable<T> first,
            IEnumerable<T> second, Func<T, TSelect> selector)
        {
            var secondSelections = second.Select(selector);
            return first.Where(x => secondSelections.Contains(selector(x)));
        }

        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                source.Add(item);
            }
        }
        
        public static void RemoveRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                source.Remove(item);
            }
        }
    }
}