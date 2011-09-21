using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
#region using users.
using CodeNote.Entity;
using CodeNote.Manager;
using CodeNote.Common;
using CodeNote.Web.Models;
#endregion
namespace CodeNote.Web.Controllers
{
    /// <summary>
    /// 网站用户信息
    /// </summary>
    public class UserController : CodeNote.Web.BaseController
    {
        #region LoginUserMg
        private LoginUserManager _loginUserMg;
        public LoginUserManager LoginUserMg
        {
            get
            {
                if (_loginUserMg == null)
                { _loginUserMg = new LoginUserManager(); }
                return _loginUserMg;
            }
        }
        #endregion

        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult LoginOut()
        {
            //退出登录
            Common.SessionWrap.Remove(Web.Models.Constans.USER_SESSION_KEY);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DoLogin(string name, string password)
        {
            ReturnValue retValue = new ReturnValue();
            if (string.IsNullOrEmpty(name))
            {
                retValue.IsExists = false;
                retValue.Message = "请输入登录名";
                return View("Result", new ReturnMessage(Request, "登录消息", retValue));
            }
            if (string.IsNullOrEmpty(password))
            {
                retValue.IsExists = false;
                retValue.Message = "请输入密码";
                return View("Result", new ReturnMessage(Request, "登录消息", retValue));
            }
            retValue = LoginUserMg.Login(name, password);
            if (retValue.IsExists)
            {
                Common.SessionWrap.Add(Web.Models.Constans.USER_SESSION_KEY, retValue.RetObjec);
                return RedirectToAction("Index", "Account");
            }
            return View("Result", new ReturnMessage(Request, "登录消息", retValue));
        }

        /// <summary>
        /// 判断电子邮件或登陆名是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult IsNull(string key)
        {
            ReturnValue retValue = new ReturnValue();

            if (string.IsNullOrEmpty(key))
            {
                retValue.IsExists = false;
                retValue.Message = "不能为空";
                return Json(retValue);
            }
            if (key != CurUser.LoginName)
            {
                if (this.LoginUserMg.Get(key) != null)
                {
                    retValue.IsExists = false;
                    retValue.Message = "对不起，此信息已经注册!";
                }
                else
                {
                    retValue.IsExists = true;
                }
            }
            return Json(retValue);
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        /// <summary>
        /// 执行注册方法
        /// </summary>
        /// <returns></returns>
        public ActionResult DoReg(string email)
        {
            ReturnValue retValue = new ReturnValue();
            if (!CodeNote.Common.Validation.Email(email))
            {
                retValue.IsExists = false;
                retValue.Message = "电子邮件格式不正确";
                return View("Result", new ReturnMessage("参数错误", retValue.Message));
            }
            LoginUser entity = this.LoginUserMg.Get(email);

            if (entity != null && entity.Type != (int)Constans.UserType.NoReg)
            {
                retValue.IsExists = false;
                retValue.Message = "此用户已经注册";

                return View("Result", new ReturnMessage("注册错误", retValue.Message));
            }
            if (entity != null && entity.Type == (int)Constans.UserType.NoReg)
            {
                //暂不做处理
            }
            else
            {
                entity = new LoginUser();
                entity.LoginName = email;
                entity.Email = email;
                entity.PassWord = CodeNote.Common.IDentity.CreateNew().AddStr(10).StrID();
                entity.Type = (int)Constans.UserType.NoReg;//为完成注册的用户
                entity.CreateDate = DateTime.Now;
                retValue = this.LoginUserMg.AddOrEdit(entity);
            }
            if (retValue.IsExists)
            {
                StringBuilder content = new StringBuilder("请点击下面连接完成注册或将下面连接复制到浏览器地址栏直接访问！<br/>");
                string url = this.UrlPath("Valid", "User", new { email = email, valid = entity.PassWord });
                content.Append(string.Format("<a href=\"{0}\" target=\"_back\">{1}</a>", url, url));

                if (CodeNote.Common.Net.Mail.EmailWrap.Default.Send(email, "注册验证邮件 - troublecode", content.ToString(), true))
                {
                    retValue.IsExists = true;
                    retValue.Message = "电子邮件发送成功";
                    return View("DoReg", retValue);
                }
                else
                {
                    retValue.IsExists = false;
                    retValue.Message = "电子邮件发送错误,请重新发送";
                    return View("Result", new ReturnMessage("参数错误", retValue.Message));
                }
            }
            else
            {
                return View("Result", new ReturnMessage("服务器错误", retValue.Message));
            }
        }

        /// <summary>
        /// 通过验证用户点击过来的连接继续注册步骤
        /// <br/>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Valid()
        {
            string email = Request["email"];//email地址
            string valid = Request["valid"];//验证信息

            ReturnValue retValue = new ReturnValue();
            retValue = this.LoginUserMg.Login(email, valid);
            if (retValue.IsExists)
            {
                retValue.IsExists = true;
                retValue.Message = "验证成功,继续完成注册!";
                Common.SessionWrap.Add(Web.Models.Constans.USER_SESSION_KEY, retValue.RetObjec);//保存用户信息
                return View("EditUser", retValue.RetObjec);
            }
            else
            {
                retValue.IsExists = false;
                retValue.Message = "对不起你的连接无效! 请重新发送注册确认邮件! ";
                return View("Result", new ReturnMessage("验证失败", retValue.Message));
            }
        }

        [Filter.CheckLogin]
        public ActionResult EditUser()
        {
            return View("EditUser", CurUser);
        }


        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DoModify()
        {
            LoginUser login = new LoginUser();
            login.ID = CodeNote.Common.ConvertWrap.ToInt(Request["userid"]);
            login.LoginName = Request["loginname"];
            login.PassWord = Request["oldpassword"];
            login.Type = CodeNote.Common.ConvertWrap.ToInt(Request["usertype"]);
            login.CreateDate = DateTime.Now;
            if (login.Type == (int)Constans.UserType.NoReg)
            {
                login.Type = (int)Constans.UserType.User;
            }

            string newPassWord = Request["newpassword"];
            string newpwssword2 = Request["newpwssword2"];
            if (newPassWord != newpwssword2)
            {
                return View("Result", new ReturnMessage("秘密设置错误", "两次输入密码不相同! "));
            }
            if (login.ID != CurUser.ID)
            {
                return View("Result", new ReturnMessage("验证失败", "对不起，请不要弄我了，我伤不起的! "));
            }

            if (!string.IsNullOrEmpty(login.PassWord))
            {
                if (login.PassWord != CurUser.PassWord)
                {
                    return View("Result", new ReturnMessage("验证失败", "对不起，密码输入错误!<br/><p><a href=\"\">忘记密码</a></p> "));
                }
            }

            bool isChangePwd = false;
            if (!string.IsNullOrEmpty(login.PassWord))
            {
                if (!string.IsNullOrEmpty(newPassWord) && newPassWord != login.PassWord)
                {
                    login.PassWord = newPassWord;
                    isChangePwd = true;
                }
            }

            ReturnValue retValue = new ReturnValue();

            retValue = this.LoginUserMg.AddOrEdit(login);

            if (retValue.IsExists && isChangePwd)
            {
                StringBuilder content = new StringBuilder();
                content.Append(string.Format("Dear {0}:<br/> 你的登录密码已经成功修改为: {1}<hr/>{2}", login.LoginName, login.PassWord, SiteData.Instance.Domain));
                CodeNote.Common.Net.Mail.EmailWrap.Default.Send(login.Email, login.LoginName + "修改密码", content.ToString(), true);
            }

            Account account = new Account();

            if (retValue.IsExists)
            {
                LoginUser temp = this.LoginUserMg.Get(login.Email);
                if (temp == null)
                {
                    temp = this.LoginUserMg.Get(login.LoginName);
                }
                Common.SessionWrap.Add(Web.Models.Constans.USER_SESSION_KEY, temp);//更新用户信息
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View("Result", new ReturnMessage("修改信息", "呵呵，这么莫名其妙，居然修改失败了!你好悲剧阿! 赶快祈求上帝把!"));
            }
        }

        /// <summary>
        /// 没有权限
        /// </summary>
        /// <returns></returns>
        public ActionResult NoPower()
        {
            return View("NoPower");
        }
    }
}
