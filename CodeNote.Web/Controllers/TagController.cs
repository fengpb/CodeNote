using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CodeNote.Manager;
using CodeNote.Common;
using CodeNote.Entity;

namespace CodeNote.Web.Controllers
{
    public class TagController : Controller
    {
        #region ArticleManager
        private ArticleManager _artMg;
        protected ArticleManager ArtMg
        {
            get
            {
                if (_artMg == null)
                {
                    _artMg = new ArticleManager();
                }
                return _artMg;
            }
            set { _artMg = value; }
        }
        #endregion

        #region Tag 获取Tag文章列表
        /// <summary>
        /// 根据Tag获取文章列表信息
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public ActionResult Tag(string tag)
        {
            ViewData["tag"] = tag;
            return View("Tag");
        }

        public ActionResult PartTag(string tag, int page=1, int size=25)
        {
            string filter = string.Empty;
            if (!string.IsNullOrEmpty(tag))
            {
                filter = string.Format(" Tag LIKE '%{0}%' ", tag);
            }
            PageList<VwArticle> model = this.ArtMg.GetList(page, size, filter);
            return PartialView("PartTag", model);
        }
        #endregion
    }
}
