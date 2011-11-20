using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.StringTemplate;

namespace CodeNote.Common
{
    /// <summary>
    /// String 模板
    /// </summary>
    public class TemplateWrap
    {
        protected static StringTemplateGroup Group { get; set; }

        protected static log4net.ILog log;

        protected static string TemplateDir
        {
            get
            {
                string tem = System.AppDomain.CurrentDomain.BaseDirectory + "/st";
                log.Debug("TemplateDir: " + tem);
                return tem;
            }
        }

        static TemplateWrap()
        {
            log = log4net.LogManager.GetLogger(typeof(TemplateWrap));
            Group = new StringTemplateGroup("CodeNote", TemplateDir, typeof(Antlr.StringTemplate.Language.DefaultTemplateLexer));
        }

        public static StringTemplate GetSt(string templateFileName)
        {

            if (string.IsNullOrEmpty(templateFileName))
            {
                return null;
            }
            else
            {
                return Group.GetInstanceOf(templateFileName);
            }
        }

    }
}
