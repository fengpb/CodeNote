<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<VwArticle>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<!-- Begin:相关推荐 -->
<% if (Model != null && Model.Count > 0)
   { %>
<div class="itembox">
    <h4>
        <label>
            相关推荐</label></h4>
    <ul class="rightlist">
        <%foreach (VwArticle item in Model)
          {
        %>
        <li>
            <%= Html.ActionLink(item.Subject, "Detail", "Article", new { articleID = item.ID }, null)%></li>
        <%
            } %>
    </ul>
</div>
<%} %>
<!-- End:相关推荐 -->
