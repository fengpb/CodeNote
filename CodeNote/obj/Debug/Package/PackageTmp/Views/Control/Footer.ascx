<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<dynamic>" %>
<!-- start footer  -->
<div id="footer">
    <div>
        <%=Html.ActionLink("关于", "About", "Home", null, new { target="_blank",title="About" })%>
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
        &copy; Copy right <b>A pure boy</b> <span class="date">2011</span>
    </p>
</div>
<!-- end footer  -->
