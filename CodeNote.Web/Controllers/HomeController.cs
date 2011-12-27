using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

#region Using users.
using CodeNote.Web.Models;
using CodeNote.Common;
#endregion

namespace CodeNote.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string key = Request["q"];
            if (!string.IsNullOrEmpty(key))
            {
                CodeNote.Common.PageList<Entity.VwArticle> model = null;
                key = key.Trim();
                if (!string.IsNullOrEmpty(key))
                {
                    CodeNote.Luc.ArtilceLuc artLuc = new Luc.ArtilceLuc();
                    model = artLuc.Search(key, 1, 10);
                    ViewData["key"] = key;
                }
                return View("Search", model);
            }
            return View("Index");
        }

        /// <summary>
        /// 搜索结果
        /// </summary>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult PartSearch(string key, int page = 1)
        {
            CodeNote.Common.PageList<Entity.VwArticle> model = null;
            if (!string.IsNullOrEmpty(key))
            {
                key = key.Trim();
                if (!string.IsNullOrEmpty(key))
                {
                    CodeNote.Luc.ArtilceLuc artLuc = new Luc.ArtilceLuc();
                    model = artLuc.Search(key, page, 10);
                    ViewData["key"] = key;
                }
            }

            return PartialView("PartSearch", model);
        }

        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View("About");
        }

        /// <summary>
        /// 关于gravatar头像
        /// </summary>
        /// <returns></returns>
        public ActionResult Avatar()
        {
            return View("Avatar");
        }

        /// <summary>
        /// 错误信息页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View("Error");
        }

        /// <summary>
        /// 帮助页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Help()
        {
            return View("Help");
        }

        [Filter.CheckAdmin]
        public ActionResult SiteMap()
        {
            Manager.HtmlManager hmMag = new Manager.HtmlManager();
            ReturnValue retValue = hmMag.RefreshSiteMap();
            if (retValue.IsExists)
            {
                return Redirect("/sitemap.xml");
            }
            else
            {
                return View("Error",retValue);
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        public ActionResult Test()
        {
            return PartialView("Test");
        }
    }
}
