using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeNote.Common
{
    /// <summary>
    /// 字符过滤
    /// </summary>
    public class StringFilter
    {
        public static string HtmlFilter(string str)
        {
            return HtmlFilter(str, true);
        }
        public static string HtmlFilter(string str, bool blankspace)
        {
            string temp = string.Empty;
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<.+?>");
            temp = reg.Replace(str, "");
            temp = temp.Replace(" ", "");
            if (blankspace)
                temp = temp.Replace("&nbsp;", "");
            return temp;
        }
    }

    public class StringUtil
    {
        /// <summary>
        /// 截取字符
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Cut(string sourceStr, int length)
        {
            return sourceStr != null && sourceStr.Length > length ? sourceStr.Substring(0, length) : sourceStr;
        }
    }

    public sealed class Validation
    {
        public static bool Email(string text)
        {
            return Regex.IsMatch(text, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        public bool IPCheck(string IP)
        {
            string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";
            return Regex.IsMatch(IP, ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
        }

        public bool IsUrl(string str_url)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_url, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }
    }
}
