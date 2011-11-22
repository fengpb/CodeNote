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

        public bool UpDate(int artID)
        {
            try
            {
                Html old = this.DataTable.Where(x => x.ArtID == artID).SingleOrDefault();
                if (old != null)
                {
                    old.Upda = DateTime.Now;
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
