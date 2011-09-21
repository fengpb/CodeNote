<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Tag：<%=ViewData["tag"] %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Navigation" runat="server">
    <div id="navigation">
        <div class="navbg">
        </div>
        <ul>
            <li><a href="/" title="Index">首页</a> </li>
            <li class="cur"><a>Tag：<%=ViewData["tag"] %></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LeftBox" runat="server">
    <div id="articlelist">
        <% Html.RenderAction("PartTag", "Tag", new { tag = ViewData["tag"] }); %>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightBox" runat="server">
    <% Html.RenderAction("ArticleNew", "Article", new { tag = ViewData["tag"] });%>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
