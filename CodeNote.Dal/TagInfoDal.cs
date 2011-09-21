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
    }
}
