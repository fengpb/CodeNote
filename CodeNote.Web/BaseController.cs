using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Entity;
using System.Web.Routing;

namespace CodeNote.Web
{
    public class BaseController : System.Web.Mvc.Controller
    {
        public LoginUser CurUser
        {
            get
            {
                return Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY);
            }
        }

        public string CurToken
        {
            get { return Common.SessionWrap.Get(Models.Constans.USER_SESSION_KEY_TOKEN) as string; }
        }

        public string UrlPath(string actionName, string controllerName, Object routeValues)
        {
            RouteValueDictionary values = new RouteValueDictionary(routeValues);
            values.Add("action", actionName);
            values.Add("controller", controllerName);
            return SiteData.Instance.Domain + Url.RouteCollection.GetVirtualPath(this.HttpContext.Request.RequestContext, values).VirtualPath;
        }
    }
}
