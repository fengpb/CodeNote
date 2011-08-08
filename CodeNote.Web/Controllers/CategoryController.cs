﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
#region Using users.
using CodeNote.Entity;
using CodeNote.Manager;
using CodeNote.Common;
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
            return View("Category", model);
        }

        #region EditCategory
        /// <summary>
        /// Admin 修改/添加分类信息
        /// </summary>
        /// <returns></returns>
        public ActionResult EditCategory()
        {
            return View("EditCategory");
        }
        #endregion

        #region CategoryTree
        /// <summary>
        /// 分类树
        /// </summary>
        /// <returns></returns>
        public ActionResult CategoryTree()
        {
            TreeWrap<CodeNote.Entity.Category> tree = this.CategoryMg.GetCategoryTree();
            return PartialView("CategoryTree", tree);
        }
        #endregion

        #region PartView
        /// <summary>
        /// 根据categoryID获取下面的子类菜单
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public ActionResult CategoryList(string categoryID)
        {
            IList<Category> model = this.CategoryMg.GetByParentID(categoryID, true);
            if (model != null && model.Count > 0)
            {
                ViewData["partitle"] = this.CategoryMg.Get(categoryID).Title;
            }
            return PartialView("CategoryList", model);
        }

        public JsonResult CategoryJson(string categoryID)
        {
            IList<Category> list = this.CategoryMg.GetByParentID(categoryID);
            Object model;
            if (list != null)
            {
                model = list.Select(e => new { cid = e.CategoryID, cname = e.Name }).ToList();
            }
            else
            {
                model = null;
            }
            return Json(model);
        }
        #endregion
    }
}
