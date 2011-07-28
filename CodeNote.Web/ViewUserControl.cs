using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Entity;
namespace CodeNote.Web
{
    public class ViewUserControl : System.Web.Mvc.ViewUserControl
    {
        public SiteData SiteData { get { return SiteData.Instance; } }

        public LoginUser CurUser
        {
            get
            {
                return Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY);
            }
        }
        public bool IsLogin { get { return CurUser != null; } }

        /// <summary>
        /// 支持 gravatar.com face
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string FaceImgUrl(string email)
        {
            string irl = "http://www.gravatar.com/avatar/{0}?s=48&d=identicon&r=pg";

            return string.Format(irl, CodeNote.Common.Encryption.MD5(email));
        }
    }
    public class ViewUserControl<T> : System.Web.Mvc.ViewUserControl<T>
    {
        public SiteData SiteData { get { return SiteData.Instance; } }
        public LoginUser CurUser
        {
            get
            {
                return Common.SessionWrap.Get<LoginUser>(Models.Constans.USER_SESSION_KEY);
            }
        }
        public bool IsLogin { get { return CurUser != null; } }

        /// <summary>
        /// 支持 gravatar.com face
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string FaceImgUrl(string email)
        {
            string irl = "http://www.gravatar.com/avatar/{0}?s=48&d=identicon&r=pg";

            return string.Format(irl, CodeNote.Common.Encryption.MD5(email));
        }
    }
}
