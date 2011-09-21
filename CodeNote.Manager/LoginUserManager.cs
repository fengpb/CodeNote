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

        public ReturnValue AddOrEdit(LoginUser entity)
        {
            ReturnValue retValue = new ReturnValue();
            using (LoginUserDal dal = new LoginUserDal())
            {
                if (entity.ID < 1)//添加 
                {
                    if (dal.Add(entity))
                    {
                        retValue.IsExists = true;
                        retValue.Message = "添加用户成功";
                    }
                    else
                    {
                        retValue.IsExists = false;
                        retValue.Message = "添加用户失败";
                    }
                }
                else//修改
                {
                    if (dal.Modify(entity))
                    {
                        retValue.IsExists = true;
                        retValue.Message = "修改用户成功";
                    }
                    else
                    {
                        retValue.IsExists = false;
                        retValue.Message = "修改用户失败";
                    }
                }
            }
            return retValue;
        }


        public LoginUser Get(string userNameOrEmail)
        {
            using (LoginUserDal dal = new LoginUserDal())
            {
                return dal.Get(userNameOrEmail);
            }
        }


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
