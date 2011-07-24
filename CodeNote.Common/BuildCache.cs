using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace CodeNote.Common
{
    public class BuildCache
    {
        private ObjectCache _cacheInstance;
        protected ObjectCache CacheInstance
        {
            get { if (_cacheInstance == null) { _cacheInstance = MemoryCache.Default; } return _cacheInstance; }
        }

        public void Build<T>(string key, IList<T> data) where T : class
        {
            this.CacheInstance.Add(key, data, DateTimeOffset.Now.AddHours(2));
        }

        public IList<T> Data<T>(string key) where T : class
        {
            if (this.CacheInstance.Get(key) == null)
            {
                return null;
            }
            return this.CacheInstance.Get(key) as IList<T>;
        }
    }
}
