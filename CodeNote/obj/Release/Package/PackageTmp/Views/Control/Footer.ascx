<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<dynamic>" %>
<!-- start footer  -->
<div id="footer">
    <div>
        <%=Html.ActionLink("关于", "About", "Home", null, new { target="_blank",title="About" })%>
        - <a target="_blank" href="/sitemap.xml">SiteMap</a> -
        <%=Html.ActionLink("标签", "Index", "Tag", null, new { target="_blank",title="Tag"})%>
        -
        <%=Html.ActionLink("帮助", "Help", "Home", null, new { target="_blank",title="Help",@class="help" })%>
        -
        <% if (IsLogin)
           { %>
        <%= Html.ActionLink(CurUser.LoginName,"Index","Account")%>
        <%}
           else
           { %>
        <%= Html.ActionLink("登录", "Login", "User", null, new { title = "Login" })%>
        <%} %>
    </div>
    <p>
        &copy; Copy right <strong>A pure boy</strong> <span class="date">2011</span>
    </p>
</div>
<!-- end footer  -->
