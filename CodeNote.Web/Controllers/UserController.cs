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

        #region LogOn
        public ActionResult LogOn()
        {
            return Login();
        }
        public ActionResult Login()
        {
            return View("Login");
        }
        #endregion

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
            retValue = LoginUserMg.Login(name, CodeNote.Common.Encryption.MD5(password), Request.UserHostAddress);
            if (retValue.IsExists)
            {
                Common.SessionWrap.Add(Web.Models.Constans.USER_SESSION_KEY, retValue.RetObjec);
                return RedirectToAction("Index", "Account");
            }
            return View("Result", new ReturnMessage(Request, "登录消息", retValue));
        }

        /// <summary>
        /// eg. Check email or longname
        /// <br/>
        /// 判断电子邮件或登陆名是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public JsonResult IsNull(string key)
        {
            ReturnValue retValue = new ReturnValue(true, "此用户未注册");

            if (string.IsNullOrEmpty(key))
            {
                retValue.IsExists = false;
                retValue.Message = "不能为空";
                return Json(retValue);
            }

            if (this.LoginUserMg.Get(key) != null)
            {
                if (CurUser != null)
                {
                    if (key != CurUser.LoginName)
                    {
                        retValue.IsExists = false;
                        retValue.Message = "对不起，此信息已经注册!";
                    }
                }
                else
                {
                    retValue.IsExists = false;
                    retValue.Message = "对不起，此信息已经注册!";
                }
            }
            else
            {
                retValue.IsExists = true;
            }
            return Json(retValue);
        }

        #region Register
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
                entity.PassWord = CodeNote.Common.Encryption.MD5(CodeNote.Common.IDentity.CreateNew().AddStr(10).StrID());
            }
            else
            {
                entity = new LoginUser();
                entity.LoginName = email;
                entity.Email = email;
                entity.PassWord = CodeNote.Common.Encryption.MD5(CodeNote.Common.IDentity.CreateNew().AddStr(10).StrID());
                entity.Type = (int)Constans.UserType.NoReg;//未完成注册的用户
                entity.CreateDate = DateTime.Now;
            }

            retValue = this.LoginUserMg.AddOrEdit(entity);//保存和修改信息

            if (retValue.IsExists)
            {
                string url = this.UrlPath("Valid", "User", new { email = email, valid = entity.PassWord, type = "reg" });
                Antlr.StringTemplate.StringTemplate st = CodeNote.Common.TemplateWrap.GetSt("register_email");
                if (st != null)
                {
                    st.SetAttribute("url", url);

                    if (CodeNote.Common.Net.Mail.EmailWrap.Default.Send(email, "注册验证 - Register validation", st.ToString(), true))
                    {
                        retValue.IsExists = true;
                        retValue.Message = "电子邮件发送成功";
                        retValue.PutValue("emailserver", CodeNote.Common.Net.Mail.EmailWrap.EmailServer(email));
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
                    retValue.IsExists = false;
                    retValue.Message = "注册电子邮件未发送";
                    return View("Result", new ReturnMessage("服务器错误", retValue.Message));
                }
            }
            else
            {
                return View("Result", new ReturnMessage("服务器错误", retValue.Message));
            }
        }
        #endregion

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
            string type = Request["type"];//验证类型

            ReturnValue retValue = new ReturnValue();
            retValue = this.LoginUserMg.Login(email, valid, Request.UserHostAddress);
            if (retValue.IsExists)
            {
                retValue.IsExists = true;
                retValue.Message = "验证成功,继续完成注册!";
                Common.SessionWrap.Add(Web.Models.Constans.USER_SESSION_KEY, retValue.RetObjec);//保存用户信息
                if (!string.IsNullOrEmpty(type))
                {
                    switch (type.Trim().ToLower())
                    {
                        case "fpwd":
                            LoginUser ret = retValue.RetObjec as LoginUser;
                            ret.Type = (int)Constans.UserType.NoReg;
                            retValue.RetObjec = ret;
                            break;
                    }
                }
                return View("EditUser", retValue.RetObjec);
            }
            else
            {
                retValue.IsExists = false;
                retValue.Message = "对不起你的连接无效! 请重新发送注册确认邮件! ";
                return View("Result", new ReturnMessage("验证失败", retValue.Message));
            }
        }

        #region EditUser
        [Filter.CheckLogin]
        public ActionResult EditUser()
        {
            return View("EditUser", CurUser);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        [Filter.CheckLogin]
        public ActionResult DoModify()
        {
            LoginUser login = new LoginUser();
            login.ID = CodeNote.Common.ConvertWrap.ToInt(Request["userid"]);
            login.Email = Request["email"];
            login.LoginName = Request["loginname"];
            if (string.IsNullOrEmpty(Request["oldpassword"]))
            {
                login.PassWord = Request["oneoldpassword"];
            }
            else
            {
                login.PassWord = CodeNote.Common.Encryption.MD5(Request["oldpassword"]);
            }
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
                    login.PassWord = CodeNote.Common.Encryption.MD5(newPassWord);
                    isChangePwd = true;
                }
            }

            ReturnValue retValue = new ReturnValue();

            retValue = this.LoginUserMg.AddOrEdit(login);//修改用户信息

            if (retValue.IsExists && isChangePwd)
            {
                Antlr.StringTemplate.StringTemplate st = CodeNote.Common.TemplateWrap.GetSt("modify_pwd_email");

                if (st != null)
                {
                    st.SetAttribute("account", login.LoginName);
                    st.SetAttribute("newpwd", newPassWord);

                    CodeNote.Common.Net.Mail.EmailWrap.Default.Send(login.Email, login.LoginName + "修改密码提示 - Change Password.", st.ToString(), true);
                }
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
        #endregion

        /// <summary>
        /// 没有权限
        /// </summary>
        /// <returns></returns>
        public ActionResult NoPower()
        {
            return View("NoPower");
        }

        /// <summary>
        /// 忘记秘密/找回密码
        /// </summary>
        /// <returns></returns>
        public ActionResult Fpwd()
        {
            return View("Fpwd");
        }

        /// <summary>
        /// 用于重置密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetPwd()
        {
            ReturnValue retValue = new ReturnValue(true, "重置密码成功");
            string email = Request["email"];
            if (string.IsNullOrEmpty(email))
            {
                retValue.IsExists = false;
                retValue.Message = "请输入电子邮件地址";
            }
            if (retValue.IsExists)
            {
                LoginUser entity = this.LoginUserMg.Get(email);//获取用户信息
                if (entity != null)
                {
                    string url = this.UrlPath("Valid", "User", new { email = email, valid = entity.PassWord, type = "fpwd" });
                    //发送重置密码的电子邮件通知
                    Antlr.StringTemplate.StringTemplate st = CodeNote.Common.TemplateWrap.GetSt("find_pwd_email");
                    if (st != null)
                    {
                        st.SetAttribute("account", entity.LoginName);
                        st.SetAttribute("url", url);

                        if (CodeNote.Common.Net.Mail.EmailWrap.Default.Send(email, "找回密码 - Find password", st.ToString(), true))
                        {
                            retValue.IsExists = true;
                            retValue.Message = "请登陆您的邮箱,进行密码找回";
                        }
                        else
                        {
                            retValue.IsExists = false;
                            retValue.Message = "对不起,发送找回密码邮件时失败！";
                        }
                    }
                    else
                    {
                        retValue.IsExists = false;
                        retValue.Message = "找回密码邮件未发送";
                    }
                }
                else
                {
                    retValue.Message = "对不起,您输入的电子邮件不是本站的注册用户。";
                }
            }

            return View("Result", new ReturnMessage(Request, "操作信息", retValue));
        }
    }
}
