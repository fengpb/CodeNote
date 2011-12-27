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
        public bool Delete(string categoryID)
        {
            using (CategoryProc proc = new CategoryProc())
            {
                return (proc.SP_Category_Del(categoryID) == 0);
            }
        }

        public bool Modify(Category entity)
        {
            try
            {
                Category old = this.Get(entity.CategoryID);
                if (old == null)
                {
                    return false;
                }
                old.Name = entity.Name;
                old.Title = entity.Title;
                old.ParentID = entity.ParentID;
                old.Status = entity.Status;
                old.IsHot = entity.IsHot;
                old.Count = entity.Count;
                this.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Warn(ex.Message, ex);
                return false;
            }
        }

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
            return this.DataTable.Where(e => (e.ParentID == "0" && e.Status >0)).OrderBy(x => x.Status).ToList();
        }

        public IList<Category> GetByParentID(string parentID)
        {
            return this.DataTable.Where(e => e.ParentID == parentID).Where(e => e.Status > -1).ToList();
        }

        /// <summary>
        /// 获取所有的分类信息
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetAll()
        {
            return this.DataTable.ToList();
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
