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

        public static string FiePath(string key)
        {
            string tmp = System.Configuration.ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(tmp) && tmp.StartsWith("/"))
            {
                tmp = System.AppDomain.CurrentDomain.BaseDirectory + tmp.Substring(1);
            }
            log.Debug(key + " = " + tmp);
            return tmp;
        }
    }
}
