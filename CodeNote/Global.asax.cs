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
               "CategoryTree", // 路由名称
               "CategoryTree", // 带有参数的 URL
               new { controller = "Category", action = "Tree" } // 参数默认值
           );
            routes.MapRoute(
                "CategoryEdit", // 路由名称
                "Edit/Category", // 带有参数的 URL
                new { controller = "Category", action = "Edit" } // 参数默认值
            );
            routes.MapRoute(
               "CategoryDoEdit", // 路由名称
               "DoEdit/Category", // 带有参数的 URL
               new { controller = "Category", action = "DoEdit" } // 参数默认值
           );
            routes.MapRoute(
              "CategoryDoDel", // 路由名称
              "DoDel/Category", // 带有参数的 URL
              new { controller = "Category", action = "DelCategory" } // 参数默认值
          );
            routes.MapRoute(
               "CategoryJson", // 路由名称
               "CgJson/{categoryID}", // 带有参数的 URL
               new { controller = "Category", action = "CategoryJson", categoryID = "" } // 参数默认值
            );
            routes.MapRoute(
             "CategoryIndex", // 路由名称
             "topic/{categoryName}", // 带有参数的 URL
             new { controller = "Category", action = "Category", categoryName = "" } // 参数默认值
            );
            #endregion

            #region Article 日志
            routes.MapRoute(
            "ArticleDetail", // 路由名称
            "Detail/{articleID}", // 带有参数的 URL
            new { controller = "Article", action = "Detail", articleID = (int?)null }, // 参数默认值
            new { articleID = "[0-9]+" }
            );
            #endregion

            #region Tag
            routes.MapRoute(
           "TagList", // 路由名称
           "TagList", // 带有参数的 URL
           new { controller = "Tag", action = "Index", Tag = (string)null } // 参数默认值
           );
            routes.MapRoute(
            "PartTag", // 路由名称
            "PartTag/{id}", // 带有参数的 URL
            new { controller = "Tag", action = "PartTag", id = UrlParameter.Optional } // 参数默认值
            );

            routes.MapRoute(
            "TagArticle", // 路由名称
            "tag/{Tag}", // 带有参数的 URL
            new { controller = "Tag", action = "Tag", Tag = (string)null } // 参数默认值
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