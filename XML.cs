using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RX
{
    public static class XMLExt
    {
        public static XDocument ToXDocument(this string xml)
        {
            return XDocument.Parse(xml);
        }

        public static XmlDocument ToXmlDOM(this string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            return document;
        }

        public static XPathNavigator ToXPath(this string xml)
        {
            XPathDocument document = new XPathDocument(new StringReader(xml));
            return document.CreateNavigator();
        }

    }
}
