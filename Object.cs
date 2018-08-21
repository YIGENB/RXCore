using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RX
{
    public static class Object
    {
        /// <summary>
        /// 赋默认值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string DefaultValue(this object obj, object val)
        {
            if (obj == null)
                return val.ToString();
            if (string.IsNullOrEmpty(obj.ToString()))
                return val.ToString();
            return obj.ToString();
        }

        /// <summary>
        /// 赋默认值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int DefaultValue(this object obj, object val, int flag)
        {
            if (obj == null)
                return int.Parse(val.ToString());

            return int.Parse(obj.ToString());
        }

        public static bool IsNull(this object o)
        {
            return (o == null);
        }

        public static bool IsNotNull(this object o)
        {
            return (o != null);
        }


        public static bool IsDBNull(this object obj)
        {
            return obj.IsType(typeof(DBNull));
        }

        public static bool IsType(this object obj, Type type)
        {
            return obj.GetType().Equals(type);
        }

        public static bool IsNullOrEmpty(this object o)
        {
            if (!o.IsNull())
            {
                return o.ToString().IsNullOrEmpty();
            }
            return true;
        }
        public static bool IsArray(this object obj)
        {
            return obj.IsType(typeof(Array));
        }

        public static short ToInt16(this object o)
        {
            short num = 0;
            if (!o.IsNullOrEmpty())
            {
                num = o.ToString().ToInt16();
            }
            return num;
        }


        public static int ToInt32(this object o)
        {
            int num = 0;
            if (!o.IsNullOrEmpty())
            {
                num = o.ToString().ToInt32();
            }
            return num;
        }
        public static long ToInt64(this object o)
        {
            long num = 0L;
            if (!o.IsNullOrEmpty())
            {
                num = o.ToString().ToInt64();
            }
            return num;
        }


        public static int ToInteger(this object strValue)
        {
            return strValue.ToInteger(0);
        }


        public static int ToInteger(this object strValue, int defValue)
        {
            int result = 0;
            int.TryParse(strValue.ToString(), out result);
            if (result != 0)
            {
                return result;
            }
            return defValue;
        }


        public static decimal ToMoney(this object strValue)
        {
            return strValue.ToMoney(0M);
        }
        public static decimal ToMoney(this object strValue, decimal defValue)
        {
            decimal result = 0M;
            decimal.TryParse(strValue.ToString(), out result);
            if (!(result == 0M))
            {
                return result;
            }
            return defValue;
        }

        public static short ToSmallInt(this object strValue)
        {
            return strValue.ToSmallInt(0);
        }

        public static short ToSmallInt(this object strValue, short defValue)
        {
            short result = 0;
            short.TryParse(strValue.ToString(), out result);
            if (result != 0)
            {
                return result;
            }
            return defValue;
        }


        public static string ToStringEmpty(this object o)
        {
            if (!o.IsNull())
            {
                return o.ToString();
            }
            return string.Empty;
        }

        public static byte ToTinyInt(this object strValue)
        {
            return strValue.ToTinyInt(0);
        }

        public static byte ToTinyInt(this object strValue, byte defValue)
        {
            byte result = 0;
            byte.TryParse(strValue.ToString(), out result);
            if (result != 0)
            {
                return result;
            }
            return defValue;
        }

        public static T ToType<T>(this object value)
        {
            return (T)value;
        }

        public static int ToInt(this object strValue, int defValue)
        {
            int result = 0;
            int.TryParse(strValue.ToString(), out result);
            if (result != 0)
                return result;
            return defValue;
        }

        public static object GetPropertyValue(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, (object[])null);
        }

        public static TProperty GetPropertyValue<T, TProperty>(this T obj, string propertyName)
        {
            return (TProperty)obj.GetType().GetProperty(propertyName).GetValue((object)obj, (object[])null);
        }

        public static T ConvertTo<T>(this object value)
        {
            return value.ConvertTo<T>(default(T));
        }

        public static T ConvertTo<T>(this object value, T defaultValue)
        {
            if (value != null)
            {
                Type type = typeof(T);
                TypeConverter converter1 = TypeDescriptor.GetConverter(value);
                if (converter1 != null && converter1.CanConvertTo(type))
                    return (T)converter1.ConvertTo(value, type);
                TypeConverter converter2 = TypeDescriptor.GetConverter(type);
                if (converter2 != null)
                {
                    try
                    {
                        if (converter2.CanConvertFrom(value.GetType()))
                            return (T)converter2.ConvertFrom(value);
                    }
                    catch
                    {
                    }
                }
            }
            return defaultValue;
        }

        public static T ConvertTo<T>(this object value, T defaultValue, bool ignoreException)
        {
            if (!ignoreException)
                return value.ConvertTo<T>();
            try
            {
                return value.ConvertTo<T>();
            }
            catch
            {
                return defaultValue;
            }
        }

        public static void CheckOnNull(this object @this, string parameterName)
        {
            if (@this.IsNull())
                throw new ArgumentNullException(parameterName);
        }

        public static void CheckOnNull(this object @this, string parameterName, string message)
        {
            if (@this.IsNull())
                throw new ArgumentNullException(parameterName, message);
        }

        public static T UnsafeCast<T>(this object value)
        {
            if (!value.IsNull())
                return (T)value;
            return default(T);
        }

        public static T SafeCast<T>(this object value)
        {
            if (!(value is T))
                return default(T);
            return value.UnsafeCast<T>();
        }

        public static bool InstanceOf<T>(this object value)
        {
            return value is T;
        }

        public static bool IsBetween<T>(this IComparable<T> t, T minT, T maxT)
        {
            if (t.CompareTo(minT) >= 0)
                return t.CompareTo(maxT) <= 0;
            return false;
        }

        public static bool IsBetween(this IComparable t, object minT, object maxT)
        {
            if (t.CompareTo(minT) >= 0)
                return t.CompareTo(maxT) <= 0;
            return false;
        }

    }
}
