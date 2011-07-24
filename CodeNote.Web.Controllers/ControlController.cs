using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

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
            return PartialView("Navigation");
        }
        public ActionResult Footer()
        {
            return PartialView("Footer");
        }
    }
}
