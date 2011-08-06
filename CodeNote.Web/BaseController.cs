using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Entity;

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
    }
}
