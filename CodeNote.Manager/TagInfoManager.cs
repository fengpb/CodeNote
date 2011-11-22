using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Common;
using CodeNote.Dal;
using log4net;
using CodeNote.Entity;

namespace CodeNote.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public class TagInfoManager
    {
        protected ILog log = LogManager.GetLogger(typeof(TagInfoManager));

        /// <summary>
        /// 添加标签信息
        /// </summary>
        /// <param name="tagNamestr"></param>
        /// <param name="tagType"></param>
        /// <returns></returns>
        public ReturnValue AddTag(string tagNamestr, int tagType)
        {
            string[] tags = tagNamestr.Split(new char[] { ' ', ',', '-', ';' });
            ReturnValue retValue = new ReturnValue();
            using (TagInfoDal dal = new TagInfoDal())
            {
                foreach (string item in tags)
                {
                    if (dal.AddTag(item, tagType))
                    {
                        retValue.PutValue("ok", retValue.GetInt("ok") + 1);
                    }
                    else
                    {
                        retValue.PutValue("error", retValue.GetInt("error") + 1);
                    }
                }
            }
            log.Info(string.Format("Add Tags : ok {0} ,error {1}", retValue.GetInt("ok"), retValue.GetInt("error")));
            return retValue;
        }

        /// <summary>
        /// 获取标签列表
        /// <br/>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PageList<TagInfo> GetList(int page, int size, string filter)
        {
            PageList<TagInfo> list = new PageList<TagInfo>();
            using (TagInfoDal dal = new TagInfoDal())
            {
                int count = 0;
                list.Data = dal.GetList(page, size, filter, ref count);
                list.RecordCount = count;
                list.CurPage = page;
                list.PageSize = size;
            }
            return list;
        }


        public static string TagLinks(string tags)
        {
            StringBuilder sb = new StringBuilder();

            string[] arr = tags.Split(new Char[] { ',', ' ', '-', ';' });
            foreach (string item in arr)
            {
                //<a href="/Tag/%E6%96%B0%E9%97%BB">新闻</a>
                string temp = "<a href=\"/Tag/{0}\">{1}</a>";

                sb.Append(string.Format(temp, item, item) + "&nbsp;");
            }
            return sb.ToString();
        }
    }
}
