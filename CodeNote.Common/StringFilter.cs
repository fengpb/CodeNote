using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
}
