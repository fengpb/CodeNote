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
        #region ArticleManager
        private ArticleManager _artMg;
        public ArticleManager ArtMg
        {
            get
            {
                if (_artMg == null) { _artMg = new ArticleManager(); }
                return _artMg;
            }
        }
        #endregion

        #region AddOrEdit 添加/修改文章
        [CheckLogin]
        public ActionResult AddArticle()
        {

            return View("AddArticle");
        }

        [CheckLogin]
        public ActionResult EditArticle(int id)
        {
            VwArticle model = null;
            if (id > 0)
            {
                model = ArtMg.Get(id);
            }
            return View("EditArticle", model);
        }
        /// <summary>
        /// 添加文章信息
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false), CheckLogin]
        public ActionResult AddOrEdit()
        {
            ReturnValue retValue = new ReturnValue();

            Article entity = new Article();
            entity.ID = CodeNote.Common.ConvertWrap.ToInt(Request["articleid"]);
            entity.Subject = Request["subject"];
            entity.Body = Request["body"];
            entity.CategoryID = Request["category"];
            entity.Tag = Request["artitag"];
            entity.CreateID = CurUser.ID;
            entity.CreateDate = DateTime.Now;


            retValue = ArtMg.AddOrEdit(entity);

            if (retValue.IsExists)
            {//添加标签或修改标签
                TagInfoManager tagMg = new TagInfoManager();
                Models.Constans.TagType tagType = Constans.TagType.UserTag;
                if (CurUser != null && CurUser.Type == (int)Constans.UserType.Administrators)
                {
                    tagType = Constans.TagType.SysTag;
                }
                tagMg.AddTag(entity.Tag, (int)tagType);
            }

            return View("Result", new ReturnMessage(Request, "提示消息", retValue));
        }
        #endregion

        #region ArticleList 文章列表信息
        /// <summary>
        /// 文章列表信息
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult ArticleList(string categoryID, int page = 1)
        {
            PageList<VwArticle> model = ArtMg.GetListByCategory(page, 20, categoryID);
            return PartialView("ArticleList", model);
        }
        #endregion

        #region ArticleNew 最近更新
        /// <summary>
        /// 获取分类中最近更新的Top 10 条信息
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public ActionResult ArticleNew(string categoryID = "", string tag = "")
        {
            string filter = string.Empty;
            if (!string.IsNullOrEmpty(tag))
            {
                filter = string.Format(" Tag LIKE '%{0}%' ", tag);
            }
            IList<VwArticle> model = ArtMg.GetNewList(10, categoryID, filter);
            return PartialView("ArticleNew", model);
        }
        #endregion

        #region ArticleRec 相关推荐文章
        /// <summary>
        /// 相关推荐文章
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        public ActionResult ArticleRec(int articleID)
        {
            VwArticle article = this.ArtMg.Get(articleID);
            IList<VwArticle> model = null;
            if (article != null)
            {
                model = ArtMg.GetRecList(10, article, null);
            }
            return PartialView("ArticleRec", model);
        }
        #endregion

        #region Detail 查看文章信息
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
        #endregion

        #region Account Article
        /// <summary>
        /// 用户文章列表
        /// </summary>
        /// <returns></returns>
        [CheckLogin]
        public ActionResult AccArtList(int page = 1)
        {
            PageList<VwArticle> model = ArtMg.GetListByAccount(page, 20, CurUser.ID);
            model.CurController = "Article";
            model.CurAction = "AccArtList";
            return PartialView("SimArticleList", model);
        }
        #endregion
    }
}
