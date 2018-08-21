using System;
using System.Collections.Generic;

namespace RX
{
  public static class TypeExt
  {
    public static bool IsNullableType(this Type type)
    {
      if (type != null && type.IsGenericType)
        return type.GetGenericTypeDefinition() == typeof (Nullable<>);
      return false;
    }

    public static Type GetNonNullableType(this Type type)
    {
      if (type.IsNullableType())
        return type.GetGenericArguments()[0];
      return type;
    }

    public static bool IsEnumerableType(this Type enumerableType)
    {
      return typeof (IEnumerable<>).FindGenericType(enumerableType) != null;
    }

    public static Type GetElementType(this Type enumerableType)
    {
      Type genericType = typeof (IEnumerable<>).FindGenericType(enumerableType);
      if (genericType != null)
        return genericType.GetGenericArguments()[0];
      return enumerableType;
    }

    public static bool IsKindOfGeneric(this Type type, Type definition)
    {
      return definition.FindGenericType(type) != null;
    }

    public static Type FindGenericType(this Type definition, Type type)
    {
      for (; type != null && type != typeof (object); type = type.BaseType)
      {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == definition)
          return type;
        if (definition.IsInterface)
        {
          foreach (Type type1 in type.GetInterfaces())
          {
            Type genericType = definition.FindGenericType(type1);
            if (genericType != null)
              return genericType;
          }
        }
      }
      return (Type) null;
    }
  }
}
