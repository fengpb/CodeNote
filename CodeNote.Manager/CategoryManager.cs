using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
#region using users.
using CodeNote.Entity;
using CodeNote.Dal;
using CodeNote.Common;
using log4net;
#endregion

namespace CodeNote.Manager
{
    public class CategoryManager
    {

        protected static ILog log;

        private string CategoryAllCacheKey = "CATEGORY_ALL_CACHE_KEY";
        private Object lockCategory = new Object();

        static CategoryManager()
        {
            log = LogManager.GetLogger(typeof(CategoryManager));
        }

        /// <summary>
        /// 添加或修改分类信息
        /// <br/>
        /// 清除分类缓存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnValue AddOrEdit(Category entity)
        {
            ReturnValue retValue = new ReturnValue();

            if (string.IsNullOrEmpty(entity.Name))
            {
                retValue.IsExists = false;
                retValue.Message = "分类名称";
                return retValue;
            }
            if (string.IsNullOrEmpty(entity.Title))
            {
                retValue.IsExists = false;
                retValue.Message = "分类显示名称";
                return retValue;
            }

            using (CategoryDal dal = new CategoryDal())
            {
                Category old = dal.Get(entity.CategoryID);
                if (old == null)//添加
                {
                    old = dal.GetByName(entity.Name);
                    if (old != null)
                    {
                        retValue.IsExists = false;
                        retValue.Message = "分类已存在";
                        return retValue;
                    }
                    if (dal.Add(entity))
                    {
                        retValue.IsExists = true;
                        retValue.Message = "分类添加成功";
                    }
                    else
                    {
                        retValue.IsExists = false;
                        retValue.Message = "分类添加失败";
                    }
                }
                else
                {
                    if (entity.Name != old.Name)
                    {
                        old = dal.GetByName(entity.Name);
                        if (old != null)
                        {
                            retValue.IsExists = false;
                            retValue.Message = "分类已存在";
                            return retValue;
                        }
                    }
                    if (dal.Modify(entity))
                    {
                        retValue.IsExists = true;
                        retValue.Message = "分类修改成功";
                    }
                    else
                    {
                        retValue.IsExists = false;
                        retValue.Message = "分类修改失败";
                    }
                }
            }
            if (retValue.IsExists)
            {
                ClearCache();
            }
            return retValue;
        }

        #region Get
        /// <summary>
        /// 根据分类ID获取分类信息
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public Category Get(string categoryID)
        {
            if (string.IsNullOrEmpty(categoryID))
            {
                return null;
            }
            using (CategoryDal dal = new CategoryDal())
            {
                return dal.Get(categoryID);
            }
        }
        /// <summary>
        /// 根据分类名字获取分类信息
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public Category GetName(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                return null;
            }
            Category entity = this.GetAllCache().Where(x => x.Name == categoryName).SingleOrDefault();
            if (entity == null)
            {
                using (CategoryDal dal = new CategoryDal())
                {
                    entity = dal.GetByName(categoryName);
                }
            }
            return entity;
        }
        #endregion

        #region GetList
        /// <summary>
        /// 获取顶级分类信息/即:导航菜单
        /// </summary>
        /// <returns></returns>
        public IList<Category> GetMenu()
        {
            IList<Category> list = this.GetAllCache().Where(e => e.ParentID == "0").ToList();
            if (list == null || list.Count < 1)
            {
                using (CategoryDal dal = new CategoryDal())
                {
                    list = dal.GetMenu();
                }
            }
            return list;
        }
        /// <summary>
        /// 通过父辈ID获取分类信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="noRetNull">如果当前节点子类为空是否返回同级节点信息</param>
        /// <returns></returns>
        public IList<Category> GetByParentID(string parentID, bool noRetNull = false)
        {
            if (string.IsNullOrEmpty(parentID))
            {
                return null;
            }

            IList<Category> list = this.GetByParentID(parentID);
            if ((list == null || list.Count < 1) && noRetNull)
            {
                int temp = parentID.LastIndexOf("-");
                if (temp > 0)
                {
                    string parID = parentID.Substring(0, temp);
                    if (log.IsDebugEnabled)
                    {
                        log.Debug(string.Format("sub item is null! last:{0} sub:{1}", temp, parID));
                    }
                    list = this.GetByParentID(parID);
                }
            }
            return list;
        }
        public IList<Category> GetByParentID(string parentID)
        {
            if (string.IsNullOrEmpty(parentID))
            {
                return null;
            }

            IList<Category> list = GetAllCache().Where(x => x.ParentID == parentID).ToList();

            if (list == null || list.Count < 1)
            {
                using (CategoryDal dal = new CategoryDal())
                {
                    list = dal.GetByParentID(parentID);
                }
            }
            return list;

        }


        /// <summary>
        /// 获取相似的分类信息
        /// </summary>
        /// <param name="likeCategoryID"></param>
        /// <returns></returns>
        public IList<Category> GetLike(string likeCategoryID)
        {
            using (CategoryDal dal = new CategoryDal())
            {
                return dal.GetLike(likeCategoryID);
            }
        }

        /// <summary>
        /// 获取分类的树状列表
        /// </summary>
        /// <returns></returns>
        public TreeWrap<Category> GetCategoryTree()
        {
            TreeWrap<Category> tree = new TreeWrap<Category>();
            tree.CurNode = new Category() { CategoryID = "0", Name = "分类信息" };
            return InitTree(tree);
        }

        private TreeWrap<Category> InitTree(TreeWrap<Category> root)
        {
            IList<Category> list = this.GetByParentID(root.CurNode.CategoryID);
            foreach (Category item in list)
            {
                TreeWrap<Category> subItem = new TreeWrap<Category>(item);
                InitTree(subItem);
                root.AddSubNode(subItem);
            }
            return root;
        }

        public IList<Category> GetAllCache()
        {
            IList<Category> cache = Common.BuildCache<IList<Category>>.Default.Get(this.CategoryAllCacheKey);
            if (cache == null)
            {
                using (CategoryDal dal = new CategoryDal())
                {
                    cache = dal.GetAll();
                    if (cache != null)
                    {
                        lock (this.lockCategory)
                        {
                            Common.BuildCache<IList<Category>>.Default.Cache(this.CategoryAllCacheKey, cache);
                        }
                    }
                }
            }
            return cache;
        }
        /// <summary>
        /// 清除缓存
        /// </summary>
        protected void ClearCache()
        {
            Common.BuildCache.CacheRemove(this.CategoryAllCacheKey);
        }
        #endregion
    }
}
