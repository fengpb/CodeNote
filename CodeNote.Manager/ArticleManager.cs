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

        public ReturnValue Add(Article entity)
        {
            ReturnValue retValue = new ReturnValue();
            if (string.IsNullOrEmpty(entity.Subject))
            {
                retValue.IsExists = false;
                retValue.Message = "标题不能为空";
            }
            if (string.IsNullOrEmpty(entity.Body))
            {
                retValue.IsExists = false;
                retValue.Message = "正文不能为空";
            }
            if (retValue.IsExists)
            {
                using (ArticleDal dal = new ArticleDal())
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
            }
            return retValue;
        }

        /// <summary>
        /// 获取文章列表分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PageList<Article> GetList(int page, int pageSize, string filter)
        {
            PageList<Article> pa = new PageList<Article>();
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

        /// <summary>
        /// 通过文章分类获取文章信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public PageList<Article> GetListByCategory(int page, int pageSize, string categoryID)
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

    }
}
