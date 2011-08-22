<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PageList<Article>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Common" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<% if (Model != null && Model.RecordCount > 0)
   { %>
<% foreach (Article item in Model.Data)
   {
%>
<div class="artitem">
    <h3>
        <%= Html.ActionLink(item.Subject,"Detail","Article",new {articleID=item.ID},null) %>
        <span></span>
    </h3>
    <div>
        <%= CodeNote.Common.StringFilter.HtmlFilter(item.Body) %></div>
</div>
<%
    } %>
<% if (Model.TotolPage > 1)
   { %>
<%= Html.AjaxPaging(new Pager() { Cur = Model.CurPage, Count = Model.RecordCount, Size = Model.PageSize }, "ArticleList", "Article",new AjaxPagingOption ("articlelist"), new { })%>
<%} %>
<%} %>
