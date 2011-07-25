using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CodeNote.Web.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index(string categoryID)
        {
            return Category(categoryID);
        }
        public ActionResult Category(string categoryID)
        {
            return View("Category");
        }
        public ActionResult CategoryList(string categoryID)
        {
            return PartialView("CategoryList");
        }
    }
}
