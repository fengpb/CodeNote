using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Common;
using CodeNote.Entity;
using CodeNote.Dal;

namespace CodeNote.Manager
{
    /// <summary>
    /// 回复管理
    /// </summary>
    public class ReplyManager
    {
        #region Add
        public ReturnValue Add(Reply entity)
        {
            ReturnValue retValue = new ReturnValue();
            if (entity.ArticleID < 1)
            {
                retValue.IsExists = false;
                retValue.Message = "回复对象未知";
                return retValue;
            }
            if (string.IsNullOrEmpty(entity.Nick))
            {
                retValue.IsExists = false;
                retValue.Message = "请输入昵称";
                return retValue;
            }
            if (string.IsNullOrEmpty(entity.Email))
            {
                retValue.IsExists = false;
                retValue.Message = "请输入电子邮件地址";
                return retValue;
            }
            if (string.IsNullOrEmpty(entity.Body))
            {
                retValue.IsExists = false;
                retValue.Message = "请输入回复内容";
                return retValue;
            }


            using (ReplyDal dal = new ReplyDal())
            {
                if (dal.Add(entity))
                {
                    retValue.IsExists = true;
                    retValue.Message = "回复成功";
                }
                else
                {
                    retValue.IsExists = false;
                    retValue.Message = "回复失败";
                }

            }
            return retValue;
        }
        #endregion

        #region GetList
        public PageList<Reply> GetList(int page, int pageSize, string filter)
        {
            PageList<Reply> pa = new PageList<Reply>();
            using (ReplyDal dal = new ReplyDal())
            {
                int rowCount = 0;
                pa.CurPage = page;
                pa.PageSize = pageSize;
                pa.Data = dal.GetList(page, pageSize, filter, "", ref rowCount);
                pa.RecordCount = rowCount;
            }
            return pa;
        }
        public PageList<Reply> GetList(int articleID, int page, int pageSize)
        {
            if (articleID < 1)
            {
                return null;
            }
            return GetList(page, pageSize, " ArticleID =" + articleID);
        }

        #endregion
    }
}
