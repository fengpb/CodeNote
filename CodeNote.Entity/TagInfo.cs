using System;
using System.Text;
using System.Data.Linq.Mapping;
// create by codesmith 2011-07-27 21:24:32

namespace CodeNote.Entity
{   
    [Table(Name="TagInfo")]
    public class TagInfo
    {
        private int _iD;
        [Column(Name="ID",DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int ID
        {
            get{ return this._iD ; }
            set{ this._iD = value ; }
        }
        private string _name;
        [Column(Name="Name",DbType = "nvarchar", CanBeNull = true)]
        public string Name
        {
            get{ return this._name ; }
            set{ this._name = value ; }
        }
        private int _count;
        [Column(Name="Count",DbType = "int", CanBeNull = true)]
        public int Count
        {
            get{ return this._count ; }
            set{ this._count = value ; }
        }
    }
}

