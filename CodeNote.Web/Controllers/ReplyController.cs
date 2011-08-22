using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CodeNote.Common;
using CodeNote.Entity;
using CodeNote.Manager;

namespace CodeNote.Web.Controllers
{
    public class ReplyController : BaseController
    {
        private ReplyManager _replayMg;
        public ReplyManager ReplayMg
        {
            get
            {
                if (_replayMg == null)
                {
                    _replayMg = new ReplyManager();
                }
                return _replayMg;
            }
        }
        /// <summary>
        /// 添加回复
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="email"></param>
        /// <param name="body"></param>
        /// <param name="articleID"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult Add(string nick, string email, string body, int articleID)
        {
            Reply entity = new Reply();
            entity.ArticleID = articleID;
            entity.Body = Common.MarkDown.Transform(body);
            entity.Nick = nick;
            entity.Email = email;
            entity.CreateDate = DateTime.Now;
            if (CurUser != null)
            {
                entity.CreateID = CurUser.ID;
            }

            ReturnValue retValue = new ReturnValue();
            retValue = this.ReplayMg.Add(entity);
            return Json(retValue);
        }

        public ActionResult ReplyList(int articleID, int page = 1, int size = 10)
        {
            PageList<Reply> model = this.ReplayMg.GetList(articleID, page, size);
            ViewData["articleID"] = articleID;
            return PartialView("ReplyList", model);
        }

    }
}
