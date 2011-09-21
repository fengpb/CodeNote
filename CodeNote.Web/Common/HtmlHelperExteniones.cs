using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using CodeNote.Common;

namespace CodeNote.Web.Common
{
    public static class HtmlHelperExteniones
    {

        public static MvcHtmlString TagLink(this HtmlHelper hh, string tags, string actionName, string controllerName)
        {

            StringBuilder sb = new StringBuilder();

            string[] arr = tags.Split(new Char[] { ',', ' ', '-', ';' });
            foreach (string item in arr)
            {
                TagBuilder alink = new TagBuilder("a");
                string url = Url(hh, actionName, controllerName, new { tag = item }).ToHtmlString();
                alink.MergeAttribute("href", url);
                alink.InnerHtml = item;
                sb.Append(alink.ToString() + "&nbsp;");
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        #region url
        public static MvcHtmlString Url(this HtmlHelper hh, string actionName, string controllerName, Object routeValues)
        {
            string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(routeValues), hh.RouteCollection, hh.ViewContext.RequestContext, true);
            return MvcHtmlString.Create(pageUrl);
        }
        #endregion

        #region image
        /// <summary>
        /// Avatar Face
        /// <br/>
        /// http://www.gravatar.com
        /// </summary>
        /// <param name="hh"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static MvcHtmlString Avatar(this HtmlHelper hh, string email)
        {
            string irl = "http://www.gravatar.com/avatar/{0}?s={1}&d=identicon&r=pg";
            TagBuilder avatar = new TagBuilder("img");
            avatar.MergeAttribute("width", "48");
            avatar.MergeAttribute("height", "48");
            avatar.MergeAttribute("src", string.Format(irl, CodeNote.Common.Encryption.MD5(email), 48));
            return MvcHtmlString.Create(avatar.ToString());
        }

        public static MvcHtmlString ImageLink(this HtmlHelper hh, string src, string actionName, string controllerName, RouteValueDictionary routeValues, RouteValueDictionary htmlAttributes)
        {
            string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
            TagBuilder link = new TagBuilder("a");
            link.MergeAttribute("href", pageUrl);
            link.MergeAttributes(htmlAttributes);
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", src);
            img.MergeAttribute("alt", "");
            link.InnerHtml = img.ToString();
            return MvcHtmlString.Create(link.ToString());
        }

        public static MvcHtmlString Image(this HtmlHelper hh, string actionName, string controllerName, Object routeValues)
        {
            return Image(hh, actionName, controllerName, new RouteValueDictionary(routeValues), new RouteValueDictionary());
        }

        public static MvcHtmlString Image(this HtmlHelper hh, string actionName, string controllerName, Object routeValues, Object htmlAttributes)
        {
            return Image(hh, actionName, controllerName, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString Image(this HtmlHelper hh, string actionName, string controllerName, RouteValueDictionary routeValues, RouteValueDictionary htmlAttributes)
        {
            string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", pageUrl);
            img.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(img.ToString());
        }
        #endregion

        #region Paging

        #region AjaxPaging
        public static MvcHtmlString AjaxPaging(this HtmlHelper hh, Pager pager, string actionName, string controllerName, AjaxPagingOption option, Object routeValues)
        {
            return AjaxPaging(hh, pager, actionName, controllerName, option, new RouteValueDictionary(routeValues));
        }
        public static MvcHtmlString AjaxPaging(this HtmlHelper hh, Pager pager, string actionName, string controllerName, AjaxPagingOption option, RouteValueDictionary routeValues)
        {
            if (option == null)
            {
                option = new AjaxPagingOption();
            }
            if (routeValues == null)
            {
                routeValues = new RouteValueDictionary();
            }
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "pager");
            StringBuilder sb = new StringBuilder();
            routeValues["page"] = pager.Cur;
            string hidRefreshUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
            sb.AppendLine(string.Format("<input type=\"hidden\" id=\"hid_RefreshUrl\" value=\"{0}\" >", hidRefreshUrl));
            if (pager.Pag > 1)//显示页码
            {
                if (pager.Cur > 1)
                {
                    routeValues["page"] = pager.Cur - 1;

                    string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                    TagBuilder parent = new TagBuilder("a");
                    parent.InnerHtml = "&lt;&lt;";
                    parent.MergeAttribute("title", "上一页");
                    parent.MergeAttribute("href", option.Href);
                    parent.MergeAttribute("onclick", option.ToString(pageUrl));
                    sb.AppendLine(parent.ToString());
                }

                int showPage = 5; //showPage*2
                int start = 1;
                int end = 5 * 2;
                if ((pager.Cur - showPage) < 1)
                {
                    start = 1;
                }
                else
                {
                    start = pager.Cur - showPage;
                }
                if ((pager.Cur + showPage) >= pager.Pag)
                {
                    end = pager.Pag;
                }
                else
                {
                    end = pager.Cur + showPage;
                }

                //首页
                if (start > showPage)
                {
                    routeValues["page"] = 1;

                    string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                    TagBuilder parent = new TagBuilder("a");
                    parent.InnerHtml = string.Format("<span>{0}</span>", 1);
                    parent.MergeAttribute("title", "首页");
                    parent.MergeAttribute("href", option.Href);
                    parent.MergeAttribute("onclick", option.ToString(pageUrl));
                    sb.AppendLine(parent.ToString());
                }

                for (int i = start; i <= end; i++)
                {
                    routeValues["page"] = i;
                    string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                    TagBuilder aLink = new TagBuilder("a");
                    if (i == pager.Cur)
                    {
                        aLink.MergeAttribute("class", "cur");
                        aLink.InnerHtml = string.Format("&nbsp;<b>{0}</b>&nbsp;", i);
                    }
                    else
                    {
                        aLink.InnerHtml = string.Format("&nbsp;<span>{0}</span>&nbsp;", i);
                    }
                    aLink.MergeAttribute("href", option.Href);
                    aLink.MergeAttribute("onclick", option.ToString(pageUrl));
                    sb.AppendLine(aLink.ToString());
                }
                if (end < pager.Pag - showPage)
                {
                    routeValues["page"] = pager.Pag;

                    string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                    TagBuilder next = new TagBuilder("a");
                    next.InnerHtml = string.Format("<span>{0}</span>", pager.Pag);
                    next.MergeAttribute("title", "尾页");
                    next.MergeAttribute("href", option.Href);
                    next.MergeAttribute("onclick", option.ToString(pageUrl));
                    sb.AppendLine(next.ToString());
                }
                if (pager.Cur < pager.Pag)
                {
                    routeValues["page"] = pager.Cur + 1;

                    string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                    TagBuilder next = new TagBuilder("a");
                    next.InnerHtml = "&gt;&gt;";
                    next.MergeAttribute("title", "下一页");
                    next.MergeAttribute("href", option.Href);
                    next.MergeAttribute("onclick", option.ToString(pageUrl));
                    sb.AppendLine(next.ToString());
                }
            }
            div.InnerHtml = sb.ToString();
            return MvcHtmlString.Create(div.ToString());
        }
        #endregion

        #region Paging
        /// <summary>
        /// Page
        /// <br/>
        /// 分页
        /// </summary>
        /// <param name="hh"></param>
        /// <param name="pager"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static MvcHtmlString Paging(
            this HtmlHelper hh,
            Pager pager,
            string actionName,
            string controllerName, Object routeValues)
        {
            return Paging(hh, pager, actionName, controllerName, new RouteValueDictionary(routeValues));
        }
        /// <summary>
        /// Page：分页 
        /// </summary>
        /// <param name="hh"></param>
        /// <param name="pager"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        public static MvcHtmlString Paging(
            this HtmlHelper hh,
            Pager pager,
            string actionName,
            string controllerName, RouteValueDictionary routeValues)
        {
            if (routeValues == null)
            {
                routeValues = new RouteValueDictionary();
            }
            TagBuilder div = new TagBuilder("div");
            StringBuilder sb = new StringBuilder();
            if (pager.Cur > 1)
            {
                routeValues["page"] = pager.Cur - 1;

                string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                TagBuilder parent = new TagBuilder("a");
                parent.InnerHtml = "&lt;&lt;";
                parent.MergeAttribute("title", "上一页");
                parent.MergeAttribute("href", pageUrl);
                sb.Append(parent.ToString());
            }

            int showPage = 5; //showPage*2
            int start = 1;
            int end = 5 * 2;
            if ((pager.Cur - showPage) < 1)
            {
                start = 1;
            }
            else
            {
                start = pager.Cur - showPage;
            }
            if ((pager.Cur + showPage) >= pager.Pag)
            {
                end = pager.Pag;
            }
            else
            {
                end = pager.Cur + showPage;
            }

            //首页
            if (start > showPage)
            {
                routeValues["page"] = 1;

                string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                TagBuilder parent = new TagBuilder("a");
                parent.InnerHtml = string.Format("<span>{0}</span>", 1);
                parent.MergeAttribute("title", "首页");
                parent.MergeAttribute("href", pageUrl);
                sb.Append(parent.ToString());
            }

            for (int i = start; i <= end; i++)
            {
                routeValues["page"] = i;
                string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                TagBuilder aLink = new TagBuilder("a");
                if (i == pager.Cur)
                    aLink.InnerHtml = string.Format("&nbsp;<b>{0}</b>&nbsp;", i);
                else
                    aLink.InnerHtml = string.Format("&nbsp;<span>{0}</span>&nbsp;", i);
                aLink.MergeAttribute("href", pageUrl);
                sb.Append(aLink.ToString());
            }
            if (end < pager.Pag - showPage)
            {
                routeValues["page"] = pager.Pag;

                string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                TagBuilder next = new TagBuilder("a");
                next.InnerHtml = string.Format("<span>{0}</span>", pager.Pag);
                next.MergeAttribute("title", "尾页");
                next.MergeAttribute("href", pageUrl);
                sb.Append(next.ToString());
            }
            if (pager.Cur < pager.Pag)
            {
                routeValues["page"] = pager.Cur + 1;

                string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                TagBuilder next = new TagBuilder("a");
                next.InnerHtml = "&gt;&gt;";
                next.MergeAttribute("title", "下一页");
                next.MergeAttribute("href", pageUrl);
                sb.Append(next.ToString());
            }
            div.InnerHtml = sb.ToString();
            return MvcHtmlString.Create(div.ToString());
        }

