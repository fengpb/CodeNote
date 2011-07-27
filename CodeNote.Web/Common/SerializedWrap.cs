using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Web.Common
{
    /// <summary>
    /// 序列化
    /// </summary>
    public class SerializedWrap
    {
        #region json Serizlize / Desrialize
        public static string JsonSerialize<T>(T obj) where T : class,new()
        {
            return CurJSS.Serialize(obj);
        }
        public static T JsonDesrialize<T>(string jsonStr) where T : class,new()
        {
            T t = null;
            if (!string.IsNullOrEmpty(jsonStr))
            {
                t = CurJSS.Deserialize<T>(jsonStr);
            }
            return t;
        }
        private static System.Web.Script.Serialization.JavaScriptSerializer _curJss;
        public static System.Web.Script.Serialization.JavaScriptSerializer CurJSS
        {
            get
            {
                if (_curJss == null)
                {
                    _curJss = new System.Web.Script.Serialization.JavaScriptSerializer();
                } return _curJss;
            }
        }
        #endregion
    }
}
