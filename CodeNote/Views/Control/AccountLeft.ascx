<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<LoginUser>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<% if (Model != null)
   { %>
<div>
    <%= Html.Avatar(CurUser.Email)%><%= Html.ActionLink("退出", "LoginOut", "User", null, new { title = "Loginout" })%>
    <hr />
</div>
<%} %>
