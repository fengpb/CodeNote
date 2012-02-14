using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Entity;

namespace CodeNote.Web
{
    public class ViewPage : System.Web.Mvc.ViewPage
    {
        public LoginUser CurUser
        {
            get
            {
                return Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY);
            }
        }
        public bool IsLogin { get { return CurUser != null; } }

        /// <summary>
        /// Markdown编码成html
        /// <br/>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string HtmlEncode(string text)
        {
            string str = Markdown.Default.Transform(text);
            return str;
        }
        /// <summary>
        /// 清除html标签
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ClearHtml(string text)
        {
            string str = Markdown.Default.Transform(text);
            str = CodeNote.Common.StringFilter.ClearHtml(str);
            return str;
        }
    }

    public class ViewPage<T> : System.Web.Mvc.ViewPage<T>
    {
        public LoginUser CurUser
        {
            get
            {
                return Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY);
            }
        }
        public bool IsLogin { get { return CurUser != null; } }

        /// <summary>
        /// markdown编码成html
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string HtmlEncode(string text)
        {
            string str = Markdown.Default.Transform(text);
            return str;
        }
        /// <summary>
        /// 清除html标签
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ClearHtml(string text)
        {
            string str = Markdown.Default.Transform(text);
            str = CodeNote.Common.StringFilter.ClearHtml(str);
            return str;
        }
    }
}
