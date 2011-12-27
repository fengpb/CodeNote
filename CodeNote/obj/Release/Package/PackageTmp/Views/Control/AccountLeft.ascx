<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<LoginUser>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<% if (Model != null)
   { %>
<div id="account">
    <div class="info posrl">
        <%= Html.Avatar(CurUser.Email)%>
        <div class="posabstr">
            <%= Html.ActionLink("退出", "LoginOut", "User", null, new { title = "Loginout" })%></div>
    </div>
</div>
<%} %>
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
        <dd>
            <%=Html.ActionLink("刷新SiteMap","SiteMap","Home") %></dd>
    </dl>
    <%} %>
</div>
