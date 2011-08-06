using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CodeNote.Web.Controllers
{
    public class MarkDownController : System.Web.Mvc.Controller
    {
        /// <summary>
        /// MarkDown help page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Help()
        {
            return View("Help");
        }
    }
}
