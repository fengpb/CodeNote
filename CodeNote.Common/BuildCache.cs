using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace CodeNote.Common
{
    public class BuildCache<T> : BuildCache where T : class
    {

        static BuildCache()
        {
            log = log4net.LogManager.GetLogger(typeof(BuildCache<T>));
        }
        private ObjectCache _cacheInstance;
        protected ObjectCache CacheInstance
        {
            get { if (_cacheInstance == null) { _cacheInstance = MemoryCache.Default; } return _cacheInstance; }
        }
        private static BuildCache<T> _default;

        public static BuildCache<T> Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new BuildCache<T>();
                }
                return _default;
            }
        }

        public void Cache(string key, T data)
        {
            CacheItemPolicy cip = new CacheItemPolicy();
            FileChangeMonitor fileCM = SetFileChangeMonitor(key);
            cip.RemovedCallback = CacheRemoveCallBack;
            if (fileCM != null)
            {
                cip.ChangeMonitors.Add(fileCM);
            }
            else
            {
                cip.AbsoluteExpiration = DateTimeOffset.Now.AddHours(2);
                cip.Priority = CacheItemPriority.Default;
            }
            this.CacheInstance.Add(key, data, cip);
        }

        public T Get(string key)
        {
            if (this.CacheInstance.Get(key) == null)
            {
                return null;
            }
            return this.CacheInstance.Get(key) as T;
        }


    }

    public class BuildCache
    {
        protected static log4net.ILog log;
        /// <summary>
        /// 移除缓存
        /// <br/>
        /// 改变缓存文件
        /// </summary>
        /// <param name="key"></param>
        public static void CacheRemove(string key)
        {
            ChangeMonitorFileDateNow(key, true);
        }

        protected static FileChangeMonitor SetFileChangeMonitor(string key)
        {
            string monitorFile = GetCacheMoniorFile(key);
            ChangeMonitorFileDateNow(key, true);
            IList<string> filePaths = new List<string>();
            filePaths.Add(monitorFile);
            FileChangeMonitor changeMonitor = new HostFileChangeMonitor(filePaths);
            return changeMonitor;
        }

        protected static string GetCacheMoniorFile(string key)
        {
            string dir = System.Configuration.ConfigurationManager.AppSettings["FileChangeMonitor_Dir"];
            if (string.IsNullOrEmpty(dir))
            {
                log.Warn("You mast set appsetings FileChangeMonitor_Dir");
                return null;
            }
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
                log.Info("Create cache monitor dir! " + dir);
            }
            string monitorFile = dir + "/" + key + ".cachemonitor";
            if (!System.IO.File.Exists(monitorFile))
            {
                System.IO.File.Create(monitorFile);
            }
            return monitorFile;
        }

        protected static void ChangeMonitorFileDateNow(string key, bool append)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(GetCacheMoniorFile(key), append))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssffffff"));
            }

        }
        protected void CacheRemoveCallBack(CacheEntryRemovedArguments args)
        {
            log.Info("Remove Cahce: " + args.CacheItem.Key);
        }
    }
}

