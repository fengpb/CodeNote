<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<dynamic>" %>
<!-- start header -->
<div id="header">
    <div id="topmenu">
        <dl>
            <dd>
                <% if (IsLogin)
                   { %>
                <%= Html.ActionLink(CurUser.LoginName,"Index","Account")%>
                <%}
                   else
                   { %>
                <%= Html.ActionLink("登录", "Login", "User", null, new { title = "Login" })%>
                <%} %>
            </dd>
        </dl>
    </div>
    <div id="divlogo">
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
        <div id="hright" class="ad">
        </div>
    </div>
</div>
<!-- end header -->
