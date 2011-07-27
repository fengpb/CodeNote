using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeNote.Entity;
using CodeNote.Dal.Proc;

namespace CodeNote.Dal
{
    public class LoginUserDal : CodeNote.Linq.IDal.BaseDalImpl<LoginUser>
    {
        public LoginUser Get(string loginNameOrEmail)
        {

            using (LoginUserProc proc = new LoginUserProc())
            {

                IList<LoginUser> list = proc.Get(loginNameOrEmail).ToList();
                if (list != null && list.Count > 0)
                {
                    return list[0];
                }

                return null;
            }
            //return this.DataTable.Where(e => (e.LoginName == loginNameOrEmail || e.Eamil == loginNameOrEmail)).SingleOrDefault();
        }
    }
}
