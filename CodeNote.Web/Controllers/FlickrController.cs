using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace CodeNote.Web.Controllers
{
    public class FlickrController : BaseController
    {
        private FlickrNet.Flickr _flickr;
        protected FlickrNet.Flickr Flickr
        {
            get
            {
                if (_flickr == null)
                {
                    //API key Shared Secret 
                    //from load web.config 
                    _flickr = new FlickrNet.Flickr();

                }

                if (!string.IsNullOrEmpty(CurToken))
                {
                    _flickr.AuthToken = CurToken;
                }
                return _flickr;
            }
        }

        public ActionResult Index()
        {
            string frob = Request["frob"];
            if (string.IsNullOrEmpty(CurToken) && string.IsNullOrEmpty(frob))
            {
                string url = "http://apureboy.com";
                url = Flickr.AuthCalcWebUrl(FlickrNet.AuthLevel.Write);
                return Redirect(url);
            }
            if (!string.IsNullOrEmpty(frob) && string.IsNullOrEmpty(CurToken))
            {
                FlickrNet.Auth auth = Flickr.AuthGetToken(frob);
                if (auth != null)
                {
                    Common.SessionWrap.Add(CodeNote.Web.Models.Constans.USER_SESSION_KEY_TOKEN, auth.Token);
                    Flickr.AuthToken = auth.Token;
                }
            }

            return View("Index");
        }

        public ActionResult UpLoadImg(HttpPostedFileBase file)
        {
            string ajax = Request["ajax"];
            if (file != null)
            {
                string photoId = Flickr.UploadPicture(file.InputStream, Request["title"], Request["desp"], Request["tags"], 1, 1, 1);

                if (!string.IsNullOrEmpty(ajax))
                {
                    return new Models.StringResult("{\"ret\":true,\"msg\":\"上传成功\",\"refurl\":\"" + UrlPath("Photo", "Flickr", new { photoId = photoId }) + "\"}");
                }
                return RedirectToAction("Photo", new { photoId = photoId }); //
            }
            if (!string.IsNullOrEmpty(ajax))
            {
                return new Models.StringResult("{\"ret\":true,\"msg\":\"请选择上载文件\"}");
            }
            return View("Result", new CodeNote.Web.Models.ReturnMessage("提示信息", "请选择上载文件"));
        }

        public ActionResult Photo(string photoId)
        {
            FlickrNet.PhotoInfo photoinfo = null;
            if (!string.IsNullOrEmpty(photoId))
            {
                photoinfo = Flickr.PhotosGetInfo(photoId);
            }
            return View("Photo", photoinfo);
        }
    }
}
