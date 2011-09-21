using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Common;
using System.Web;

namespace CodeNote.Web.Models
{
    /// <summary>
    /// 消息实体
    /// </summary>
    public class ReturnMessage
    {

        #region ReturnMessage
        public ReturnMessage()
        {
        }
        public ReturnMessage(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public ReturnMessage(HttpRequestBase request, string title, ReturnValue retValue)
        {
            this.Title = title;
            this.RetValue = retValue;
            this.BackUrl = request.UrlReferrer.AbsolutePath;
        }

        public ReturnMessage(HttpRequestBase request,string title, string content)
        {
            this.Title = title;
            this.BackUrl = request.UrlReferrer.AbsolutePath;
            this.Content = content;
        }
        #endregion

        public string BackUrl { get; set; }
        public string Title { get; set; }
        private string _content;
        public string Content
        {
            get
            {
                if (string.IsNullOrEmpty(_content))
                {
                    _content = this.RetValue.Message;
                }
                return _content;
            }
            set { _content = value; }
        }

        public ReturnValue RetValue { get; set; }
    }
}
