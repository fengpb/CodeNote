using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CodeNote.Common
{
    public class PageList<T> where T : class
    {
        private IList<T> _data;
        private int _recordCount = -1;
        public int PageSize { set; get; }
        public int CurPage { set; get; }
        /// <summary>
        /// 当前请求的 action
        /// </summary>
        public string CurAction { set; get; }
        /// <summary>
        /// 当前请求的 Controller
        /// </summary>
        public string CurController { set; get; }
        public int TotolPage
        {
            get { return (int)Math.Ceiling(RecordCount / (double)PageSize); }
        }
        /// <summary>
        /// 设置或获取当前列表的项集合。将该属性设置为null时每次获取时将得到一个空列表
        /// </summary>
        public IList<T> Data
        {
            get { return _data ?? new List<T>(0); }
            set { _data = value; }
        }

        /// <summary>
        /// 完整列表包含项目的总数
        /// </summary>
        public int RecordCount
        {
            get { return _recordCount; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                _recordCount = value;
            }
        }

    }
}
