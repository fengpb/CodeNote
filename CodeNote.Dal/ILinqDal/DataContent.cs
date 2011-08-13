using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Configuration;

namespace CodeNote.Linq.IDal
{
    public class DataContext<T> : System.Data.Linq.DataContext where T : class
    {
        public DataContext(string connectionStr)
            : base(connectionStr)
        {
            this.DataTable = this.GetTable<T>();
        }

        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["CodeNoteBlog"].ConnectionString)
        {
            this.DataTable = this.GetTable<T>();
        }

        public Table<T> DataTable { get; private set; }
    }
    public class DataContext : System.Data.Linq.DataContext
    {
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["CodeNoteBlog"].ConnectionString)
        {
        }
    }
}
