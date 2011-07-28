using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
#region using users.
using CodeNote.Entity;
using CodeNote.Manager;
#endregion
namespace CodeNote.Web.Controllers
{
    /// <summary>
    /// Views/Control
    /// </summary>
    public class ControlController : Controller
    {
        public ActionResult Header()
        {
            return PartialView("Header");
        }
        public ActionResult Navigation()
        {
            CategoryManager cmg = new CategoryManager();
            IList<Category> model = cmg.GetMenu();
            return PartialView("Navigation", model);
        }
        public ActionResult Footer()
        {
            return PartialView("Footer");
        }


        public ActionResult AccountLeft()
        {
            LoginUser model = Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY);
            return PartialView("AccountLeft", model);
        }

        public ActionResult AccountNav()
        {
            return PartialView("AccountNav");
        }
    }
}
