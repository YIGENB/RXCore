using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RX
{
  public static class WhereIfExt
  {
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
    {
      if (!condition)
        return source;
      return source.Where<T>(predicate);
    }

    public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, int, bool>> predicate, bool condition)
    {
      if (!condition)
        return source;
      return source.Where<T>(predicate);
    }

    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
    {
      if (!condition)
        return source;
      return source.Where<T>(predicate);
    }

    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, int, bool> predicate, bool condition)
    {
      if (!condition)
        return source;
      return source.Where<T>(predicate);
    }
  }
}
