using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CodeNote.Web.Filter;

namespace CodeNote.Web.Controllers
{
    public class AccountController:System.Web.Mvc.Controller
    {
        [CheckLogin]
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
