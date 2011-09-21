using System;
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
    public class CategoryController : CodeNote.Web.BaseController
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

        #region Category
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
                //暂无此分类信息
                return RedirectToAction("Index", "Home");
            }
            return View("Category", model);
        }
        #endregion

        #region DelCategory
        /// <summary>
        /// 删除分类信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DelCategory(string ids)
        {
            ReturnValue retValue = new ReturnValue();
            retValue = CategoryMg.Delete(ids);
            return Json(retValue);
        }
        #endregion

        #region EditCategory
        /// <summary>
        /// Admin 修改/添加分类信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            string categoryID = Request["categoryID"];
            Entity.Category model = CategoryMg.Get(categoryID);
            return PartialView("EditCategory", model);
        }
        [Filter.CheckAdmin]
        public JsonResult DoEdit()
        {
            Entity.Category entity = new Entity.Category();
            entity.ParentID = Request["parentid"];
            entity.CategoryID = Request["categoryID"];
            if (entity.ParentID == entity.CategoryID)
            {
                entity.ParentID = "0";
            }
            if (entity.ParentID.Length == entity.CategoryID.Length)
            {
                entity.ParentID = entity.CategoryID.Substring(entity.CategoryID.IndexOf("-"));
            }

            entity.Name = Request["name"];
            entity.Title = Request["title"];
            entity.Count = 0;
            entity.Status = 0;
            entity.IsHot = false;
            entity.CreateDate = DateTime.Now;
            entity.CreateID = this.CurUser.ID;

            ReturnValue retValue = new ReturnValue();
            retValue = this.CategoryMg.AddOrEdit(entity);
            return Json(retValue);
        }
        #endregion

        #region CategoryTree
        /// <summary>
        /// 分类树
        /// </summary>
        /// <returns></returns>
        public ActionResult Tree()
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
