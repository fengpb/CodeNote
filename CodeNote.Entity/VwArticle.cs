using System;
using System.Text;
using System.Data.Linq.Mapping;
// create by codesmith 2011-08-10 22:23:20

namespace CodeNote.Entity
{
    [Table(Name = "vwArticle")]
    public class VwArticle
    {
        private int _iD;
        [Column(Name = "ID", DbType = "int")]
        public int ID
        {
            get { return this._iD; }
            set { this._iD = value; }
        }
        private string _subject;
        [Column(Name = "Subject", DbType = "nvarchar")]
        public string Subject
        {
            get { return this._subject; }
            set { this._subject = value; }
        }
        private string _body;
        [Column(Name = "Body", DbType = "text")]
        public string Body
        {
            get { return this._body; }
            set { this._body = value; }
        }
        private string _categoryID;
        [Column(Name = "CategoryID", DbType = "nvarchar")]
        public string CategoryID
        {
            get { return this._categoryID; }
            set { this._categoryID = value; }
        }
        private string _categoryTitle;
        [Column(Name = "CategoryTitle", DbType = "nvarchar")]
        public string CategoryTitle
        {
            get { return this._categoryTitle; }
            set { this._categoryTitle = value; }
        }
        private string _categoryName;
        [Column(Name = "CategoryName", DbType = "nvarchar")]
        public string CategoryName
        {
            get { return this._categoryName; }
            set { this._categoryName = value; }
        }
        private string _tag;
        [Column(Name = "Tag", DbType = "nvarchar")]
        public string Tag
        {
            get { return this._tag; }
            set { this._tag = value; }
        }
        private int _status;
        [Column(Name = "Status", DbType = "int")]
        public int Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        private int _replyCount;
        [Column(Name = "ReplyCount", DbType = "int")]
        public int ReplyCount
        {
            get { return this._replyCount; }
            set { this._replyCount = value; }
        }
        private int _clickCount;
        [Column(Name = "ClickCount", DbType = "int")]
        public int ClickCount
        {
            get { return this._clickCount; }
            set { this._clickCount = value; }
        }
        private int _createID;
        [Column(Name = "CreateID", DbType = "int")]
        public int CreateID
        {
            get { return this._createID; }
            set { this._createID = value; }
        }
        private string _createName;
        [Column(Name = "CreateName", DbType = "nvarchar")]
        public string CreateName
        {
            get { return this._createName; }
            set { this._createName = value; }
        }
        private string _createEmail;
        [Column(Name = "CreateEmail", DbType = "nvarchar")]
        public string CreateEmail
        {
            get { return this._createEmail; }
            set { this._createEmail = value; }
        }
        private DateTime _createDate;
        [Column(Name = "CreateDate", DbType = "datetime")]
        public DateTime CreateDate
        {
            get { return this._createDate; }
            set { this._createDate = value; }
        }

        private DateTime _modDate;
        [Column(Name = "ModDate", DbType = "datetime")]
        public DateTime ModDate
        {
            get { return this._modDate; }
            set { this._modDate = value; }
        }

        private string _htmlUrl;
        [Column(Name = "Url", DbType = "nvarchar")]
        public string HtmlUrl
        {
            get { return this._htmlUrl; }
            set { this._htmlUrl = value; }
        }
    }
}

