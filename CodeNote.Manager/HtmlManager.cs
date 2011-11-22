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
        private readonly string STATIC_HTML_DIR = "Statis_Html_Dir";

        #endregion

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
                htm.Upda = DateTime.Now;
            }
            else
            {
                htm.Upda = DateTime.Now;
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
        /// <param name="article"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        protected bool CreateHtml(VwArticle article, Html html)
        {
            StringTemplate st = CodeNote.Common.TemplateWrap.GetSt("article_detail");
            if (st != null)
            {
                //markdown to html
                article.Body = CodeNote.Markdown.Default.Transform(article.Body);

                st.SetAttribute("entity", article);
                st.SetAttribute("update", html.Upda);
                st.SetAttribute("keywords", article.Tag);
                st.SetAttribute("taglinks", TagInfoManager.TagLinks(article.Tag));
                return CodeNote.Common.IoWrap.WriteFile(CodeNote.Common.ConfigWrap.FiePath(STATIC_HTML_DIR) + html.Url, st.ToString());
            }
            else
            {
                log.Warn("Not find 'article_detail.st' template !");
            }
            return false;
        }

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
                    //比较时间进行同步
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
                    if (dal.UpDate(html.ArtID))
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
