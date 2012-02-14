using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#region uing user
using log4net;
using CodeNote.Common;
using CodeNote.Entity;
using CodeNote.Dal;
using Antlr.StringTemplate;
#endregion

namespace CodeNote.Manager
{
    /// <summary>
    /// 用于生产html页面
    /// </summary>
    public class HtmlManager
    {
        private static ILog log;
        static HtmlManager()
        {
            log = LogManager.GetLogger(typeof(HtmlManager));
        }

        #region STATIC_HTML_DIR
        private readonly string STATIC_HTML_DIR = "static_html_dir";
        private readonly string SITE_MAP_FILE = "site_map_file";
        #endregion

        #region CreateHtml
        /// <summary>
        /// 创建文章的静态html页面
        /// </summary>
        /// <param name="artID">文章ID</param>
        /// <returns></returns>
        public ReturnValue CreateHtml(int artID)
        {
            ArticleManager artMg = new ArticleManager();
            VwArticle art = artMg.Get(artID);
            if (art != null)
            {
                return CreateHtml(art);
            }
            return new ReturnValue(false, "文章为空");
        }

        /// <summary>
        /// 创建文章的静态html页面
        /// </summary>
        /// <param name="article">文章实体</param>
        /// <returns></returns>
        public ReturnValue CreateHtml(VwArticle article)
        {
            ReturnValue retValue = new ReturnValue(false, "生成失败");
            if (article == null || article.ID < 0)
            {
                log.Info("CreateHtml article is null !");
                retValue.Message = "参数不正确";
                return retValue;
            }
            Html htm = this.Get(article.ID);
            if (htm == null)//没有静态页记录
            {
                htm = new Html();
                htm.ArtID = article.ID;
                htm.Url = CodeNote.Common.IDentity.CreateNew().AddStr("/").AddDate("yyyy").AddStr("/").AddDate("MM").AddStr("/").AddDate("ddHHmmssff").AddStr(5).StrID() + ".html";
                article.HtmlUrl = htm.Url;
                htm.Upda = article.ModDate;
            }
            else
            {
                htm.Upda = article.ModDate;
                log.Info("Modify: " + article.Subject + " => " + htm.Url);
            }
            if (CreateHtml(article, htm))
            {
                retValue = this.AddOrEdit(htm);
            }
            return retValue;
        }

        /// <summary>
        /// 生成静态页面信息
        /// </summary>
        /// <param name="article">文章信息</param>
        /// <param name="html">html页面信息</param>
        /// <returns></returns>
        protected bool CreateHtml(VwArticle article, Html html)
        {
            StringTemplate st = CodeNote.Common.TemplateWrap.GetSt("article_detail");
            if (st != null)
            {
                article.Body = CodeNote.Markdown.Default.Transform(article.Body);
                //markdown to html
                st.SetAttribute("update", html.Upda);
                st.SetAttribute("keywords", article.Tag);//搜索关键字
                st.SetAttribute("taglinks", TagInfoManager.TagLinks(article.Tag));
                st.SetAttribute("description", CodeNote.Common.StringFilter.ClearHtml(article.Body,200));
                st.SetAttribute("entity", article);

                return CodeNote.Common.IoWrap.WriteFile(CodeNote.Common.ConfigWrap.FiePath(STATIC_HTML_DIR) + html.Url, st.ToString());
            }
            else
            {
                log.Warn("Not find 'article_detail.st' template !");
            }
            return false;
        }
        #endregion

        #region RefreshSiteMap 刷新站点地图
        /// <summary>
        /// 用于更新sitemap.xml
        /// </summary>
        /// <returns></returns>
        public ReturnValue RefreshSiteMap()
        {
            ReturnValue retValue = new ReturnValue();
            IList<Html> list = null;
            using (HtmlDal dal = new HtmlDal())
            {
                list = dal.SiteMapList();
            }
            if (list != null)
            {
                StringTemplate st = CodeNote.Common.TemplateWrap.GetSt("sitemap_xml");
                if (st != null)
                {
                    st.SetAttribute("list", list);
                    st.SetAttribute("date", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszd"));
                    st.SetAttribute("domain", CodeNote.Common.ConfigWrap.FileUrl("domain"));
                    st.SetAttribute("baseurl", CodeNote.Common.ConfigWrap.FileUrl(STATIC_HTML_DIR, true));
                    if (CodeNote.Common.IoWrap.WriteFile(CodeNote.Common.ConfigWrap.FiePath(SITE_MAP_FILE), st.ToString()))
                    {
                        retValue.IsExists = true;
                        retValue.Message = "Refresh stiemap suuuessful!";
                    }
                    else
                    {
                        retValue.IsExists = false;
                        retValue.Message = "Refresh stiemap error!";
                    }
                }
                else
                {
                    log.Warn("Not find 'sitemap_xml.st' template !");
                }
            }
            else
            {
                retValue.IsExists = false;
                retValue.Message = "无数据";
            }
            return retValue;
        }
        #endregion

        public Html Get(int artID)
        {
            Html html = null;
            using (HtmlDal dal = new HtmlDal())
            {
                html = dal.Get(artID);
            }
            return html;
        }

        public Html GetOrAdd(int artID)
        {
            Html html = null;
            html = this.Get(artID);
            if (html == null)
            {

                ReturnValue retValue = CreateHtml(artID);
                if (retValue != null && retValue.IsExists)
                {
                    html = this.Get(artID);
                }
            }
            else
            {
                string htmlPath = CodeNote.Common.ConfigWrap.FiePath(STATIC_HTML_DIR) + html.Url;
                if (!System.IO.File.Exists(htmlPath))
                {
                    CreateHtml(artID);
                }
                else
                {
                    ArticleManager artMg = new ArticleManager();
                    VwArticle art = artMg.Get(artID);
                    if (art != null && art.ModDate != html.Upda)
                    {
                        CreateHtml(art);
                    }
                }
            }
            return html;
        }

        public ReturnValue AddOrEdit(Html html)
        {
            ReturnValue retValue = new ReturnValue();
            if (html == null || html.ArtID < 0)
            {
                retValue.IsExists = false;
                retValue.Message = "html 信息为空";
                return retValue;
            }
            Html old = this.Get(html.ArtID);

            using (HtmlDal dal = new HtmlDal())
            {
                if (old == null)
                {
                    if (dal.Add(html))
                    {
                        retValue.IsExists = true;
                        retValue.Message = "页面信息添加成功";
                    }
                    else
                    {
                        retValue.IsExists = false;
                        retValue.Message = "页面信息添加失败";
                    }
                }
                else//修改
                {
                    if (dal.Modify(html))
                    {
                        retValue.IsExists = true;
                        retValue.Message = "页面信息修改成功";
                    }
                    else
                    {
                        retValue.IsExists = false;
                        retValue.Message = "页面信息修改失败";
                    }
                }
            }
            return retValue;
        }
    }
}
