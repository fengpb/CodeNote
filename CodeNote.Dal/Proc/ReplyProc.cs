using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Data.Linq;

using CodeNote.Entity;

namespace CodeNote.Dal.Proc
{
    public class ReplyProc : CodeNote.Linq.IDal.DataContext
    {
        [Function(Name = "SP_Reply_List")]
        public ISingleResult<Reply> GetList(
            [Parameter(Name = "PageIndex")]int page,
            [Parameter(Name = "PageSize")]int pageSize,
            [Parameter(Name = "Filter")]string filter,
            [Parameter(Name = "OrderBy")]string orderBy,
            [Parameter(Name = "RowCount")]ref int rowCount)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), page, pageSize, filter, orderBy, rowCount);
            rowCount = (int)result.GetParameterValue(4);

            return (ISingleResult<Reply>)result.ReturnValue;
        }
    }
}
