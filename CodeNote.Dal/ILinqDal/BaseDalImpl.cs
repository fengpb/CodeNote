using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Linq.IDal
{
    public class BaseDalImpl<T> : DataContent<T>, IBaseDal<T> where T : class
    {
        public BaseDalImpl(string connectionStr)
            : base(connectionStr)
        {
        }

        public BaseDalImpl()
            //: base(System.Configuration.ConfigurationManager.ConnectionStrings["CodeNoteBlog"].ConnectionString)
        { }
        public bool Add(T entity)
        {
            try
            {
                DataTable.InsertOnSubmit(entity);
                this.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Del(T entity)
        {
            try
            {
                DataTable.DeleteOnSubmit(entity);
                this.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<T> GetAllList()
        {
            return DataTable.ToList<T>();
        }
    }
}
