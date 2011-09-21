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

        public bool Modify(LoginUser entity)
        {
            try
            {
                LoginUser old = this.DataTable.Where(x => x.ID == entity.ID).SingleOrDefault();
                if (old == null)
                {
                    log.Info("修改的用户不存在! ID:" + entity.ID);
                    return false;
                }

                if (!string.IsNullOrEmpty(entity.LoginName) && entity.LoginName != old.LoginName)
                {
                    old.LoginName = entity.LoginName;
                }
                if (!string.IsNullOrEmpty(entity.PassWord) && entity.PassWord != old.PassWord)
                {
                    old.PassWord = entity.PassWord;
                }
                if (!string.IsNullOrEmpty(entity.Email) && entity.Email != old.Email)
                {
                    old.Email = entity.Email;
                }
                if (entity.LastLoginDate != null && entity.LastLoginDate != old.LastLoginDate)
                {
                    old.LastLoginDate = entity.LastLoginDate;
                }
                if (entity.Type != old.Type)
                {
                    old.Type = entity.Type;
                }
                if (!string.IsNullOrEmpty(entity.LastLoginIP) && entity.LastLoginIP != old.LastLoginIP)
                {
                    old.LastLoginIP = entity.LastLoginIP;
                }

                if (entity.CreateDate != null && entity.CreateDate != old.CreateDate)
                {
                    old.CreateDate = entity.CreateDate;
                }

                this.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Warn(ex.Message, ex);
                return false;
            }
        }
    }
}
