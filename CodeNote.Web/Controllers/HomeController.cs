using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

#region Using users.
using CodeNote.Web.Models;
#endregion

namespace CodeNote.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
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
