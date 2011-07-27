using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#region using users.
using CodeNote.Entity;
using CodeNote.Dal;
using CodeNote.Common;
#endregion
namespace CodeNote.Manager
{
    public class LoginUserManager
    {
        public ReturnValue Login(string userNameOrEmail, string password)
        {
            ReturnValue retValue = new ReturnValue();
            using (LoginUserDal dal = new LoginUserDal())
            {
                LoginUser user = dal.Get(userNameOrEmail);
                //加密比较
                if (user != null)
                {
                    if (user.PassWord != password)
                    {
                        retValue.IsExists = false;
                        retValue.Message = "密码输入错误";
                        return retValue;
                    }
                    retValue.IsExists = true;
                    retValue.Message = "登录成功";
                    retValue.RetObjec = user;
                }
                else
                {
                    retValue.IsExists = false;
                    retValue.Message = "此用户不存在";
                    return retValue;
                }
            }
            return retValue;
        }
    }
}
