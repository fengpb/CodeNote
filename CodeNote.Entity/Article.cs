using System;
using System.Text;
using System.Data.Linq.Mapping;
// create by codesmith 2011-07-24 02:38:42

namespace CodeNote.Entity
{   
    [Table(Name="Article")]
    public class Article
    {
        private int _iD;
        [Column(Name="ID",DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int ID
        {
            get{ return this._iD ; }
            set{ this._iD = value ; }
        }
        private string _subject;
        [Column(Name="Subject",DbType = "nvarchar", CanBeNull = false)]
        public string Subject
        {
            get{ return this._subject ; }
            set{ this._subject = value ; }
        }
        private string _body;
        [Column(Name="Body",DbType = "text", CanBeNull = false)]
        public string Body
        {
            get{ return this._body ; }
            set{ this._body = value ; }
        }
        private string _categoryID;
        [Column(Name="CategoryID",DbType = "nvarchar", CanBeNull = false)]
        public string CategoryID
        {
            get{ return this._categoryID ; }
            set{ this._categoryID = value ; }
        }
        private string _tag;
        [Column(Name="Tag",DbType = "nvarchar", CanBeNull = false)]
        public string Tag
        {
            get{ return this._tag ; }
            set{ this._tag = value ; }
        }
        private int _status;
        [Column(Name="Status",DbType = "int", CanBeNull = false)]
        public int Status
        {
            get{ return this._status ; }
            set{ this._status = value ; }
        }
        private int _replyCount;
        [Column(Name="ReplyCount",DbType = "int", CanBeNull = true)]
        public int ReplyCount
        {
            get{ return this._replyCount ; }
            set{ this._replyCount = value ; }
        }
        private int _clickCount;
        [Column(Name="ClickCount",DbType = "int", CanBeNull = true)]
        public int ClickCount
        {
            get{ return this._clickCount ; }
            set{ this._clickCount = value ; }
        }
        private int _createID;
        [Column(Name="CreateID",DbType = "int", CanBeNull = true)]
        public int CreateID
        {
            get{ return this._createID ; }
            set{ this._createID = value ; }
        }
        private DateTime _createDate;
        [Column(Name="CreateDate",DbType = "datetime", CanBeNull = false)]
        public DateTime CreateDate
        {
            get{ return this._createDate ; }
            set{ this._createDate = value ; }
        }
    }
}

