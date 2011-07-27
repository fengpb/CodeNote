using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Web.Models;

namespace CodeNote.Web
{
    public class ViewUserControl : System.Web.Mvc.ViewUserControl
    {
        public SiteData SiteData { get { return SiteData.Instance; } }
    }
    public class ViewUserControl<T> : System.Web.Mvc.ViewUserControl<T>
    {
        public SiteData SiteData { get { return SiteData.Instance; } }
    }
}
