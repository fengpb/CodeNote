using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Web.Models
{
    /// <summary>
    /// Global Data 网站全局数据信息
    /// </summary>
    public class SiteData
    {
        private SiteData _instance;
        public SiteData Instance
        {
            get { if (_instance == null) { _instance = new SiteData(); } return _instance; }
        }
    }
}
