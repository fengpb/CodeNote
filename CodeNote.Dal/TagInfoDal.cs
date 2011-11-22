using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Entity;
using CodeNote.Dal.Proc;

namespace CodeNote.Dal
{
    public class TagInfoDal : CodeNote.Linq.IDal.BaseDalImpl<TagInfo>
    {
        /// <summary>
        /// 添加标签信息
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="tagType"></param>
        /// <returns></returns>
        public bool AddTag(string tagName, int tagType)
        {
            using (TagProc proc = new TagProc())
            {
                if (proc.SP_TagInfo_Add(tagName, tagType) > 0)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// 获取标签列表信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="filter"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IList<TagInfo> GetList(int page, int size, string filter, ref int count)
        {
            using (TagProc proc = new TagProc())
            {
                return proc.SP_TagInfo_List(page, size, filter, ref count).ToList();
            }
        }
    }
}
