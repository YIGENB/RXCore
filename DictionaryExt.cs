using System.Collections.Generic;

namespace RX
{
  public static class DictionaryExt
  {
    public static TDictionary Copy<TDictionary, TKey, TValue>(this TDictionary source, IDictionary<TKey, TValue> copy) where TDictionary : IDictionary<TKey, TValue>
    {
      foreach (KeyValuePair<TKey, TValue> keyValuePair in (IEnumerable<KeyValuePair<TKey, TValue>>) copy)
        source.Add(keyValuePair.Key, keyValuePair.Value);
      return source;
    }

    public static TDictionary Copy<TDictionary, TKey, TValue>(this TDictionary source, IDictionary<TKey, TValue> copy, IEnumerable<TKey> keys) where TDictionary : IDictionary<TKey, TValue>
    {
      foreach (TKey key in keys)
        source.Add(key, copy[key]);
      return source;
    }

    public static TDictionary RemoveKeys<TDictionary, TKey, TValue>(this TDictionary source, IEnumerable<TKey> keys) where TDictionary : IDictionary<TKey, TValue>
    {
      foreach (TKey key in keys)
        source.Remove(key);
      return source;
    }

    public static IDictionary<TKey, TValue> RemoveKeys<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<TKey> keys)
    {
      foreach (TKey key in keys)
        source.Remove(key);
      return source;
    }

    public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
    {
      if (!dict.ContainsKey(key))
        dict.Add(key, value);
      return dict;
    }

    public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
    {
      dict[key] = value;
      return dict;
    }

    public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue)
    {
      if (!dict.ContainsKey(key))
        return defaultValue;
      return dict[key];
    }

    public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
    {
      return dict.GetValue<TKey, TValue>(key, default (TValue));
    }

    public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted)
    {
      foreach (KeyValuePair<TKey, TValue> keyValuePair in values)
      {
        if (!dict.ContainsKey(keyValuePair.Key) || replaceExisted)
          dict[keyValuePair.Key] = keyValuePair.Value;
      }
      return dict;
    }
  }
}
