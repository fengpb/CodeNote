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

            TagBuilder div = new TagBuilder("div");
            StringBuilder sb = new StringBuilder();
            if (pager.Cur > 1)
            {
                routeValues["page"] = pager.Cur - 1;

                string pageUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, hh.RouteCollection, hh.ViewContext.RequestContext, true);
                TagBuilder parent = new TagBuilder("a");
                parent.InnerHtml = "&lt;";
                parent.MergeAttribute("title", "上一页");
                parent.MergeAttribute("href", pageUrl);
                sb.Append(parent.ToString());
            }

            int showPage = 10;
            int start = 1;
            int end = (pager.Cur + (showPage / 2)) > pager.Pag ? pager.Pag : showPage;
            start = (pager.Cur - (showPage / 2)) > 1 ? pager.Cur - (showPage / 2) : 1;
            if ((pager.Pag - pager.Cur) <= showPage / 2 && pager.Pag > showPage)
            {
                end = pager.Pag;
                start = pager.Pag - showPage + 1;
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
                next.InnerHtml = "&gt;";
                next.MergeAttribute("title", "下一页");
                next.MergeAttribute("href", pageUrl);
                sb.Append(next.ToString());
            }
            div.InnerHtml = sb.ToString();
            return MvcHtmlString.Create(div.ToString());
        }
        #endregion

        #region tree
        public static MvcHtmlString Tree(this HtmlHelper hh, TreeWrap<CodeNote.Entity.Category> tree)
        {
            TagBuilder div = new TagBuilder("div");
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
                    label.MergeAttribute("title", item.CurNode.Title);
                    label.InnerHtml = item.CurNode.Title;
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
