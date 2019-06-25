using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DxControls
{
    public static class LinqExtend
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition) => condition ? source.Where(predicate) : source;
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, int, bool>> predicate, bool condition) => condition ? source.Where(predicate) : source;
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition) => condition ? source.Where(predicate) : source;
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, int, bool> predicate, bool condition) => condition ? source.Where(predicate) : source;
        public static void AddRange<T>(this ConcurrentBag<T> current, IEnumerable<T> toAdd) => toAdd.AsParallel().ForAll(t => current.Add(t));
    }
}
