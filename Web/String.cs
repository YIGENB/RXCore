using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Net;

namespace RX.Web
{
    public static class String
    {
        /// <summary>
        /// 删除空行
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveBR(this string str)
        {
            return Regex.Replace(str, @"\n\s+\n", "\n", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns></returns>
        public static int RealLength(this string str)
        {
            return System.Text.Encoding.Default.GetBytes(str).Length;
        }

        /// <summary>
        /// 转换首字母为大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string InitialsToUpper(this string str)
        {
            string text = "";

            if (str.IndexOf("_") >= 0)
            {
                foreach (string s in str.Split('_'))
                    text += s.Length < 2 ? s.ToUpper() : s.Substring(0, 1).ToUpper() + s.Substring(1);
            }
            else
                text = str.Length < 2 ? str.ToUpper() : str.Substring(0, 1).ToUpper() + str.Substring(1);
            return text;
        }

        /// <summary>
        /// 清除UBB标签
        /// </summary>
        /// <param name="str">帖子内容</param>
        /// <returns>帖子内容</returns>
        public static string ClearUBB(this string str)
        {
            return Regex.Replace(str, @"\[[^\]]*?\]", string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 清除给定字符串中的回车及换行符
        /// </summary>
        /// <param name="str">要清除的字符串</param>
        /// <returns>清除后返回的字符串</returns>
        public static string ClearBR(this string str)
        {
            Regex r = null;
            Match m = null;

            r = new Regex(@"(\r\n)",RegexOptions.IgnoreCase);
            for (m = r.Match(str); m.Success; m = m.NextMatch())
            {
                str = str.Replace(m.Groups[0].ToString(), "");
            }
            return str;
        }

        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(this string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }

        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD532To16(this string md532)
        {
            return md532.Remove(1, 8).Remove(md532.Remove(1, 8).Length - 8, 8);
        }

        /// <summary>
        /// SHA256函数
        /// </summary>
        /// /// <param name="str">原始字符串</param>
        /// <returns>SHA256结果</returns>
        public static string SHA256(this string str)
        {
            byte[] SHA256Data = System.Text.Encoding.UTF8.GetBytes(str);
            System.Security.Cryptography.SHA256Managed Sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] Result = Sha256.ComputeHash(SHA256Data);
            return System.Convert.ToBase64String(Result);  //返回长度为44字节的字符串
        }

        /// <summary>
        /// 移除Html标记
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveHtml(this string content)
        {
            if (string.IsNullOrEmpty(content))
                return "";

            string regexstr = @"<[^>]*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 过滤HTML中的不安全标签
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveUnsafeHtml(this string content)
        {
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }

        /// <summary>
        /// 删除最后一个字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveLastChar(this string str)
        {
            if (str == "")
                return "";
            else
                return str.Substring(0, str.Length - 1);
        }

        /// <summary>
        /// 将全角数字转换为数字
        /// </summary>
        /// <param name="SBCCase"></param>
        /// <returns></returns>
        public static string ToNumberic(this string SBCCase)
        {
            char[] c = SBCCase.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            return new string(c);
        }

        /// <summary>
        /// 清除HTML函数  
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string RemoveAllHTML(this string Htmlstring)
        {
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML  
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring =HtmlDecode(Htmlstring).Trim();
            return Htmlstring;
        }

        public static string HtmlDecode(this string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        public static string HtmlEncode(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        public static string UrlDecode(this string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static string UrlEncode(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// 按照指定格式输出时间
        /// </summary>
        /// <param name="NowDate">时间</param>
        /// <param name="type">输出类型</param>
        /// <returns></returns>
        public static string WriteDate(this string NowDate, int type)
        {
            double TimeZone = 0;
            System.DateTime NewDate = System.DateTime.Parse(NowDate).AddHours(TimeZone);
            string strResult = "";

            switch (type)
            {
                case 1:
                    strResult = NewDate.ToString();
                    break;
                case 2:
                    strResult = NewDate.ToShortDateString().ToString();
                    break;
                case 3:
                    strResult = NewDate.Year + "年" + NewDate.Month + "月" + NewDate.Day + "日 " + NewDate.Hour + "点" + NewDate.Minute + "分" + NewDate.Second + "秒";
                    break;
                case 4:
                    strResult = NewDate.Year + "年" + NewDate.Month + "月" + NewDate.Day + "日";
                    break;
                case 5:
                    strResult = NewDate.Year + "年" + NewDate.Month + "月" + NewDate.Day + "日 " + NewDate.Hour + "点" + NewDate.Minute + "分";
                    break;
                case 6:
                    strResult = NewDate.Year + "-" + NewDate.Month + "-" + NewDate.Day + "  " + NewDate.Hour + ":" + NewDate.Minute;
                    break;
                default:
                    strResult = NewDate.ToString();
                    break;
            }
            return strResult;
        }


        public static byte[] ToByteArray(this string Input)
        {
            return Input.ToByteArray((Encoding)null);
        }

        public static byte[] ToByteArray(this string Input, Encoding EncodingUsing)
        {
            if (!string.IsNullOrEmpty(Input))
                return EncodingUsing.NullCheck<Encoding>((Encoding)new UTF8Encoding()).GetBytes(Input);
            return (byte[])null;
        }

        public static string ToBase64(this string Input)
        {
            return Input.ToBase64((Encoding)null);
        }

        public static string ToBase64(this string Input, Encoding OriginalEncodingUsing)
        {
            if (string.IsNullOrEmpty(Input))
                return "";
            return Convert.ToBase64String(OriginalEncodingUsing.NullCheck<Encoding>((Encoding)new UTF8Encoding()).GetBytes(Input));
        }

        public static string FromBase64(this string Input, Encoding EncodingUsing)
        {
            if (string.IsNullOrEmpty(Input))
                return "";
            byte[] bytes = Convert.FromBase64String(Input);
            return EncodingUsing.NullCheck<Encoding>((Encoding)new UTF8Encoding()).GetString(bytes);
        }

        public static byte[] FromBase64(this string Input)
        {
            if (!string.IsNullOrEmpty(Input))
                return Convert.FromBase64String(Input);
            return new byte[0];
        }

        public static string ToFirstCharacterUpperCase(this string Input)
        {
            if (string.IsNullOrEmpty(Input))
                return "";
            char[] charArray = Input.ToCharArray();
            for (int index = 0; index < charArray.Length; ++index)
            {
                if ((int)charArray[index] != 32 && (int)charArray[index] != 9)
                {
                    charArray[index] = char.ToUpper(charArray[index]);
                    break;
                }
            }
            return new string(charArray);
        }

        public static bool CompareTrim(this string s, string c, bool isIgnoreCase)
        {
            if (s == null || c == null)
                return s == c;
            return string.Compare(s.Trim(), c.Trim(), isIgnoreCase) == 0;
        }

        public static bool CompareTrim(this string s, string c)
        {
            return s.CompareTrim(c, true);
        }

        public static bool Compare(this string s, string c, bool isIgnoreCase)
        {
            if (s == null || c == null)
                return s == c;
            return string.Compare(s, c, isIgnoreCase) == 0;
        }

        public static bool Compare(this string s, string c)
        {
            return s.Compare(c, true);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotNullOrEmpty(this string s)
        {
            return !String.IsNullOrEmpty(s);
        }

        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static string FormatWith(this string format, object arg0)
        {
            return string.Format(format, arg0);
        }

        public static string FormatWith(this string format, object arg0, object arg1)
        {
            return string.Format(format, arg0, arg1);
        }

        public static string FormatWith(this string format, object arg0, object arg1, object arg2)
        {
            return string.Format(format, arg0, arg1, arg2);
        }

        public static string SurroundWith(this string source, string formatter)
        {
            if (String.IsNullOrEmpty(source))
                return string.Empty;
            return string.Format(formatter, (object)source);
        }

        public static bool IsMatch(this string s, string pattern)
        {
            if (String.IsNullOrEmpty(s))
                return false;
            return Regex.IsMatch(s, pattern);
        }

        public static string Match(this string s, string pattern)
        {
            if (String.IsNullOrEmpty(s))
                return string.Empty;
            return Regex.Match(s, pattern).Value;
        }

        public static bool IsMatch(this string s, string pattern, RegexOptions regexOptions)
        {
            if (String.IsNullOrEmpty(s))
                return false;
            return Regex.IsMatch(s, pattern, regexOptions);
        }

        public static string Match(this string s, string pattern, RegexOptions regexOptions)
        {
            if (String.IsNullOrEmpty(s))
                return string.Empty;
            return Regex.Match(s, pattern, regexOptions).Value;
        }

        public static IEnumerable<string> MatchValues(this string s, string pattern)
        {
            MatchCollection matchCollection = s.Matchs(pattern);
            int count = matchCollection.Count;
            for (int index = 0; index < count; ++index)
                yield return matchCollection[index].Value;
        }

        public static MatchCollection Matchs(this string s, string pattern)
        {
            if (String.IsNullOrEmpty(s))
                return (MatchCollection)null;
            return Regex.Matches(s, pattern);
        }

        public static MatchCollection Matchs(this string s, string pattern, RegexOptions regexOptions)
        {
            if (String.IsNullOrEmpty(s))
                return (MatchCollection)null;
            return Regex.Matches(s, pattern, regexOptions);
        }

        public static int MatchsCount(this string s, string pattern)
        {
            if (String.IsNullOrEmpty(s))
                return 0;
            return s.Matchs(pattern).Count;
        }

        public static int MatchsCount(this string s, string pattern, RegexOptions regexOptions)
        {
            if (String.IsNullOrEmpty(s))
                return 0;
            return s.Matchs(pattern, regexOptions).Count;
        }

        public static string RemoveRegex(this string s, string pattern)
        {
            if (String.IsNullOrEmpty(s))
                return string.Empty;
            return Regex.Replace(s, pattern, string.Empty);
        }

        public static string Remove(this string s, string pattern)
        {
            if (String.IsNullOrEmpty(s))
                return string.Empty;
            return s.Replace(pattern, string.Empty);
        }

        public static string ReplaceRegex(this string s, string pattern, string replacement)
        {
            if (String.IsNullOrEmpty(s))
                return string.Empty;
            return Regex.Replace(s, pattern, replacement);
        }

        public static string ReplaceRegex(this string s, string pattern, string replacement, RegexOptions regexOptions)
        {
            if (String.IsNullOrEmpty(s))
                return string.Empty;
            return Regex.Replace(s, pattern, replacement, regexOptions);
        }

        public static string ToCamel(this string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            return s[0].ToString().ToLower() + s.Substring(1);
        }

        public static string ToPascal(this string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            return s[0].ToString().ToUpper() + s.Substring(1);
        }

        public static string ToSBC(this string input)
        {
            char[] charArray = input.ToCharArray();
            for (int index = 0; index < charArray.Length; ++index)
            {
                if ((int)charArray[index] == 32)
                    charArray[index] = '　';
                else if ((int)charArray[index] < (int)sbyte.MaxValue)
                    charArray[index] = (char)((uint)charArray[index] + 65248U);
            }
            return new string(charArray);
        }

    }
}
