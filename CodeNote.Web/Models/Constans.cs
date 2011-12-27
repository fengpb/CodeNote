using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Web.Models
{
    /// <summary>
    /// 静态变量
    /// </summary>
    public class Constans
    {
        public static readonly string USER_SESSION_KEY = "cur_user_session_key";
        public static readonly string USER_SESSION_KEY_TOKEN = "cur_user_session_key_token";

        public enum UserType
        {
            NoReg = -2,
            Administrators = -1,
            User = 0
        }

        public enum TagType
        {
            SysTag = -1,
            UserTag = 0
        }
    }
}
