using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace RX.Serializes
{
  public static class SerializeExt
  {
    public static void SerializeXmlFile(this object o, string fileName)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(o.GetType());
      if (!File.Exists(fileName))
        return;
      using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        xmlSerializer.Serialize((Stream) fileStream, o);
    }

    public static T DeserializeXmlFile<T>(string fileName)
    {
      using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        return (T) new XmlSerializer(typeof (T)).Deserialize((Stream) fileStream);
    }

    public static string SerializeXml(this object o)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(o.GetType());
      StringBuilder sb = new StringBuilder();
      using (TextWriter textWriter = (TextWriter) new StringWriter(sb))
        xmlSerializer.Serialize(textWriter, o);
      return sb.ToString();
    }

    public static T DeserializeXml<T>(this string xml)
    {
      return (T) SerializeExt.Deserialize(xml, typeof (T));
    }

    public static object Deserialize(string xml, Type type)
    {
      using (TextReader textReader = (TextReader) new StringReader(xml))
        return new XmlSerializer(type).Deserialize(textReader);
    }

    public static T Decompress<T>(this byte[] compressedData) where T : class
    {
      return compressedData.Decompress().Deserialize<T>();
    }

    public static T Deserialize<T>(this byte[] data) where T : class
    {
      using (MemoryStream memoryStream = new MemoryStream(data))
        return new BinaryFormatter().Deserialize((Stream) memoryStream) as T;
    }

    public static object Deserialize(this byte[] data)
    {
      using (MemoryStream memoryStream = new MemoryStream(data))
        return new BinaryFormatter().Deserialize((Stream) memoryStream);
    }

    public static byte[] Decompress(this byte[] data)
    {
      using (MemoryStream memoryStream1 = new MemoryStream())
      {
        memoryStream1.Write(data, 0, data.Length);
        memoryStream1.Position = 0L;
        using (DeflateStream deflateStream = new DeflateStream((Stream) memoryStream1, CompressionMode.Decompress))
        {
          using (MemoryStream memoryStream2 = new MemoryStream())
          {
            byte[] buffer = new byte[64];
            for (int count = deflateStream.Read(buffer, 0, buffer.Length); count > 0; count = deflateStream.Read(buffer, 0, buffer.Length))
              memoryStream2.Write(buffer, 0, count);
            deflateStream.Close();
            return memoryStream2.ToArray();
          }
        }
      }
    }

    public static byte[] Serialize(this object value)
    {
      MemoryStream memoryStream = new MemoryStream();
      new BinaryFormatter().Serialize((Stream) memoryStream, value);
      return memoryStream.ToArray();
    }

    public static object CloneObject(this object obj)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        BinaryFormatter binaryFormatter = new BinaryFormatter((ISurrogateSelector) null, new StreamingContext(StreamingContextStates.Clone));
        binaryFormatter.Serialize((Stream) memoryStream, obj);
        memoryStream.Seek(0L, SeekOrigin.Begin);
        return binaryFormatter.Deserialize((Stream) memoryStream);
      }
    }

    public static byte[] Compress(this byte[] data)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (DeflateStream deflateStream = new DeflateStream((Stream) memoryStream, CompressionMode.Compress))
          deflateStream.Write(data, 0, data.Length);
        return memoryStream.ToArray();
      }
    }
  }
}
