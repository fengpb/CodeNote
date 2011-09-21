using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Data.Linq;

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
    }
}
