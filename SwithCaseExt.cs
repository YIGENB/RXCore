using System;

namespace RX
{
  public static class SwithCaseExt
  {
    public static SwithCaseExt.SwithCase<TCase, TOther> Switch<TCase, TOther>(this TCase t, Action<TOther> action) where TCase : IEquatable<TCase>
    {
      return new SwithCaseExt.SwithCase<TCase, TOther>(t, action);
    }

    public static SwithCaseExt.SwithCase<TCase, TOther> Switch<TInput, TCase, TOther>(this TInput t, Func<TInput, TCase> selector, Action<TOther> action) where TCase : IEquatable<TCase>
    {
      return new SwithCaseExt.SwithCase<TCase, TOther>(selector(t), action);
    }

    public static SwithCaseExt.SwithCase<TCase, TOther> Case<TCase, TOther>(this SwithCaseExt.SwithCase<TCase, TOther> sc, TCase option, TOther other) where TCase : IEquatable<TCase>
    {
      return sc.Case<TCase, TOther>(option, other, true);
    }

    public static SwithCaseExt.SwithCase<TCase, TOther> Case<TCase, TOther>(this SwithCaseExt.SwithCase<TCase, TOther> sc, TCase option, TOther other, bool bBreak) where TCase : IEquatable<TCase>
    {
      return sc.Case<TCase, TOther>((Predicate<TCase>) (c => c.Equals(option)), other, bBreak);
    }

    public static SwithCaseExt.SwithCase<TCase, TOther> Case<TCase, TOther>(this SwithCaseExt.SwithCase<TCase, TOther> sc, Predicate<TCase> predict, TOther other) where TCase : IEquatable<TCase>
    {
      return sc.Case<TCase, TOther>(predict, other, true);
    }

    public static SwithCaseExt.SwithCase<TCase, TOther> Case<TCase, TOther>(this SwithCaseExt.SwithCase<TCase, TOther> sc, Predicate<TCase> predict, TOther other, bool bBreak) where TCase : IEquatable<TCase>
    {
      if (sc == null)
        return (SwithCaseExt.SwithCase<TCase, TOther>) null;
      if (!predict(sc.Value))
        return sc;
      sc.Action(other);
      if (!bBreak)
        return sc;
      return (SwithCaseExt.SwithCase<TCase, TOther>) null;
    }

    public static void Default<TCase, TOther>(this SwithCaseExt.SwithCase<TCase, TOther> sc, TOther other)
    {
      if (sc == null)
        return;
      sc.Action(other);
    }

    public class SwithCase<TCase, TOther>
    {
      public TCase Value { get; private set; }

      public Action<TOther> Action { get; private set; }

      public SwithCase(TCase value, Action<TOther> action)
      {
        this.Value = value;
        this.Action = action;
      }
    }
  }
}
