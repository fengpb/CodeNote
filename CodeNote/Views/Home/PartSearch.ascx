<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<PageList<VwArticle>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Common" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<!-- search result -->
<% if (Model != null && Model.RecordCount > 0)
   { %>
<% for (int i = 0; i < Model.Data.Count; i++)
   {
       VwArticle item = Model.Data[i];
%>
<div class="shritem <%= i+1==Model.Data.Count?"end":"" %>">
    <h3>
        <%= Html.DetialLink(item.Subject, "Detail", "Article",item.ID)%>
    </h3>
    <div>
        <%= item.Body %>
        <p>
            <%= SiteData.HtmlDir+item.HtmlUrl %>
            - <span>
                <%=item.ModDate.ToString("yyyy-MM-dd") %></span>
        </p>
    </div>
</div>
<%
   } %>
<% if (Model.TotolPage > 1)
   { %>
<%= Html.AjaxPaging(new Pager() { Cur = Model.CurPage, Count = Model.RecordCount, Size = Model.PageSize }, "PartSearch", "Home", new AjaxPagingOption("searchresult"), new {key=ViewData["key"] })%>
<%} %>
<%}
   else
   { %>
<div>
    <p class="null">
        好不幸！ 没有找到！</p>
</div>
<%} %>
<!--end: search result -->
