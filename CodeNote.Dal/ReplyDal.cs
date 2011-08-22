using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#region using
using CodeNote.Entity;
using CodeNote.Linq.IDal;
using CodeNote.Dal.Proc;
#endregion

namespace CodeNote.Dal
{
    public class ReplyDal : BaseDalImpl<Reply>
    {
        /// <summary>
        /// 获取回复分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public IList<Reply> GetList(int page, int pageSize, string filter, string orderBy, ref int rowCount)
        {
            using (ReplyProc proc = new ReplyProc())
            {
                return proc.GetList(page, pageSize, filter, orderBy, ref rowCount).ToList();
            }
        }
    }
}
