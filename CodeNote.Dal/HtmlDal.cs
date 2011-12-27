using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#region using user.
using CodeNote.Entity;
using CodeNote.Linq.IDal;
#endregion

namespace CodeNote.Dal
{
    public class HtmlDal : BaseDalImpl<Html>
    {

        public Html Get(int artID)
        {
            return this.DataTable.Where(x => x.ArtID == artID).SingleOrDefault();
        }

        public IList<Html> SiteMapList()
        {
            return this.DataTable.OrderByDescending(x => x.Upda).Take(10000).ToList();
        }

        public bool Modify(Html entity)
        {
            try
            {
                Html old = this.DataTable.Where(x => x.ArtID == entity.ArtID).SingleOrDefault();
                if (old != null)
                {
                    old.Upda = entity.Upda;
                }
                this.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return false;
            }
        }
    }
}
