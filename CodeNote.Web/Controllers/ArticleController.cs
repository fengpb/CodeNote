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
using CodeNote.Web.Models;
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
        [CheckLogin]
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
        /// 获取分类中最近更新的Top 10 条信息
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public ActionResult ArticleNew(string categoryID)
        {
            IList<Article> model = ArtMg.GetNewList(10, categoryID);
            return PartialView("ArticleNew", model);
        }

        /// <summary>
        /// 添加文章信息
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false), CheckLogin]
        public ActionResult DoAdd()
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

            return View("Result", new ReturnMessage("提示消息", retValue));
        }

        /// <summary>
        /// 查看文章信息
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        public ActionResult Detail(int articleID)
        {
            VwArticle model = this.ArtMg.Get(articleID);
            if (model == null)
            {
                return View("Result", new ReturnMessage("错误", "对不起！您查看的文章信息不存在！"));
            }
            return View("Detail", model);
        }

        /// <summary>
        /// 文章列表信息
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ArticleList(string categoryID, int page = 1)
        {
            PageList<Article> model = ArtMg.GetListByCategory(page, 20, categoryID);
            return PartialView("ArticleList", model);
        }
    }
}
