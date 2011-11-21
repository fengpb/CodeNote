<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<dynamic>" %>
<ul id="navbar">
    <li>
        <%=Html.ActionLink("首页", "Index", "Home")%></li>
    <li>
        <%=Html.ActionLink("个人中心", "Index", "Account", null, new { id="accindex"})%></li>
    <% if (SiteData.IsAdmin)
       { %>
    <li>
        <%= Html.ActionLink("新日志", "AddArticle", "Article")%></li>
    <li>
        <%= Html.ActionLink("站内分类","Category","Account") %>
    </li>
    <li>
        <%= Html.ActionLink("站内标签", "Tag","Account")%>
    </li>
    <%} %>
</ul>
