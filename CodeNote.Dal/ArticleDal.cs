using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#region Using users.
using CodeNote.Linq.IDal;
using CodeNote.Entity;
using CodeNote.Dal.Proc;
#endregion
namespace CodeNote.Dal
{
    /// <summary>
    /// 文章Dal
    /// </summary>
    public class ArticleDal : BaseDalImpl<Article>
    {

        public bool Modify(Article entity)
        {
            try
            {
                Article old = Get(entity.ID);
                if (old == null)
                {
                    return false;
                }
                old.Subject = entity.Subject;
                old.Body = entity.Body;
                old.ClickCount = entity.ClickCount;
                if (!string.IsNullOrEmpty(entity.CategoryID) && old.CategoryID != entity.CategoryID)
                { old.CategoryID = entity.CategoryID; }
                old.ReplyCount = entity.ReplyCount;
                old.Status = entity.Status;
                if (!string.IsNullOrEmpty(entity.Tag) && old.Tag != entity.Tag)
                {
                    old.Tag = entity.Tag;
                }

                this.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return false;
            }
        }

        public IList<VwArticle> GetList(int page, int pageSize, string filter, ref int rowCount)
        {
            using (ArticleProc proc = new ArticleProc())
            {
                return proc.SP_Article_List(page, pageSize, filter, ref rowCount).ToList();
            }
        }

        public IList<VwArticle> GetNewList(int topNum, string categoryID,string filter)
        {
            using (ArticleProc proc = new ArticleProc())
            {
                return proc.SP_Article_New(topNum, categoryID,filter).ToList();
            }
        }


        public Article Get(int articleID)
        {
            return this.DataTable.Where(x => x.ID == articleID).SingleOrDefault();
        }

        public VwArticle GetVw(int articleID)
        {
            try
            {
                return this.GetTable<VwArticle>().Where(x => x.ID == articleID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return null;
            }
        }
    }
}
