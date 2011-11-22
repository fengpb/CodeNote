<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<VwArticle>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
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
            <%= Html.DetialLink(item.Subject, "Detail", "Article",item.ID)%></li>
        <%
          } %>
    </ul>
</div>
<%} %>
<!-- End:相关推荐 -->
