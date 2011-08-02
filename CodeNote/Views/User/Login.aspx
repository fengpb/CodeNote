<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   登录 - Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="poptitle">
        <h4>
            <span title="Login">登录</span></h4>
    </div>
    <div>
        <% Html.BeginForm("DoLogin", "User", FormMethod.Post); %>
        <dl class="dlinput">
            <dt><label title="Login Name" for="loginName">登录名</label></dt>
            <dd>
                <input id="loginName" type="text" class="text" name="name" /></dd>
            <dt><label title="Password" for="loginPassword">密码</label></dt>
            <dd>
                <input id="loginPassword" type="password" class="text" name="password" /></dd>
            <dd>
                <input type="submit" value="登录" title="Login" class="button" /></dd>
        </dl>
        <div>
            <p class="note">
                还没有帐号，请<%= Html.ActionLink("注册","Register","User",null,new {title="Register"}) %>。
            </p>
        </div>
        <% Html.EndForm(); %>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
