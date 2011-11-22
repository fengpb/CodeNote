using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Common
{
    /// <summary>
    /// 用于读取Web.config信息
    /// </summary>
    public class ConfigWrap
    {
        static ConfigWrap()
        {
            log = log4net.LogManager.GetLogger(typeof(ConfigWrap));
        }

        protected static log4net.ILog log;

        public static string FiePath(string key, bool isAppDomain)
        {
            string tmp = System.Configuration.ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(tmp) && tmp.StartsWith("/") && isAppDomain)
            {
                tmp = System.AppDomain.CurrentDomain.BaseDirectory + tmp.Substring(1);
            }
            log.Debug("FiePath: " + key + " = " + tmp);
            return tmp;
        }

        public static string FiePath(string key)
        {
            return FiePath(key, true);

        }

        public static string FileUrl(string key)
        {
            return FileUrl(key, false);
        }
        public static string FileUrl(string key, bool isdomain)
        {
            string tmp = System.Configuration.ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(tmp) && tmp.StartsWith("/") && isdomain)
            {
                tmp = System.Configuration.ConfigurationManager.AppSettings["Domain"] + tmp;
            }
            log.Debug("FileUrl: " + key + " = " + tmp);
            return tmp;
        }
    }
}
