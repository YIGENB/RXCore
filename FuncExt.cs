using System;
using System.Collections.Generic;

namespace RX
{
  public static class FuncExt
  {
    public static IEnumerable<int> GetSequence(this Func<int, int> func, int count)
    {
      for (int index = 0; index < count; ++index)
        yield return func(index);
    }

    public static int GetFibonacci(int n)
    {
      if (n > 1)
        return FuncExt.GetFibonacci(n - 1) + FuncExt.GetFibonacci(n - 2);
      return n;
    }
  }
}
