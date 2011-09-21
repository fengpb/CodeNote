<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="CodeNote.Web.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CodeNote
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Navigation" runat="server">
    <% Html.RenderAction("Navigation", "Control", new { categoryID = "Index" }); %>
</asp:Content>
<asp:Content ID="leftbox" ContentPlaceHolderID="LeftBox" runat="server">
    <div id="articlelist">
        <% Html.RenderAction("ArticleList", "Article"); %>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="RightBox" runat="server">
    <% Html.RenderAction("CategoryList", "Category"); %>
    <% Html.RenderAction("ArticleNew", "Article");%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
