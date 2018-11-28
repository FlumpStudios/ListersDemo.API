using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;

namespace ListersDemo.API.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> list, string orderBy, bool isDecending = false)
        {
            if (list == null) return null;
            if (string.IsNullOrEmpty(orderBy)) return list;

            if (isDecending) orderBy += " descending";
            list = list.AsQueryable().OrderBy(orderBy);
            return list;
        }
    }
}
