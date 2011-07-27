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
            SiteData.Instance.CurCategory.CategoryID = "Index";
            return View("Index");
        }
    }
}
