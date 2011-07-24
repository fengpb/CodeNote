using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Linq.IDal
{
    public interface IBaseDal<T> where T: class
    {
        bool Add(T entity);
        bool Del(T entity);

        IList<T> GetAllList();
    }
}
