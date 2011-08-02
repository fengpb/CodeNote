﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PageList<Article>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Common" %>
<% if (Model != null && Model.RecordCount > 0)
   { %>
<% foreach (Article item in Model.Data)
   {
%>
<div>
    <h3>
        <%: item.Subject %></h3>
    <div>
        <%: item.Body %></div>
</div>
<%
   } %>
<%} %>
