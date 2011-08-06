using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
#region Using users.
using CodeNote.Common;
using CodeNote.Entity;
using CodeNote.Manager;
using CodeNote.Web.Filter;
#endregion
namespace CodeNote.Web.Controllers
{

    /// <summary>
    /// Veiws/Article
    /// </summary>
    public class ArticleController : BaseController
    {

        private ArticleManager _artMg;
        public ArticleManager ArtMg
        {
            get
            {
                if (_artMg == null) { _artMg = new ArticleManager(); }
                return _artMg;
            }
        }

        public ActionResult AddArticle()
        {
            return View("AddArticle");
        }
        [CheckLogin]
        public ActionResult EditArticle()
        {
            return PartialView("EditArticle");
        }



        /// <summary>
        /// 添加文章信息
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false),CheckLogin]
        public JsonResult DoAdd()
        {
            ReturnValue retValue = new ReturnValue();
            string body = Request["body"];

            Article entity = new Article();
            entity.Subject = Request["subject"];
            entity.Body = Common.MarkDown.Transform(body);
            entity.CategoryID = Request["category"];
            entity.Tag = Request["artitag"];
            entity.CreateID = CurUser.ID;
            entity.CreateDate = DateTime.Now;


            retValue = ArtMg.Add(entity);

            return Json(retValue);
        }



        public ActionResult ArticleList(string categoryID, int page = 1)
        {
            string filter = string.Empty;
            if (!string.IsNullOrEmpty(categoryID))
            {
                filter = " CategoryID LIKE '" + categoryID + "%'";
            }
            PageList<Article> model = ArtMg.GetList(page, 20,filter);
            return PartialView("ArticleList", model);
        }
    }
}
