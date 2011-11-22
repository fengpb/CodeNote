<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<VwArticle>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<!-- Begin:最近更新 -->
<% if (Model != null && Model.Count > 0)
   { %>
<div class="itembox">
    <h4>
        <label>
            最近更新</label></h4>
    <ul class="rightlist">
        <%foreach (VwArticle item in Model)
          {
        %>
        <li>
            <%= Html.DetialLink(item.Subject, "Detail", "Article",item.ID )%></li>
        <%
          } %>
    </ul>
</div>
<%} %>
<!-- End:最近更新 -->
