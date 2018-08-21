using System;

namespace RX
{
  public static class IntExt
  {
    public static bool IsAbs(this int i)
    {
      return i > 0;
    }

    public static bool IsInt(this string s)
    {
      int result;
      return int.TryParse(s, out result);
    }

    public static int ToInt(this string s)
    {
      return int.Parse(s);
    }

    public static int ToInt32(this string s)
    {
      int result;
      int.TryParse(s, out result);
      return result;
    }

    public static long ToInt64(this string s)
    {
      long result;
      long.TryParse(s, out result);
      return result;
    }

    public static bool IsInt64(this string s)
    {
      long result;
      return long.TryParse(s, out result);
    }

    public static short ToInt16(this string s)
    {
      short result;
      short.TryParse(s, out result);
      return result;
    }

    public static bool IsInt16(this string s)
    {
      short result;
      return short.TryParse(s, out result);
    }

    public static double ToDouble(this string s)
    {
      double result;
      double.TryParse(s, out result);
      return result;
    }

    public static bool IsDouble(this string s)
    {
      double result;
      return double.TryParse(s, out result);
    }

    public static Decimal ToDecimal(this string s)
    {
      Decimal result;
      Decimal.TryParse(s, out result);
      return result;
    }

    public static bool IsDecimal(this string s)
    {
      Decimal result;
      return Decimal.TryParse(s, out result);
    }

    public static float ToFloat(this string s)
    {
      float result;
      float.TryParse(s, out result);
      return result;
    }

    public static bool IsFloat(this string s)
    {
      float result;
      return float.TryParse(s, out result);
    }
  }
}
