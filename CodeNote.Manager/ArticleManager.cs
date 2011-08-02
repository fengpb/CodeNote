using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
#region Using users.
using CodeNote.Entity;
using CodeNote.Dal;
using CodeNote.Common;
#endregion

namespace CodeNote.Manager
{
    public class ArticleManager
    {
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

        public PageList<Article> GetList(int page, int pageSize, string filter)
        {
            PageList<Article> pa = new PageList<Article>();
            using (ArticleDal dal=new ArticleDal())
            {
                int rowCount = 0;
                pa.CurPage = page;
                pa.PageSize = pageSize;
                pa.Data = dal.GetList(page, pageSize, filter, ref rowCount);
                pa.RecordCount = rowCount;
            }
            return pa;
        }

    }
}
