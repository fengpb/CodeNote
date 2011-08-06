using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CodeNote.Web.Common
{
    public class SessionWrap
    {
        private static HttpContext CurContext
        {
            get
            {
                return System.Web.HttpContext.Current;
            }
        }
        public static void Add<T>(string key, T data)
        {
            CurContext.Session.Add(key, data);
        }

        public static void Add(string key, Object obj)
        {
            CurContext.Session.Add(key, obj);
        }

        public static T Get<T>(string key) where T : class
        {
            return CurContext.Session[key] as T;
        }

        public static Object Get(string key)
        {
            return CurContext.Session[key];
        }

        public static void Remove(string key)
        {
            CurContext.Session.Remove(key);
        }
    }
}
