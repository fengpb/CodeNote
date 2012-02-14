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
        public static string ClearHtml(string str)
        {
            return ClearHtml(str, false);
        }

        public static string ClearHtml(string str, int length)
        {
            string temp = ClearHtml(str, false);
            if (temp.Length > length)
            {
                return temp.Substring(0, length);
            } return temp;
        }
        /// <summary>
        /// 过滤Html标签
        /// </summary>
        /// <param name="str">含有html标签的字符</param>
        /// <param name="isfilter">是否开启黑白名单过滤</param>
        /// <returns></returns>
        public static string ClearHtml(string str, bool isfilter)
        {
            string temp = string.Empty;

            if (isfilter)
            {
                temp = Filter(str);
            }
            else
            {
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<.+?>");
                temp = reg.Replace(str, "");
            }
            return temp;
        }

        /// <summary>
        /// 白名单标签允许自带样式
        /// </summary>
        private static string[] WhiteList = new string[] 
        { 
          "span", "h1", "h2", "h3", "h4", "strong", "b", "em", "i", "u", "p", "pre", "br"
        };
        /// <summary>
        /// 黑名单内的标签
        /// </summary>
        private static string[] Blacklist = new string[]
        {
            "script","iframe","form","input","select"
        };


        public static string Filter(string sourceStr)
        {
            sourceStr = sourceStr.ToLower();
            StringBuilder sb = new StringBuilder(sourceStr);

            for (int i = 0; i < WhiteList.Length; i++)
            {
                string tag = WhiteList[i];
                string reg = "<(" + tag + ")(?:.+?)(style=)\"(.+?)\"(?:.+?)>";
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(reg);
                sb = new StringBuilder(regex.Replace(sb.ToString(), "<$1 $2\"$3\">"));
            }

            for (int i = 0; i < Blacklist.Length; i++)
            {
                string tag = Blacklist[i];
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("<" + tag + ".+?>");

                string tmp = regex.Replace(sb.ToString(), "");
                sb = new StringBuilder(tmp.Replace("</" + tag + ">", ""));
            }
            return sb.ToString();
        }
    }

    /// <summary>
    /// 字符工具
    /// </summary>
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

    /// <summary>
    /// 字符验证
    /// </summary>
    public sealed class Validation
    {
        public static bool Email(string text)
        {
            return Regex.IsMatch(text, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        public static bool IPCheck(string IP)
        {
            string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";
            return Regex.IsMatch(IP, ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
        }

        public static bool IsUrl(string str_url)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_url, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }
    }
}
