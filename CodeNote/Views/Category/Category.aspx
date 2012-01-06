<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Category>" %>

<%@ Import Namespace="CodeNote.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A Pure Boy：<%=Model.Title %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Navigation" runat="server">
    <% Html.RenderAction("Navigation", "Control", new { categoryID = Model.CategoryID }); %>
</asp:Content>
<asp:Content ID="LeftBox" ContentPlaceHolderID="LeftBox" runat="server">
    <h1 class="title">
        Topic：<%=Model.Title %></h1>
    <div id="articlelist">
        <% Html.RenderAction("ArticleList", "Article", new { categoryID = Model.CategoryID }); %>
    </div>
</asp:Content>
<asp:Content ID="RightBox" ContentPlaceHolderID="RightBox" runat="server">
    <% Html.RenderAction("CategoryList", "Category", new { categoryID = Model.CategoryID }); %>
    <% Html.RenderAction("ArticleNew", "Article", new { categoryID = Model.CategoryID });%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
