using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Entity;

namespace CodeNote.Web
{
    /// <summary>
    /// Global Data 网站全局数据信息
    /// </summary>
    public class SiteData
    {
        private static SiteData _instance;
        public static SiteData Instance
        {
            get { if (_instance == null) { _instance = new SiteData(); } return _instance; }
        }
        private Category _curCategory;
        public Category CurCategory
        {
            get
            {
                if (_curCategory == null)
                {
                    _curCategory = new Category() { CategoryID = "Index", Name = "首页" };
                }

                return _curCategory;
            }
            set { _curCategory = value; }
        }

        public LoginUser CurUser
        {
            get { return Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY); }
        }

        public bool IsAdmin
        {
            get
            {
                if (IsLogin && CurUser.Type == (int)CodeNote.Web.Models.Constans.UserType.Administrators)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsLogin
        {
            get
            {
                if (Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY) != null)
                {
                    return true;
                }
                return false;
            }
        }

        private string _domain;
        /// <summary>
        /// 网站域名
        /// </summary>
        public string Domain
        {
            get
            {
                if (string.IsNullOrEmpty(_domain))
                {
                    _domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
                }
                return _domain;
            }
        }
        private string _htmlDir;
        /// <summary>
        /// 静态文件目录
        /// </summary>
        public string HtmlDir
        {
            get
            {
                if (string.IsNullOrEmpty(_htmlDir))
                {
                    _htmlDir = CodeNote.Common.ConfigWrap.FileUrl("Statis_Html_Dir",true);
                }
                return _htmlDir;
            }
        }
    }
}
