using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CodeNote.Web.Models;
using System.Web.Routing;

namespace CodeNote.Web.Filter
{
    public class CheckAdmin : System.Web.Mvc.AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (SiteData.Instance.IsLogin && SiteData.Instance.CurUser.Type > (int)Constans.UserType.NoReg)
            {
                return true;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RouteValueDictionary rvd = new RouteValueDictionary();
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "User" }, { "action", "NoPower" } });
        }
    }
}
