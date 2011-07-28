<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<LoginUser>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<% if (Model != null)
   { %>
<div>
    <img style="vertical-align:middle" alt="<%:Model.LoginName %>" src="<%= FaceImgUrl(Model.Eamil,80) %>" />
    <hr />
</div>
<%} %>
