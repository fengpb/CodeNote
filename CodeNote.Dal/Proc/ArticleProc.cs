﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Reflection;

using CodeNote.Entity;

namespace CodeNote.Dal.Proc
{
    public class ArticleProc : CodeNote.Linq.IDal.DataContext
    {
        [Function(Name = "SP_Article_New")]
        public ISingleResult<VwArticle> SP_Article_New(
            [Parameter(Name = "TopNum")]int topNum, 
            [Parameter(Name = "CategoryID")]string categoryID,
            [Parameter(Name = "Filter")]string filter)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), topNum, categoryID,filter);
            return (ISingleResult<VwArticle>)result.ReturnValue;
        }

        [Function(Name = "SP_Article_List")]
        public ISingleResult<VwArticle> SP_Article_List(
            [Parameter(Name = "PageIndex")]int page,
            [Parameter(Name = "PageSize")]int pageSize,
            [Parameter(Name = "Filter")]string filter,
            [Parameter(Name = "RowCount")]ref int rowCount)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), page, pageSize, filter, rowCount);
            rowCount = (int)result.GetParameterValue(3);
            return (ISingleResult<VwArticle>)result.ReturnValue;
        }
    }
}
