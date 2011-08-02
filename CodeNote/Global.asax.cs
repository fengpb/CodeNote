using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeNote
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region category
            routes.MapRoute(
               "CategoryIndex", // 路由名称
               "Category/{categoryName}", // 带有参数的 URL
               new { controller = "Category", action = "Category", categoryName = "" } // 参数默认值
           );
            routes.MapRoute(
               "CategoryJson", // 路由名称
               "CgJson/{categoryID}", // 带有参数的 URL
               new { controller = "Category", action = "CategoryJson", categoryID = "" } // 参数默认值
           );
            
            #endregion

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

        }

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
    }
}