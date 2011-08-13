using System;
using System.Text;
using System.Data.Linq.Mapping;
// create by codesmith 2011-07-27 21:24:31

namespace CodeNote.Entity
{   
    [Table(Name="LoginUser")]
    public class LoginUser
    {
        private int _iD;
        [Column(Name="ID",DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int ID
        {
            get{ return this._iD ; }
            set{ this._iD = value ; }
        }
        private string _loginName;
        [Column(Name="LoginName",DbType = "nvarchar", CanBeNull = false)]
        public string LoginName
        {
            get{ return this._loginName ; }
            set{ this._loginName = value ; }
        }
        private string _passWord;
        [Column(Name="PassWord",DbType = "nvarchar", CanBeNull = false)]
        public string PassWord
        {
            get{ return this._passWord ; }
            set{ this._passWord = value ; }
        }
        private string _email;
        [Column(Name="Email",DbType = "nvarchar", CanBeNull = false)]
        public string Email
        {
            get{ return this._email ; }
            set{ this._email = value ; }
        }
        private DateTime? _lastLoginDate;
        [Column(Name="LastLoginDate",DbType = "datetime", CanBeNull = true)]
        public DateTime? LastLoginDate
        {
            get{ return this._lastLoginDate ; }
            set{ this._lastLoginDate = value ; }
        }
        private int _type;
        [Column(Name="Type",DbType = "int", CanBeNull = false)]
        public int Type
        {
            get{ return this._type ; }
            set{ this._type = value ; }
        }
        private string _lastLoginIP;
        [Column(Name="LastLoginIP",DbType = "nvarchar", CanBeNull = true)]
        public string LastLoginIP
        {
            get{ return this._lastLoginIP ; }
            set{ this._lastLoginIP = value ; }
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

