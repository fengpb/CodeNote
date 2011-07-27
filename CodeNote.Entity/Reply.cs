using System;
using System.Text;
using System.Data.Linq.Mapping;
// create by codesmith 2011-07-27 21:24:32

namespace CodeNote.Entity
{   
    [Table(Name="Reply")]
    public class Reply
    {
        private int _iD;
        [Column(Name="ID",DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int ID
        {
            get{ return this._iD ; }
            set{ this._iD = value ; }
        }
        private int _articleID;
        [Column(Name="ArticleID",DbType = "int", CanBeNull = false)]
        public int ArticleID
        {
            get{ return this._articleID ; }
            set{ this._articleID = value ; }
        }
        private string _body;
        [Column(Name="Body",DbType = "nvarchar", CanBeNull = false)]
        public string Body
        {
            get{ return this._body ; }
            set{ this._body = value ; }
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

