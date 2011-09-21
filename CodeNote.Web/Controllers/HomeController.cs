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

    }
}
