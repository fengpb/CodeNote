using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Luc
{
    public class ArtilceLuc : BaseLuc<CodeNote.Entity.VwArticle>
    {
        public override void CreateIndex()
        {
            IList<Entity.VwArticle> list = null;
            Manager.ArticleManager artMg = new Manager.ArticleManager();
            list = artMg.GetAllList();
            base.Create(LuceneConfig.IndexDir, true, list);
        }

        public override void ModifyIndex(Entity.VwArticle entity)
        {
            if (base.Delete(LuceneConfig.IndexDir, entity.ID.ToString(), "ID"))
            {
                base.Create(LuceneConfig.IndexDir, entity);
            }
        }

        public Common.PageList<Entity.VwArticle> Search(string key, int page, int size)
        {
            DateTime dtSt = DateTime.Now;
            Common.PageList<Entity.VwArticle> pageList = new Common.PageList<Entity.VwArticle>();
            IList<Entity.VwArticle> list = null;
            int totalHits = 0;
            
            //key = base.GetKeyWordsSplitBySpace(key, new Lucene.Net.Analysis.PanGu.PanGuTokenizer());

            list = base.Search(LuceneConfig.IndexDir, key, new string[] { "Subject", "Body" }, page * size, out totalHits);

            pageList.RecordCount = totalHits;
            pageList.CurPage = page;
            pageList.PageSize = size;

            IList<Entity.VwArticle> data = new List<Entity.VwArticle>();
            if (list != null)
            {
                int start = (page - 1) * size;
                for (int i = start; i < list.Count; i++)
                {
                    data.Add(list[i]);
                }
            }
            DateTime dtEnd = DateTime.Now;
            TimeSpan ts = dtEnd - dtSt;
            pageList.Data = data;
            pageList.Msecond = ts.TotalMilliseconds;
            return pageList;
        }

        public override Lucene.Net.Documents.Document WrapDoc(Entity.VwArticle entity)
        {
            Lucene.Net.Documents.Document doc = new Lucene.Net.Documents.Document();
            doc.Add(new Lucene.Net.Documents.Field("ID", entity.ID.ToString(), Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NOT_ANALYZED));
            doc.Add(new Lucene.Net.Documents.Field("Subject", entity.Subject, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED));
            doc.Add(new Lucene.Net.Documents.Field("Body", CodeNote.Common.StringFilter.ClearHtml(CodeNote.Markdown.Default.Transform(entity.Body), true), Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED));
            doc.Add(new Lucene.Net.Documents.Field("HtmlUrl", entity.HtmlUrl, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NOT_ANALYZED));
            doc.Add(new Lucene.Net.Documents.Field("ModDate", CodeNote.Common.ConvertWrap.ToDateStr(entity.ModDate), Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NOT_ANALYZED));
            return doc;
        }

        public override Entity.VwArticle WrapEntity(Lucene.Net.Documents.Document doc, Lucene.Net.Analysis.Analyzer analyzer, Lucene.Net.Highlight.Highlighter highlighter)
        {
            Entity.VwArticle entity = new Entity.VwArticle();
            string subject = doc.Get("Subject");
            string body = doc.Get("Body");
            entity.ID = CodeNote.Common.ConvertWrap.ToInt(doc.Get("ID"));
            entity.HtmlUrl = doc.Get("HtmlUrl");
            entity.ModDate = CodeNote.Common.ConvertWrap.ToDate(doc.Get("ModDate"));

            //高亮显示
            Lucene.Net.Analysis.TokenStream tokenStream = analyzer.TokenStream("Subject", new System.IO.StringReader(subject));
            Lucene.Net.Analysis.TokenStream tsContent = analyzer.TokenStream("Body", new System.IO.StringReader(body));
            string newSubject = highlighter.GetBestFragments(tokenStream, subject, 1, "..");
            string newBody = highlighter.GetBestFragments(tsContent, body, 2, "..");

            if (!string.IsNullOrEmpty(newSubject))
                subject = newSubject;
            if (!string.IsNullOrEmpty(newBody))
                body = newBody;

            entity.Subject = subject;
            entity.Body = body;

            return entity;
        }
    }
}
