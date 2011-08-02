using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
#region Using users.
using CodeNote.Common;
using CodeNote.Entity;
using CodeNote.Manager;
#endregion
namespace CodeNote.Web.Controllers
{

    /// <summary>
    /// Veiws/Article
    /// </summary>
    public class ArticleController : Controller
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

        public ActionResult EditArticle()
        {
            return PartialView("EditArticle");
        }



        /// <summary>
        /// 添加文章信息
        /// </summary>
        /// <returns></returns>
        public JsonResult DoAdd()
        {
            ReturnValue retValue = new ReturnValue();
            string subject = Request["subject"].ToString();
            string body = Request["body"].ToString();
            string categoryID = Request["category"].ToString();
            string tag = Request["artitag"].ToString();


            Article entity = new Article();
            entity.Subject = subject;
            entity.Body = body;
            entity.CategoryID = categoryID;
            entity.Tag = tag;
            entity.CreateID = 0;
            entity.CreateDate = DateTime.Now;


            retValue = ArtMg.Add(entity);

            return Json(retValue);
        }



        public ActionResult ArticleList(string categoryID, int page = 1)
        {
            PageList<Article> model = ArtMg.GetList(page, 20, "");
            return PartialView("ArticleList", model);
        }
    }
}
