<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<!-- start footer  -->
<div id="footer">
    <div>
        <%=Html.ActionLink("关于我们", "About", "Home", null, new { target="_blank",title="About" })%>
        &nbsp;-&nbsp;
        <%=Html.ActionLink("MarkDown","Help","MarkDown") %>
        &nbsp;-&nbsp; <a href="https://github.com/fpobin/CodeNote" target="_blank" title="Site Code">
            本站代码</a>
    </div>
    <p>
        &copy; Copy right 2011
    </p>
</div>
<!-- end footer  -->
