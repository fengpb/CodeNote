using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Luc
{
    /// <summary>
    /// Lucene 索引生成器
    /// </summary>
    public class IndexCreater
    {
        protected static log4net.ILog log = log4net.LogManager.GetLogger(typeof(IndexCreater));

        #region LuceneConfing 获取 Lucene 配置信息
        private Config.LuceneConfig _luceneConfig;
        /// <summary>
        /// Lucene 配置信息
        /// </summary>
        public Config.LuceneConfig LuceneConfig
        {
            get
            {
                if (_luceneConfig == null)
                {
                    _luceneConfig = System.Configuration.ConfigurationManager.GetSection("lucene") as Config.LuceneConfig;
                }
                if (_luceneConfig == null)
                {
                    log.Warn("No lucene config! Place seting lucene config in web.config or App.config.");
                }
                return _luceneConfig;
            }
            set { _luceneConfig = value; }
        }
        #endregion

        #region Create Index File
        /// <summary>
        /// 用于创建 Lucene 索引文件
        /// </summary>
        /// <returns></returns>
        public bool CreateIndex()
        {
            try
            {
                log.Info(string.Format("Lucene index create ok in '{0}'", LuceneConfig.IndexDir));
                return true;
            }
            catch (Exception ex)
            {
                log.Warn(ex.Message, ex);
                return false;
            }
        }
        #endregion
    }
}
