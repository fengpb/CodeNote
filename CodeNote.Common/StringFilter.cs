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
            string temp = string.Empty;
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<.+?>");
            temp = reg.Replace(str, "");
            temp = temp.Replace(" ", "");
            temp = temp.Replace("&nbsp;", "");
            temp = temp.Replace("\r\n", "");
            return temp;
        }
    }

    /// <summary>
    /// desp:  html 转换
    /// author:fengpengbin@live.cn
    /// </summary>
    public sealed class HtmlFilter
    {
        public HtmlFilter()
        {
        }
        private static string[] WhiteList = new string[] { 
            "code", "span", "h1","ul","li","ol", "h2", "h3", "h4","h5","h6", "strong", "b", "em", "i", "u", "p", "pre", "br", 
            "CODE", "SPAN", "H1","UL","LI","OL", "H2", "H3", "H4","H5","H6", "STRONG", "B", "EM", "I", "U", "P", "PRE", "BR" 
        };
        public static string Filter(string sourceStr)
        {
            return Filter(sourceStr, true);
        }

        public static string Filter(string sourceStr, bool isStyle)
        {
            StringBuilder sb = new StringBuilder(Encode(sourceStr));
            for (int i = 0; i < WhiteList.Length; i++)
            {
                string tag = WhiteList[i];
                if (isStyle)//
                {
                    string reg = "&lt;(" + tag + "(?:.+?)style=)&quot;(.+?)&quot;&gt;";
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(reg);
                    sb = new StringBuilder(regex.Replace(sb.ToString(), "<$1\"$2\">"));
                }
                //空格&
                sb = sb.Replace("&amp;", "&");
                sb = sb.Replace("&lt;" + tag + "/&gt;", "<" + tag + "/>");
                sb = sb.Replace("&lt;" + tag + " /&gt;", "<" + tag + "/>");
                sb = sb.Replace("&lt;" + tag + "&gt;", "<" + tag + ">");
                sb = sb.Replace("&lt;/" + tag + "&gt;", "</" + tag + ">");
            }
            return sb.ToString();
        }

        public static string Encode(string sourceStr)
        {
            return System.Web.HttpUtility.HtmlEncode(sourceStr);
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
