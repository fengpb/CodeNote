<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    关于gravatar头像
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PopTitle" runat="server">
    <li><a href="/" title="Home">首页</a> </li>
    <li class="cur"><a>关于gravatar头像</a> </li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="magtlf10 mgt10">
        <p class="mgb10">
            本站使用<a href="http://www.gravatar.com" target="_blank">www.gravatar.com</a>提供的全球头像服务。
            <br />
            您可以在该网站上注册帐户设置你的头像信息。
        </p>
        <h4 class="mgt10">
            步骤如下：</h4>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
