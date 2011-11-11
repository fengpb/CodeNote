﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Luc.Config
{
    /// <summary>
    /// Lucene 配置读取器
    /// </summary>
    public class LuceneConfigSectionHandler : System.Configuration.IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            LuceneConfig lc = new LuceneConfig();
            foreach (System.Xml.XmlNode item in section)
            {
                if (item.Name == "index")
                {
                    lc.IndexDir = item.Attributes["dir"].Value;
                    lc.Cron = Convert.ToBoolean(item.Attributes["cron"].Value);
                }
            }
            return lc;
        }
    }

    public class LuceneConfig
    {
        /// <summary>
        /// 索引位置
        /// </summary>
        private string _indexDir;
        public string IndexDir
        {
            get { return _indexDir; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.StartsWith("/"))
                {
                    _indexDir = System.AppDomain.CurrentDomain.BaseDirectory + value.Substring(1);
                }
                else
                {
                    _indexDir = value;
                }
            }
        }

        /// <summary>
        /// 索引是否计划任务生成
        /// <br/>
        /// 暂时不使用
        /// </summary>
        public bool Cron { get; set; }
    }
}
