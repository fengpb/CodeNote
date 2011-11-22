using System;
using System.Text;
using System.Data.Linq.Mapping;

// create by codesmith 2011-07-27 21:24:32

namespace CodeNote.Entity
{
    [Table(Name = "Html")]
    public class Html
    {
        private int _artID;
        [Column(Name = "ArtID", DbType = "int", IsPrimaryKey = true, IsDbGenerated = false, CanBeNull = false)]
        public int ArtID
        {
            get { return this._artID; }
            set { this._artID = value; }
        }
        private string _url;
        [Column(Name = "Url", DbType = "nvarchar", CanBeNull = false)]
        public string Url
        {
            get { return this._url; }
            set { this._url = value; }
        }

        private DateTime _upDa;
        [Column(Name = "UpDa", DbType = "datetime", CanBeNull = true)]
        public DateTime Upda
        {
            get { return _upDa; }
            set { this._upDa = value; }
        }
    }
}

