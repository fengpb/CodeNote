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

            Article entity = new Article();
            entity.Subject = subject;
            entity.Body = body;

            ArticleManager articleManager = new ArticleManager();
            retValue = articleManager.Add(entity);

            return Json(retValue);
        }
    }
}
