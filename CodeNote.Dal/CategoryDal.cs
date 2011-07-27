using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region Using users.
using CodeNote.Entity;
using CodeNote.Dal.Proc;
#endregion

namespace CodeNote.Dal
{
    public class CategoryDal : CodeNote.Linq.IDal.BaseDalImpl<Category>
    {

        public Category Get(string categoryID)
        {
            return this.DataTable.Where(e => e.CategoryID == categoryID).SingleOrDefault();
        }

        public Category GetByName(string name)
        {
            return this.DataTable.Where(e => e.Name == name).SingleOrDefault();
        }

        public IList<Category> GetMenu()
        {
            return this.DataTable.Where(e => e.ParentID == "0").ToList();
        }

        public IList<Category> GetByParentID(string parentID)
        {
            return this.DataTable.Where(e => e.ParentID == parentID).ToList();
        }

        public IList<Category> GetLike(string likeCategoryID)
        {
            using (CategoryProc proc = new CategoryProc())
            {
                return proc.GetLike(likeCategoryID).ToList();
            }
        }
    }
}
