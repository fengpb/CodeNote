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
                return proc.GetList(page, pageSize, filter, ref rowCount).ToList();
            }
        }
    }
}
