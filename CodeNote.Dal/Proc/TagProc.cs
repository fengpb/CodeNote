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
    /// <summary>
    /// 标签管理
    /// </summary>
    public class TagProc : CodeNote.Linq.IDal.DataContext
    {
        [Function(Name = "SP_TagInfo_Add")]
        public int SP_TagInfo_Add([Parameter(Name = "Name")]string name, [Parameter(Name = "Type")]int type)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), name, type);
            return (int)result.ReturnValue;
        }

        [Function(Name = "SP_TagInfo_List")]
        public ISingleResult<TagInfo> SP_TagInfo_List(
            [Parameter(Name = "PageIndex")]int page,
            [Parameter(Name = "PageSize")]int pageSize,
            [Parameter(Name = "Filter")]string filter,
            [Parameter(Name = "RowCount")]ref int rowCount)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), page, pageSize, filter, rowCount);
            rowCount = (int)result.GetParameterValue(3);
            return (ISingleResult<TagInfo>)result.ReturnValue;
        }
    }
}
