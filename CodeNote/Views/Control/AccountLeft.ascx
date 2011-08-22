<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<LoginUser>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<% if (Model != null)
   { %>
<div id="account">
    <div class="info posrl">
        <%= Html.Avatar(CurUser.Email)%>
        <div class="posabstr">
            <%= Html.ActionLink("退出", "LoginOut", "User", null, new { title = "Loginout" })%></div>
    </div>
</div>
<%} %>
