using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Entity;
namespace CodeNote.Web
{
    public class ViewUserControl : System.Web.Mvc.ViewUserControl
    {
        public SiteData SiteData { get { return SiteData.Instance; } }

        public LoginUser CurUser
        {
            get
            {
                return Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY);
            }
        }
        public bool IsLogin { get { return CurUser != null; } }

        /// <summary>
        /// markdown 编码成html
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
    public class ViewUserControl<T> : System.Web.Mvc.ViewUserControl<T>
    {
        public SiteData SiteData { get { return SiteData.Instance; } }
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
