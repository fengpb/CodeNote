using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeNote.Web.Models
{
    public class StringResult : System.Web.Mvc.ActionResult
    {
        public StringResult(string message)
        {
            Msg = message;
        }
        public string Msg { get; set; }
        public override void ExecuteResult(System.Web.Mvc.ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "text/html";
            context.HttpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(context.HttpContext.Response.OutputStream, Encoding.UTF8))
                sw.Write(Msg);

        }
    }
}
