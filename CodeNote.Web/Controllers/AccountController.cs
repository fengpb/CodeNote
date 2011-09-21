using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CodeNote.Web.Filter;

namespace CodeNote.Web.Controllers
{
    public class AccountController : System.Web.Mvc.Controller
    {
        [CheckLogin]
        public ActionResult Index()
        {
            return View("Index");
        }

        #region Navigation
        /// <summary>
        /// 用户导航
        /// </summary>
        /// <returns></returns>
        [CheckAdmin]
        public ActionResult Navigation()
        {
            return View("Navigation");
        }
        #endregion

        #region Category
        /// <summary>
        /// 分类管理
        /// </summary>
        /// <returns></returns>
        [CheckAdmin]
        public ActionResult Category()
        {
            return View("Category");
        }
        #endregion

        #region Tag
        /// <summary>
        /// 标签管理
        /// </summary>
        /// <returns></returns>
        [CheckAdmin]
        public ActionResult Tag()
        {
            return View("Tag");
        }
        #endregion
    }
}
