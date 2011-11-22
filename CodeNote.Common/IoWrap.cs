using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using log4net;

namespace CodeNote.Common
{
    /// <summary>
    /// 包装用户操作IO的常用方法
    /// </summary>
    public class IoWrap
    {
        public static ILog log;
        static IoWrap()
        {
            log = LogManager.GetLogger(typeof(IoWrap));
        }

        public static bool WriteFile(string filePath, string fileContent)
        {
            return WriteFile(filePath, fileContent, false);
        }

        public static bool WriteFile(string filePath, string fileContent, bool isAppend)
        {
            try
            {
                log.Info("WriteFile: " + filePath);

                string pathName = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(pathName))
                {
                    Directory.CreateDirectory(pathName);
                }
                using (StreamWriter sw = new StreamWriter(filePath, isAppend, Encoding.UTF8))
                {
                    sw.WriteLine(fileContent);
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return false;
            }
        }
    }
}
