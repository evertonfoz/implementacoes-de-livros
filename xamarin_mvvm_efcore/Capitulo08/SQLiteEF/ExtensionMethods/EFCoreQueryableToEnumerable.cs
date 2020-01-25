using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.ExtensionMethods
{
    public static class EFCoreQueryableToEnumerable
    {
        public static Task<List<T>> ToListAsyncSafe<T>(this IQueryable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (!(source is IAsyncEnumerable<T>))
                return Task.FromResult(source.ToList());
            return source.ToListAsync();
        }
    }
}
