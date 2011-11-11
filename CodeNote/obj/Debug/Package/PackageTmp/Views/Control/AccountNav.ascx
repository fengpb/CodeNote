<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<dynamic>" %>
<ul id="navbar">
    <li>
        <%=Html.ActionLink("首页", "Index", "Account")%></li>
    <li>
        <%=Html.ActionLink("帐户信息", "EditUser", "User")%></li>
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
