<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <div id="poptitle">
 <label title="Login">
        登录</label>
 </div>
    <div>
        <% Html.BeginForm("DoLogin", "User", FormMethod.Post); %>
        <dl>
            <dt><span title="Login Name">登录名</span></dt>
            <dd>
                <input type="text" class="text" name="name" /></dd>
            <dt><span title="Password">密码</span></dt>
            <dd>
                <input type="password" class="text" name="password" /></dd>
            <dd>
                <input type="submit" value="登录" title="Login" class="button" /></dd>
        </dl>
        <div>
            <p>
                还没有帐号，请<%= Html.ActionLink("注册","Register","User",null,new {title="Register"}) %>。
            </p>
        </div>
        <% Html.EndForm(); %>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
