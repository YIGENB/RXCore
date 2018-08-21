using System;
using System.Collections.Generic;
using System.Linq;

namespace RX
{
  public static class ClassExt
  {
    public static TResult Select<TSource, TResult>(this TSource entity, Func<TSource, TResult> selector)
    {
      return new List<TSource>() { entity }.Select<TSource, TResult>(selector).ToList<TResult>()[0];
    }

    public static bool EqualsAny<T>(this T obj, params T[] values)
    {
      return Array.IndexOf<T>(values, obj) != -1;
    }

    public static bool IsBetween<T>(this T value, T minValue, T maxValue) where T : IComparable<T>
    {
      return value.IsBetween<T>(minValue, maxValue, (IComparer<T>) null);
    }

    public static bool IsBetween<T>(this T value, T minValue, T maxValue, IComparer<T> comparer) where T : IComparable<T>
    {
      comparer = comparer ?? (IComparer<T>) Comparer<T>.Default;
      int num = comparer.Compare(minValue, maxValue);
      if (num < 0)
      {
        if (comparer.Compare(value, minValue) >= 0)
          return comparer.Compare(value, maxValue) <= 0;
        return false;
      }
      if (num == 0)
        return comparer.Compare(value, minValue) == 0;
      if (comparer.Compare(value, maxValue) >= 0)
        return comparer.Compare(value, minValue) <= 0;
      return false;
    }

    public static R Pipe<T, R>(this T o, Func<T, R> action)
    {
      T obj = o;
      return action(obj);
    }

    public static T Pipe<T>(this T o, Action<T> action)
    {
      T obj = o;
      action(obj);
      return obj;
    }

    public static bool IsDefault<T>(this T value)
    {
      return object.Equals((object) value, (object) default (T));
    }
  }
}
