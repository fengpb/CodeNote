using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CodeNote.Web.Controllers
{
    public class AccountController:System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
