using System;
using System.Text;
using System.Data.Linq.Mapping;
// create by codesmith 2011-07-24 02:38:42

namespace CodeNote.Entity
{   
    [Table(Name="Category")]
    public class Category
    {
        private string _categoryID;
        [Column(Name="CategoryID",DbType = "nvarchar", IsPrimaryKey = true, CanBeNull = false)]
        public string CategoryID
        {
            get{ return this._categoryID ; }
            set{ this._categoryID = value ; }
        }
        private string _name;
        [Column(Name="Name",DbType = "nvarchar", CanBeNull = false)]
        public string Name
        {
            get{ return this._name ; }
            set{ this._name = value ; }
        }
        private bool _isMenu;
        [Column(Name="IsMenu",DbType = "bit", CanBeNull = true)]
        public bool IsMenu
        {
            get{ return this._isMenu ; }
            set{ this._isMenu = value ; }
        }
        private int _status;
        [Column(Name="Status",DbType = "int", CanBeNull = false)]
        public int Status
        {
            get{ return this._status ; }
            set{ this._status = value ; }
        }
        private bool _isHot;
        [Column(Name="IsHot",DbType = "bit", CanBeNull = true)]
        public bool IsHot
        {
            get{ return this._isHot ; }
            set{ this._isHot = value ; }
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

