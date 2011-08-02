<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    注册 - Register
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="poptitle">
        <h4>
            <span title="Register">注册</span></h4>
    </div>
    <div>
        <dl class="dlinput">
            <dt><label title="Email" for="regemail">电子邮件</label></dt>
            <dd>
                <input id="regemail" type="text" class="text" name="email" /></dd>
            <dd>
                <input type="submit" value="提交" title="submit" class="button" />
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
