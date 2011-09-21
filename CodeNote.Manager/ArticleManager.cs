using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
#region Using users.
using CodeNote.Entity;
using CodeNote.Dal;
using CodeNote.Common;
using log4net;
#endregion

namespace CodeNote.Manager
{
    public class ArticleManager
    {
        protected static ILog log;
        static ArticleManager()
        {
            log = LogManager.GetLogger(typeof(ArticleManager));
        }

        public ReturnValue AddOrEdit(Article entity)
        {
            ReturnValue retValue = new ReturnValue();
            if (string.IsNullOrEmpty(entity.Subject))
            {
                retValue.IsExists = false;
                retValue.Message = "标题不能为空";
                return retValue;
            }
            if (string.IsNullOrEmpty(entity.Body))
            {
                retValue.IsExists = false;
                retValue.Message = "正文不能为空";
                return retValue;
            }

            using (ArticleDal dal = new ArticleDal())
            {
                VwArticle old = null;
                if (entity.ID > 1)
                {
                    old = dal.GetVw(entity.ID);
                }
                if (old == null)
                {
                    if (dal.Add(entity))
                    {
                        retValue.IsExists = true;
                        retValue.Message = "保存成功";
                    }
                    else
                    {
                        retValue.IsExists = false;
                        retValue.Message = "保存失败";
                    }
                }
                else //修改
                {
                    if (dal.Modify(entity))
                    {
                        retValue.IsExists = true;
                        retValue.Message = "修改成功";
                    }
                    else
                    {
                        retValue.IsExists = false;
                        retValue.Message = "修改失败";
                    }
                }
            }



            return retValue;
        }

        public VwArticle Get(int articleID)
        {
            if (articleID < 1)
            {
                return null;
            }
            using (ArticleDal dal = new ArticleDal())
            {
                return dal.GetVw(articleID);
            }
        }

        /// <summary>
        /// 获取文章列表分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PageList<VwArticle> GetList(int page, int pageSize, string filter)
        {
            PageList<VwArticle> pa = new PageList<VwArticle>();
            using (ArticleDal dal = new ArticleDal())
            {
                int rowCount = 0;
                pa.CurPage = page;
                pa.PageSize = pageSize;
                pa.Data = dal.GetList(page, pageSize, filter, ref rowCount);
                pa.RecordCount = rowCount;
            }
            return pa;
        }

        #region GetNewList 获取最新日志信息
        /// <summary>
        /// 获取最新的文章信息
        /// </summary>
        /// <param name="topNum"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public IList<VwArticle> GetNewList(int topNum, string categoryID, string filter)
        {
            if (topNum < 0)
            {
                return null;
            }

            using (ArticleDal dal = new ArticleDal())
            {
                return dal.GetNewList(topNum, categoryID, filter);
            }
        }
        #endregion

        public IList<VwArticle> GetRecList(int topNum, VwArticle article, string filter)
        {
            return null;
        }

        #region GetListByCategory 根据分类获取日志信息
        /// <summary>
        /// 通过文章分类获取文章信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public PageList<VwArticle> GetListByCategory(int page, int pageSize, string categoryID)
        {
            string filter = string.Empty;
            if (!string.IsNullOrEmpty(categoryID))
            {
                filter = " CategoryID LIKE '" + categoryID + "%'";
                if (log.IsDebugEnabled)
                {
                    log.Debug(string.Format("GetArticleList: filter => {0}", filter));
                }
            }
            return this.GetList(page, pageSize, filter);
        }
        #endregion
    }
}
