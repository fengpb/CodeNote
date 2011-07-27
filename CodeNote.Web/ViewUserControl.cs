using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Entity;
namespace CodeNote.Web
{
    public class ViewUserControl : System.Web.Mvc.ViewUserControl
    {
        public SiteData SiteData { get { return SiteData.Instance; } }

        public LoginUser CurUser
        {
            get
            {
                return Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY);
            }
        }
        public bool IsLogin { get { return CurUser != null; } }
    }
    public class ViewUserControl<T> : System.Web.Mvc.ViewUserControl<T>
    {
        public SiteData SiteData { get { return SiteData.Instance; } }
        public LoginUser CurUser
        {
            get
            {
                return Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY);
            }
        }
        public bool IsLogin { get { return CurUser != null; } }
    }
}
