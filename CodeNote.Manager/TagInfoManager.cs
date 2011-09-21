using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Common;
using CodeNote.Dal;
using log4net;

namespace CodeNote.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public class TagInfoManager
    {
        protected ILog log = LogManager.GetLogger(typeof(TagInfoManager));

        public ReturnValue AddTag(string tagNamestr,int tagType)
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
    }
}
