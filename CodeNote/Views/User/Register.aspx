<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="poptitle">
        <label title="Register">
            注册</label></div>
    <div>
        <dl>
            <dt><span title="Email">电子邮件</span></dt>
            <dd>
                <input type="text" class="text" name="email" /></dd>
            <dd>
                <input type="submit" value="提交" title="submit" class="button" />
            </dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
