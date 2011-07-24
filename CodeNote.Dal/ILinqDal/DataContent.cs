using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Configuration;

namespace CodeNote.Linq.IDal
{
    public class DataContent<T> : System.Data.Linq.DataContext where T : class
    {
        public DataContent(string connectionStr)
            : base(connectionStr)
        {
            this.DataTable = this.GetTable<T>();
        }

        public DataContent()
            : base(ConfigurationManager.ConnectionStrings["CodeNoteBlog"].ConnectionString)
        {
            this.DataTable = this.GetTable<T>();
        }

        public Table<T> DataTable { get; private set; }
    }
}
