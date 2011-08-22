using System;
using System.Text;
using System.Data.Linq.Mapping;
// create by codesmith 2011-08-17 20:58:00

namespace CodeNote.Entity
{
    [Table(Name = "Reply")]
    public class Reply
    {
        private int _iD;
        [Column(Name = "ID", DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int ID
        {
            get { return this._iD; }
            set { this._iD = value; }
        }
        private int _articleID;
        [Column(Name = "ArticleID", DbType = "int", CanBeNull = false)]
        public int ArticleID
        {
            get { return this._articleID; }
            set { this._articleID = value; }
        }
        private string _body;
        [Column(Name = "Body", DbType = "nvarchar", CanBeNull = false)]
        public string Body
        {
            get { return this._body; }
            set { this._body = value; }
        }
        private string _nick;
        [Column(Name = "Nick", DbType = "nvarchar", CanBeNull = false)]
        public string Nick
        {
            get { return this._nick; }
            set { this._nick = value; }
        }
        private string _email;
        [Column(Name = "Email", DbType = "nvarchar", CanBeNull = false)]
        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }
        private int _createID;
        [Column(Name = "CreateID", DbType = "int", CanBeNull = true)]
        public int CreateID
        {
            get { return this._createID; }
            set { this._createID = value; }
        }
        private DateTime _createDate;
        [Column(Name = "CreateDate", DbType = "datetime", CanBeNull = false)]
        public DateTime CreateDate
        {
            get { return this._createDate; }
            set { this._createDate = value; }
        }
    }
}

