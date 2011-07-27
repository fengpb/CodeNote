using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CodeNote.Web.Common
{
    public class CookieWrap
    {

        private static HttpContext CurContext
        {
            get
            {
                return System.Web.HttpContext.Current;
            }
        }

        public static void AddCookie(string key, string data)
        {
            if (!string.IsNullOrEmpty(key) && data != null)
            {
                CurContext.Response.Cookies.Add(WrapCookie(key, data));
            }
        }

        public static void AddCookie<T>(string key, T data) where T : class,new()
        {
            AddCookie(key, SerializedWrap.JsonSerialize<T>(data));
        }

        private static HttpCookie WrapCookie(string key, string data)
        {
            HttpCookie cookie = new HttpCookie(key);
            cookie.Value = data;
            cookie.Expires = DateTime.Now.AddMonths(1);
            return cookie;
        }

        private static HttpCookie WrapCookie<T>(string key, T data) where T : class,new()
        {
            return WrapCookie(key, SerializedWrap.JsonSerialize<T>(data));
        }

        public static T GetCookie<T>(string key) where T : class, new()
        {
            if (string.IsNullOrEmpty(key))
                return null;
            string serializStr = GetCookie(key);
            T t = null;
            if (!string.IsNullOrEmpty(serializStr))
            {
                t = new T();
                t = SerializedWrap.JsonDesrialize<T>(serializStr);
            }
            return t;
        }

        public static string GetCookie(string key)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;
            HttpCookie cookie = CurContext.Request.Cookies[key];
            if (cookie == null)
                return string.Empty;
            return CurContext.Request.Cookies[key].Value;
        }

        public static void RemoveCookie(string key)
        {
            if (!string.IsNullOrEmpty(key))
                CurContext.Response.Cookies.Remove(key);
        }
    }
}