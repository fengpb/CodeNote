using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Reflection;
#region using users.
using CodeNote.Entity;

#endregion

namespace CodeNote.Dal.Proc
{
    public class LoginUserProc : CodeNote.Linq.IDal.DataContext
    {
        
        //SP_User_Login
        [Function(Name = "SP_User_Login")]
        public ISingleResult<LoginUser> Get([Parameter(Name = "LoginName")]string LoginName)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, (MethodInfo)MethodInfo.GetCurrentMethod(), LoginName);
            return (ISingleResult<LoginUser>)result.ReturnValue;
        }
    }
}
