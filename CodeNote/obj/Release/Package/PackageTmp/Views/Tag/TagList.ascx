<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PageList<TagInfo>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Common" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<% if (Model != null && Model.RecordCount > 0)
   { %>
<ul class="taglist">
    <%foreach (var item in Model.Data)
      {
    %>
    <li><a href="<%=Html.Url("Tag", "Tag", new { tag =item.Name})%>" target="_blank">
        <%=item.Name %><small><%:item.Count %></small></a></li>
    <%
      } %>
</ul>
<% if (Model.TotolPage > 1)
   { %>
<%= Html.AjaxPaging(new Pager() { Cur = Model.CurPage, Count = Model.RecordCount, Size = Model.PageSize }, "TagList", "Tag", new AjaxPagingOption("taglist"), new { })%>
<%} %>
<%}
   else
   { %>
<p class="null">
    这里什么都没有!</p>
<%} %>