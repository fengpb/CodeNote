using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Web.Common
{
    public class MarkDown
    {
        public static string Transform(string body)
        {
            Markdown.Markdown markdown = new Markdown.Markdown();
            //body = System.Web.HttpUtility.HtmlEncode(body);
            return markdown.Transform(body);
        }
    }
}
