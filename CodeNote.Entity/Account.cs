using System;
using System.Text;
using System.Data.Linq.Mapping;
// create by codesmith 2011-07-27 21:24:31

namespace CodeNote.Entity
{   
    [Table(Name="Account")]
    public class Account
    {
        private int _userID;
        [Column(Name="UserID",DbType = "int", IsPrimaryKey = true, CanBeNull = false)]
        public int UserID
        {
            get{ return this._userID ; }
            set{ this._userID = value ; }
        }
        private string _realName;
        [Column(Name="RealName",DbType = "nvarchar", CanBeNull = true)]
        public string RealName
        {
            get{ return this._realName ; }
            set{ this._realName = value ; }
        }
        private string _mobel;
        [Column(Name="Mobel",DbType = "nvarchar", CanBeNull = true)]
        public string Mobel
        {
            get{ return this._mobel ; }
            set{ this._mobel = value ; }
        }
        private int _age;
        [Column(Name="Age",DbType = "int", CanBeNull = true)]
        public int Age
        {
            get{ return this._age ; }
            set{ this._age = value ; }
        }
        private string _resume;
        [Column(Name="Resume",DbType = "nvarchar", CanBeNull = true)]
        public string Resume
        {
            get{ return this._resume ; }
            set{ this._resume = value ; }
        }
        private DateTime _birthDay;
        [Column(Name="BirthDay",DbType = "datetime", CanBeNull = true)]
        public DateTime BirthDay
        {
            get{ return this._birthDay ; }
            set{ this._birthDay = value ; }
        }
        private byte[] _protectQuestion;
        [Column(Name="ProtectQuestion",DbType = "varbinary", CanBeNull = true)]
        public byte[] ProtectQuestion
        {
            get{ return this._protectQuestion ; }
            set{ this._protectQuestion = value ; }
        }
        private string _protectPwd;
        [Column(Name="ProtectPwd",DbType = "nvarchar", CanBeNull = true)]
        public string ProtectPwd
        {
            get{ return this._protectPwd ; }
            set{ this._protectPwd = value ; }
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