        #endregion

        #endregion

        #region tree
        public static MvcHtmlString Tree(this HtmlHelper hh, TreeWrap<CodeNote.Entity.Category> tree)
        {
            TagBuilder div = new TagBuilder("div");
            div.MergeAttribute("class", "tree");
            div.InnerHtml = InitTree(hh, tree);
            return MvcHtmlString.Create(div.ToString());
        }
        public static string InitTree(HtmlHelper hh, TreeWrap<CodeNote.Entity.Category> tree)
        {
            if (tree.IsSub)
            {
                TagBuilder ul = new TagBuilder("ul");
                StringBuilder sb = new StringBuilder();
                foreach (TreeWrap<CodeNote.Entity.Category> item in tree.SubNode)
                {
                    TagBuilder li = new TagBuilder("li");
                    TagBuilder label = new TagBuilder("label");
                    string hid = string.Format("<input type=\"checkbox\" name=\"chkCategory\" value=\"{0}\" onchange=\"ChkCategoryChange(this)\" />", item.CurNode.CategoryID);
                    label.MergeAttribute("title", item.CurNode.Title);
                    label.InnerHtml = hid + "&nbsp;" + item.CurNode.Name + "(" + item.CurNode.Title + ")";
                    li.InnerHtml = label.ToString() + InitTree(hh, item);
                    sb.Append(li.ToString());
                }
                ul.InnerHtml = sb.ToString();
                return ul.ToString();
            }
            return string.Empty;
        }
        #endregion
    }

    /// <summary>
    /// Ajax Page option
    /// </summary>
    public class AjaxPagingOption
    {
        public AjaxPagingOption()
        {
            this.Function = "AjaxPager('{0}','{1}')";
            this.Href = "javascript:;";
        }
        public AjaxPagingOption(string target)
        {
            this.Function = "AjaxPager('{0}','{1}')";
            this.Href = "javascript:;";
            this.Targer = target;
        }
        public AjaxPagingOption(string function, string target)
        {
            this.Function = function;
            this.Href = "javascript:;";
            this.Targer = target;
        }
        public string Href { get; set; }
        public string Function { get; set; }
        public string Targer { get; set; }

        public string ToString(string url)
        {
            return string.Format(this.Function, url, this.Targer);
        }
    }

    public class Pager
    {
        public Pager() { }
        public Pager(int cur, int size, int count)
        {
            this.Cur = cur;
            this.Size = size;
            this.Count = count;
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int Cur { get; set; }
        /// <summary>
        /// 数据条数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 每页显示的条数
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 页数
        /// </summary>
        public int Pag
        {
            get
            {
                return (int)Math.Ceiling(Count / (double)Size);
            }
        }
    }
}
