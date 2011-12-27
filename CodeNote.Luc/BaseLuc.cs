using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Luc
{
    /// <summary>
    /// Lucene 索引生成器
    /// </summary>
    public abstract class BaseLuc<T> where T : class
    {
        protected static log4net.ILog log;
        static BaseLuc()
        {
            log = log4net.LogManager.GetLogger(typeof(BaseLuc<T>));
        }

        protected Lucene.Net.Analysis.Analyzer Analyzer
        {
            get
            {
                return new Lucene.Net.Analysis.PanGu.PanGuAnalyzer();
                //return new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);//标准分词器
            }
        }

        #region LuceneConfing 获取 Lucene 配置信息
        private Config.LuceneConfig _luceneConfig;
        /// <summary>
        /// Lucene 配置信息
        /// </summary>
        protected Config.LuceneConfig LuceneConfig
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
        protected bool Create(string indexDir, T entity)
        {
            IList<T> list = new List<T>();
            list.Add(entity);
            //TODO: 删除索引


            return Create(indexDir, false, list);
        }

        /// <summary>
        /// 用于创建 Lucene 索引文件
        /// </summary>
        /// <returns></returns>
        protected bool Create(string indexDir, bool create, IList<T> list)
        {
            if (string.IsNullOrEmpty(indexDir))
            {
                log.Warn("Create indexdir isnullorempty !");
                return false;
            }
            Lucene.Net.Store.Directory indexStoreDir = null;
            Lucene.Net.Analysis.Analyzer analyzer = null;
            Lucene.Net.Index.IndexWriter indexWriter = null;
            bool retValue = false;

            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(indexDir);//索引目录
                indexStoreDir = Lucene.Net.Store.FSDirectory.Open(dir);//lucene索引
                analyzer = Analyzer;
                indexWriter = new Lucene.Net.Index.IndexWriter(indexStoreDir, analyzer, create, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);

                if (list != null)
                {
                    foreach (var item in list)
                    {
                        indexWriter.AddDocument(this.WrapDoc(item));
                    }
                }

                indexWriter.Optimize(false);
                indexWriter.Commit();
                if (create)
                {
                    log.Info(string.Format("Lucene index create ok in '{0}'. create num: {1}", LuceneConfig.IndexDir, list.Count));
                }
                else
                {
                    log.Info(string.Format("Lucene index append ok in '{0}'. append num: {1}", LuceneConfig.IndexDir, list.Count));
                }
                retValue = true;
            }
            catch (Exception ex)
            {
                log.Warn(ex.Message, ex);
                retValue = false;
            }
            finally
            {
                if (indexWriter != null)
                    indexWriter.Close();
                if (analyzer != null)
                    analyzer.Close();
                if (indexStoreDir != null)
                    indexStoreDir.Close();
            }
            return retValue;
        }
        #endregion

        #region Search Index File
        protected IList<T> Search(string indexDir, string key, string[] searchFields, int topN, out int totalHits)
        {
            if (LuceneConfig.AutoSCI)
            {
                this.CreateIndex();
            }

            IList<T> list = null;
            totalHits = 0;
            if (string.IsNullOrEmpty(indexDir))
            {
                log.Warn("Search indexdir isnullorempty !");
                return null;
            }

            Lucene.Net.Store.Directory indexStoreDir = null;
            Lucene.Net.Analysis.Analyzer analyzer = null;
            Lucene.Net.Search.IndexSearcher indexSearch = null;

            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(indexDir);//索引目录
                indexStoreDir = Lucene.Net.Store.FSDirectory.Open(dir);//lucene索引
                analyzer = Analyzer;
                indexSearch = new Lucene.Net.Search.IndexSearcher(indexStoreDir, false);

                Lucene.Net.QueryParsers.QueryParser qp = new Lucene.Net.QueryParsers.MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, searchFields, analyzer);
                qp.SetDefaultOperator(Lucene.Net.QueryParsers.QueryParser.AND_OPERATOR);
                Lucene.Net.Search.Query queryField = qp.Parse(key);

                //高亮显示 Highlighter.Net
                Lucene.Net.Highlight.SimpleHTMLFormatter simpleHTMLFormatter = new Lucene.Net.Highlight.SimpleHTMLFormatter("<em>", "</em>");
                Lucene.Net.Highlight.Highlighter highlighter = new Lucene.Net.Highlight.Highlighter(simpleHTMLFormatter, new Lucene.Net.Highlight.QueryScorer(queryField));


                Lucene.Net.Search.TopDocs topDocs = indexSearch.Search(queryField, topN);
                totalHits = topDocs.totalHits;
                if (topDocs != null && topDocs.scoreDocs != null)
                {
                    list = new List<T>();
                    foreach (var item in topDocs.scoreDocs)
                    {
                        Lucene.Net.Documents.Document doc = indexSearch.Doc(item.doc);
                        list.Add(this.WrapEntity(doc, analyzer, highlighter));
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
            finally
            {
                if (indexSearch != null)
                    indexSearch.Close();
                if (analyzer != null)
                    analyzer.Close();
                if (indexStoreDir != null)
                    indexStoreDir.Close();
            }
            return list;
        }
        #endregion

        #region Delete Index
        public bool Delete(string indexDir, string key, string field)
        {

            bool retValue = false;
            if (string.IsNullOrEmpty(indexDir) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(field))
            {
                return retValue;
            }

            Lucene.Net.Store.Directory indexStoreDir = null;
            Lucene.Net.Analysis.Analyzer analyzer = null;
            Lucene.Net.Index.IndexWriter indexWriter = null;

            try
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(indexDir);//索引目录
                indexStoreDir = Lucene.Net.Store.FSDirectory.Open(dir);//lucene索引
                analyzer = Analyzer;
                indexWriter = new Lucene.Net.Index.IndexWriter(indexStoreDir, analyzer, false, Lucene.Net.Index.IndexWriter.MaxFieldLength.LIMITED);

                Lucene.Net.Index.Term term = new Lucene.Net.Index.Term(field, key);

                indexWriter.DeleteDocuments(term);
                indexWriter.Optimize(false);
                indexWriter.Commit();

                log.Info(string.Format("Delete index term={0}. ", term.ToString()));
                log.Info(string.Format("MaxDoc={0} ,NumDocs={1}", indexWriter.MaxDoc(), indexWriter.NumDocs()));
                retValue = true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                retValue = false;
            }
            finally
            {
                if (indexWriter != null)
                    indexWriter.Close();
                if (analyzer != null)
                    analyzer.Close();
                if (indexStoreDir != null)
                    indexStoreDir.Close();
            }

            return retValue;
        }
        #endregion

        /// <summary>
        /// 对关键字分词
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="ktTokenizer"></param>
        /// <returns></returns>
        public string GetKeyWordsSplitBySpace(string keywords, Lucene.Net.Analysis.PanGu.PanGuTokenizer ktTokenizer)
        {
            StringBuilder result = new StringBuilder();
            ICollection<PanGu.WordInfo> words = ktTokenizer.SegmentToWordInfos(keywords);
            foreach (PanGu.WordInfo word in words)
            {
                if (word == null)
                {
                    continue;
                }
                result.AppendFormat("{0}^{1}.0 ", word.Word, (int)Math.Pow(3, word.Rank));
            }
            return result.ToString().Trim();
        }

        #region abstract method
        public abstract void CreateIndex();
        public abstract void ModifyIndex(T entity);

        /// <summary>
        /// 包装Document对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract Lucene.Net.Documents.Document WrapDoc(T entity);

        /// <summary>
        /// 包装Entity对象
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public abstract T WrapEntity(Lucene.Net.Documents.Document doc, Lucene.Net.Analysis.Analyzer analyzer, Lucene.Net.Highlight.Highlighter highlighter);
        #endregion
    }
}
