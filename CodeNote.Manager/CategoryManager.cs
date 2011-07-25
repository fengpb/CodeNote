using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
#region using users.
using CodeNote.Entity;
using CodeNote.Dal;
#endregion

namespace CodeNote.Manager
{
    public class CategoryManager
    {
        public Category Get(string categoryID)
        {
            using (CategoryDal dal = new CategoryDal())
            {
                return dal.Get(categoryID);
            }
        }

        public IList<Category> GetMenu()
        {
            using (CategoryDal dal = new CategoryDal())
            {
                return dal.GetMenu();
            }
        }

        public IList<Category> GetLike(string likeCategoryID)
        {
            using (CategoryDal dal = new CategoryDal())
            {
                return dal.GetLike(likeCategoryID);
            }
        }
    }
}
