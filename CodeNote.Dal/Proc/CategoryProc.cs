﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Reflection;
#region Using users.
using CodeNote.Entity;
#endregion

namespace CodeNote.Dal.Proc
{
    public class CategoryProc : CodeNote.Linq.IDal.DataContent<Category>
    {
        public ISingleResult<Category> GetLike([Parameter(Name = "Key")]string likeCategoryID)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), likeCategoryID);
            return (ISingleResult<Category>)result.ReturnValue;
        }

    }
}