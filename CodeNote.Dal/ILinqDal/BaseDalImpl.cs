using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace CodeNote.Linq.IDal
{
    public class BaseDalImpl<T> : DataContext<T>, IBaseDal<T> where T : class
    {
        public BaseDalImpl(string connectionStr)
            : base(connectionStr)
        {
        }

        public BaseDalImpl()
        //: base(System.Configuration.ConfigurationManager.ConnectionStrings["CodeNoteBlog"].ConnectionString)
        { }

        protected ILog log = LogManager.GetLogger(typeof(BaseDalImpl<T>));

        public bool Add(T entity)
        {
            try
            {
                DataTable.InsertOnSubmit(entity);
                this.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Warn(ex.Message, ex);
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
            catch (Exception ex)
            {
                log.Warn(ex.Message, ex);
                return false;
            }
        }

        public IList<T> GetAllList()
        {
            return DataTable.ToList<T>();
        }

        public IList<T> GetList(Func<T, bool> f)
        {
            return DataTable.Where(f).ToList<T>();
        }
    }
}
