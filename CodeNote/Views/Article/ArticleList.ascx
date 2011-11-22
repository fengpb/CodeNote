<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<PageList<VwArticle>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Common" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<!-- Begin:日志列表 -->
<% if (Model != null && Model.RecordCount > 0)
   { %>
<% for (int i = 0; i < Model.Data.Count; i++)
   {
       VwArticle item = Model.Data[i];
%>
<div class="artitem <%= i+1==Model.Data.Count?"end":"" %>">
    <div class="com">
        <h3>
            <%= Html.DetialLink(item.Subject, "Detail", "Article",item.ID)%>
            <span></span>
        </h3>
        <dl>
            <dd>
                <label title="作者">
                    By：<%= Html.ActionLink(item.CreateName, "", "") %></label></dd>
            <% if (!string.IsNullOrEmpty(item.CategoryName))
               { %>
            <dd>
                <label title="主题">
                    Topic：<%= Html.ActionLink(item.CategoryTitle, "Category", "Category", new { categoryName = item.CategoryName }, new { title = item.CategoryTitle })%></label></dd>
            <%} %>
            <% if (!string.IsNullOrEmpty(item.Tag))
               { %>
            <dd>
                <label title="标签">
                    Tag：<%= Html.TagLink(item.Tag, "Tag", "Tag")%>
                </label>
            </dd>
            <%} %>
        </dl>
    </div>
    <div class="content">
        <%= HtmlEncode (item.Body) %></div>
</div>
<%
   } %>
<% if (Model.TotolPage > 1)
   { %>
<%= Html.AjaxPaging(new Pager() { Cur = Model.CurPage, Count = Model.RecordCount, Size = Model.PageSize }, "ArticleList", "Article",new AjaxPagingOption ("articlelist"), new { })%>
<%} %>
<%}
   else
   { %>
<div>
    <p class="null">
        好不幸！ 这里什么都没有啊！</p>
</div>
<%} %>
<!-- End:日志列表 -->
