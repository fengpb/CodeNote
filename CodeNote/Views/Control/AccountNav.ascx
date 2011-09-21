<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<dynamic>" %>
<div class="<%=SiteData.IsAdmin?"navrightmenu":""%>">
    <dl>
        <% if (SiteData.IsAdmin)
           { %>
        <dt>用户管理</dt>
        <%} %>
        <dd>
            <%=Html.ActionLink("帐户信息", "EditUser", "User")%></dd>
    </dl>
    <% if (SiteData.IsAdmin)
       { %>
    <dl>
        <dt>站长工具</dt>
        <dd>
            <a href="#">站内统计</a></dd>
        <dd>
            <%= Html.ActionLink("站内分类","Category","Account") %>
        </dd>
        <dd>
            <%= Html.ActionLink("站内标签", "Tag","Account")%>
        </dd>
    </dl>
    <%} %>
</div>
