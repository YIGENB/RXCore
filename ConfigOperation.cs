using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace RX
{
    public static class ConfigOperation
    {
        private static string GetNewIP(this string oldValue, string serverIP)
        {
            string pattern = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            string replacement = string.Format("{0}", serverIP);
            string newvalue = Regex.Replace(oldValue, pattern, replacement);
            return newvalue;
        }
    }
}
