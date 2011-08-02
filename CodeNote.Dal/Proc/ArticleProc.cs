﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Reflection;
using CodeNote.Entity;

namespace CodeNote.Dal.Proc
{
    public class ArticleProc : System.Data.Linq.DataContext
    {
        public ArticleProc()
            : base(ConfigurationManager.ConnectionStrings["CodeNoteBlog"].ConnectionString)
        {
        }

        [Function(Name = "SP_Article_List")]
        public ISingleResult<Article> GetList(
            [Parameter(Name = "PageIndex")]int page,
            [Parameter(Name = "PageSize")]int pageSize,
            [Parameter(Name = "Filter")]string filter,
            [Parameter(Name = "RowCount")]ref int rowCount)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), page, pageSize, filter, rowCount);
            rowCount = (int)result.GetParameterValue(3);

            return (ISingleResult<Article>)result.ReturnValue;
        }
    }
}
