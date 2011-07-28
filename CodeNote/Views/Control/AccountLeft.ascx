<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<LoginUser>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<% if (Model != null)
   { %>
<div>
    <img alt="<%:Model.LoginName %>" src="<%= FaceImgUrl(Model.Eamil) %>" />
    <hr />
    <p><%= FaceImgUrl(Model.Eamil) %></p>
</div>
<%} %>
