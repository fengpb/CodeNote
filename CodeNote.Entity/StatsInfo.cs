using System;
using System.Text;
using System.Data.Linq.Mapping;
// create by codesmith 2011-07-27 21:24:32

namespace CodeNote.Entity
{   
    [Table(Name="StatsInfo")]
    public class StatsInfo
    {
        private int _iD;
        [Column(Name="ID",DbType = "int", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int ID
        {
            get{ return this._iD ; }
            set{ this._iD = value ; }
        }
        private int _articleCount;
        [Column(Name="ArticleCount",DbType = "int", CanBeNull = true)]
        public int ArticleCount
        {
            get{ return this._articleCount ; }
            set{ this._articleCount = value ; }
        }
        private int _categoryCount;
        [Column(Name="CategoryCount",DbType = "int", CanBeNull = true)]
        public int CategoryCount
        {
            get{ return this._categoryCount ; }
            set{ this._categoryCount = value ; }
        }
        private int _tagCount;
        [Column(Name="TagCount",DbType = "int", CanBeNull = true)]
        public int TagCount
        {
            get{ return this._tagCount ; }
            set{ this._tagCount = value ; }
        }
        private int _replyCount;
        [Column(Name="ReplyCount",DbType = "int", CanBeNull = true)]
        public int ReplyCount
        {
            get{ return this._replyCount ; }
            set{ this._replyCount = value ; }
        }
        private DateTime _statsDate;
        [Column(Name="StatsDate",DbType = "datetime", CanBeNull = true)]
        public DateTime StatsDate
        {
            get{ return this._statsDate ; }
            set{ this._statsDate = value ; }
        }
    }
}

