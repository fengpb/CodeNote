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
    public class UserController : System.Web.Mvc.Controller
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
                return View("Result", new ReturnMessage("登录消息", retValue));
            }
            if (string.IsNullOrEmpty(password))
            {
                retValue.IsExists = false;
                retValue.Message = "请输入密码";
                return View("Result", new ReturnMessage("登录消息", retValue));
            }
            retValue = LoginUserMg.Login(name, password);
            if (retValue.IsExists)
            {
                Common.SessionWrap.Add(Web.Models.Constans.USER_SESSION_KEY, retValue.RetObjec);
                return RedirectToAction("Index", "Account");
            }
            return View("Result", new ReturnMessage("登录消息", retValue));
        }

        public ActionResult Register()
        {
            return View("Register");
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
