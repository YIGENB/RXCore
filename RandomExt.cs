using System;

namespace RX
{
  public static class RandomExt
  {
    public static bool NextBool(this Random random)
    {
      return random.NextDouble() > 0.5;
    }

    public static T NextEnum<T>(this Random random) where T : struct
    {
      Type enumType = typeof (T);
      if (!enumType.IsEnum)
        throw new InvalidOperationException();
      Array values = Enum.GetValues(enumType);
      int index = random.Next(values.GetLowerBound(0), values.GetUpperBound(0) + 1);
      return (T) values.GetValue(index);
    }

    public static byte[] NextBytes(this Random random, int length)
    {
      byte[] buffer = new byte[length];
      random.NextBytes(buffer);
      return buffer;
    }

    public static DateTime NextDateTime(this Random random, DateTime minValue, DateTime maxValue)
    {
      return new DateTime(minValue.Ticks + (long) ((double) (maxValue.Ticks - minValue.Ticks) * random.NextDouble()));
    }

    public static DateTime NextDateTime(this Random random)
    {
      return random.NextDateTime(DateTime.MinValue, DateTime.MaxValue);
    }

    public static ushort NextUInt16(this Random random)
    {
      return BitConverter.ToUInt16(random.NextBytes(2), 0);
    }

    public static short NextInt16(this Random random)
    {
      return BitConverter.ToInt16(random.NextBytes(2), 0);
    }

    public static float NextFloat(this Random random)
    {
      return BitConverter.ToSingle(random.NextBytes(4), 0);
    }
  }
}
