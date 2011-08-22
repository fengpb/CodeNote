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

        public IList<Article> GetList(int page, int pageSize, string filter, ref int rowCount)
        {
            using (ArticleProc proc = new ArticleProc())
            {
                return proc.SP_Article_List(page, pageSize, filter, ref rowCount).ToList();
            }
        }

        public IList<Article> GetNewList(int topNum, string categoryID)
        {
            using (ArticleProc proc = new ArticleProc())
            {
                return proc.SP_Article_New(topNum, categoryID).ToList();
            }
        }

        public VwArticle Get(int articleID)
        {
            try
            {
                return this.GetTable<VwArticle>().Where(x => x.ID == articleID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Warn(ex.Message, ex);
                return null;
            }
        }
    }
}
