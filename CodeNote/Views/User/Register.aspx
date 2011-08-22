<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    注册 - Register
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="PopTitle" ContentPlaceHolderID="PopTitle" runat="server">
    <li class="cur"><a>注册</a></li>
    <li>
        <%= Html.ActionLink("登陆","Login","User") %></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="magtlf10 mgt10">
        <dl class="dlinput">
            <dt>
                <label for="loginname">
                    登陆名</label></dt>
            <dd>
                <input id="loginname" type="text" class="text" maxlength="20" />
            </dd>
            <dt>
                <label title="Email" for="regemail">
                    电子邮件</label></dt>
            <dd>
                <input id="regemail" type="text" class="text" name="email" /></dd>
            <dt>
                <label for="loginpasswod">
                    密码</label>
            </dt>
            <dd>
                <input id="loginpasswod" type="password" class="text" /></dd>
            <dd>
                <dt>
                    <label for="loginpasswod2">
                        确认密码</label>
                </dt>
                <dd>
                    <input id="loginpasswod2" type="password" class="text" /></dd>
                <dd>
                    <input type="submit" value="提交" title="submit" class="button" />
                </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
