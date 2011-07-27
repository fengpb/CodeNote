using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
#region Using users.
using CodeNote.Entity;
using CodeNote.Manager;
#endregion


namespace CodeNote.Web.Controllers
{
    public class CategoryController : Controller
    {
        #region CategoryManager
        private CategoryManager _categoryMg;
        protected CategoryManager CategoryMg
        {
            get
            {
                if (_categoryMg == null)
                {
                    _categoryMg = new CategoryManager();
                }
                return _categoryMg;
            }
        }
        #endregion

        /// <summary>
        /// 不同分类的页面
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public ActionResult Category(string categoryName)
        {
            Entity.Category model = this.CategoryMg.GetName(categoryName);
            if (model == null)
            {
                //暂无次分类信息
               return RedirectToAction("Index", "Home");
            }
            Web.Models.SiteData.Instance.CurCategory = model;
            return View("Category", model);
        }

        #region PartView
        /// <summary>
        /// 根据categoryID获取下面的子类菜单
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public ActionResult CategoryList(string categoryID)
        {
            IList<Category> model = this.CategoryMg.GetByParentID(categoryID);
            return PartialView("CategoryList", model);
        }
        #endregion
    }
}
