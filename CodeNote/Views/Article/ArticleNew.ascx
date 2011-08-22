<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<Article>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<% if (Model != null && Model.Count > 0)
   { %>
<div class="itembox">
    <h4>
        <label>
            最近更新</label></h4>
    <ul class="rightlist">
        <%foreach (Article item in Model)
          {
        %>
        <li>
            <%= Html.ActionLink(item.Subject, "Detail", "Article", new { articleID = item.ID }, null)%></li>
        <%
            } %>
    </ul>
</div>
<%} %>
