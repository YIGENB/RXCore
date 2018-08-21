using RX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace RX
{
  public static class TypeConversionExt
  {

    public static bool IsNotNullOrDBNull(this object Object)
    {
      if (Object != null)
        return !Convert.IsDBNull(Object);
      return false;
    }

    public static bool IsNullOrDBNull(this object Object)
    {
      if (Object != null)
        return Convert.IsDBNull(Object);
      return true;
    }

    public static T NullCheck<T>(this T Object)
    {
      return Object.NullCheck<T>(default (T));
    }

    public static T NullCheck<T>(this T Object, T DefaultValue)
    {
      if ((object) Object != null)
        return Object;
      return DefaultValue;
    }

    public static void ThrowIfNull(this object Item, string Name)
    {
      if (Item.IsNull())
        throw new ArgumentNullException(Name);
    }
    public static void ThrowIfNullOrDBNull(this object Item, string Name)
    {
      if (Item.IsNullOrDBNull())
        throw new ArgumentNullException(Name);
    }


    public static DbType ToDbType(this Type Type)
    {
      if (Type == typeof (byte))
        return DbType.Byte;
      if (Type == typeof (sbyte))
        return DbType.SByte;
      if (Type == typeof (short))
        return DbType.Int16;
      if (Type == typeof (ushort))
        return DbType.UInt16;
      if (Type == typeof (int))
        return DbType.Int32;
      if (Type == typeof (uint))
        return DbType.UInt32;
      if (Type == typeof (long))
        return DbType.Int64;
      if (Type == typeof (ulong))
        return DbType.UInt64;
      if (Type == typeof (float))
        return DbType.Single;
      if (Type == typeof (double))
        return DbType.Double;
      if (Type == typeof (Decimal))
        return DbType.Decimal;
      if (Type == typeof (bool))
        return DbType.Boolean;
      if (Type == typeof (string))
        return DbType.String;
      if (Type == typeof (char))
        return DbType.StringFixedLength;
      if (Type == typeof (Guid))
        return DbType.Guid;
      if (Type == typeof (DateTime))
        return DbType.DateTime2;
      if (Type == typeof (DateTimeOffset))
        return DbType.DateTimeOffset;
      if (Type == typeof (byte[]))
        return DbType.Binary;
      if (Type == typeof (byte?))
        return DbType.Byte;
      if (Type == typeof (sbyte?))
        return DbType.SByte;
      if (Type == typeof (short?))
        return DbType.Int16;
      if (Type == typeof (ushort?))
        return DbType.UInt16;
      if (Type == typeof (int?))
        return DbType.Int32;
      if (Type == typeof (uint?))
        return DbType.UInt32;
      if (Type == typeof (long?))
        return DbType.Int64;
      if (Type == typeof (ulong?))
        return DbType.UInt64;
      if (Type == typeof (float?))
        return DbType.Single;
      if (Type == typeof (double?))
        return DbType.Double;
      if (Type == typeof (Decimal?))
        return DbType.Decimal;
      if (Type == typeof (bool?))
        return DbType.Boolean;
      if (Type == typeof (char?))
        return DbType.StringFixedLength;
      if (Type == typeof (Guid?))
        return DbType.Guid;
      if (Type == typeof (DateTime?))
        return DbType.DateTime2;
      return Type == typeof (DateTimeOffset?) ? DbType.DateTimeOffset : DbType.Int32;
    }

    public static Type ToType(this DbType Type)
    {
      if (Type == DbType.Byte)
        return typeof (byte);
      if (Type == DbType.SByte)
        return typeof (sbyte);
      if (Type == DbType.Int16)
        return typeof (short);
      if (Type == DbType.UInt16)
        return typeof (ushort);
      if (Type == DbType.Int32)
        return typeof (int);
      if (Type == DbType.UInt32)
        return typeof (uint);
      if (Type == DbType.Int64)
        return typeof (long);
      if (Type == DbType.UInt64)
        return typeof (ulong);
      if (Type == DbType.Single)
        return typeof (float);
      if (Type == DbType.Double)
        return typeof (double);
      if (Type == DbType.Decimal)
        return typeof (Decimal);
      if (Type == DbType.Boolean)
        return typeof (bool);
      if (Type == DbType.String)
        return typeof (string);
      if (Type == DbType.StringFixedLength)
        return typeof (char);
      if (Type == DbType.Guid)
        return typeof (Guid);
      if (Type == DbType.DateTime2)
        return typeof (DateTime);
      if (Type == DbType.DateTime)
        return typeof (DateTime);
      if (Type == DbType.DateTimeOffset)
        return typeof (DateTimeOffset);
      if (Type == DbType.Binary)
        return typeof (byte[]);
      return typeof (int);
    }

    public static R TryTo<T, R>(this T Object)
    {
      return Object.TryTo<T, R>(default (R));
    }

    public static R TryTo<T, R>(this T Object, R DefaultValue)
    {
      try
      {
        if (((object) Object).IsNullOrDBNull())
          return DefaultValue;
        if (((object) Object as string).IsNotNull())
        {
          string s = (object) Object as string;
          if (typeof (R).IsEnum)
            return (R) Enum.Parse(typeof (R), s, true);
          if (String.IsNullOrEmpty(s))
            return DefaultValue;
        }
        if (((object) Object as IConvertible).IsNotNull())
          return (R) Convert.ChangeType((object) Object, typeof (R));
        if (typeof (R).IsAssignableFrom(Object.GetType()))
          return (R) (object) Object;
        TypeConverter converter = TypeDescriptor.GetConverter(Object.GetType());
        if (converter.CanConvertTo(typeof (R)))
          return (R) converter.ConvertTo((object) Object, typeof (R));
        if (((object) Object as string).IsNotNull())
          return Object.ToString().TryTo<string, R>(DefaultValue);
      }
      catch
      {
      }
      return DefaultValue;
    }
  }
}
