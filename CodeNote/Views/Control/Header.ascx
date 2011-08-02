<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<dynamic>" %>
<!-- start header -->
<div id="header">
    <div id="logo">
        <h1>
            <a href="/"><span class="red">Code</span><span>Note</span>
                <!--<img alt="CodeNote" class="logoimg" src="" />-->
            </a>
        </h1>
        <div class="sitedesp">
            Life is good!
        </div>
    </div>
    <div id="hright">
        <dl>
            <dd>
                <div class="tar">
                    <% if (IsLogin)
                       { %>
                    <%= Html.ActionLink("退出", "LoginOut", "User", null, new { title = "Loginout" })%>
                    <%= Html.ActionLink(CurUser.LoginName,"Index","Account")%>
                    <%}
                       else
                       { %>
                    <%= Html.ActionLink("登录", "Login", "User", null, new { title = "Login" })%>
                    <%} %>
                </div>
            </dd>
            <dd>
                <div class="searchbox">
                    <form action="" method="post">
                    <input type="text" class="text" />
                    </form>
                </div>
            </dd>
        </dl>
    </div>
</div>
<!-- end header -->
