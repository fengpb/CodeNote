<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<!-- start footer  -->
<div id="footer">
    <div>
        <%=Html.ActionLink("关于", "About", "Home", null, new { target="_blank",title="About" })%>
    </div>
    <p>
        &copy; Copy right <b>A pure boy</b> <span class="date">2011</span>
    </p>
</div>
<!-- end footer  -->
