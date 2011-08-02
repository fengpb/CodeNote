<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="CodeNote.Web.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/Categroy.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="leftwrap">
        <div class="leftbox">
            <% Html.RenderAction("ArticleList", "Article"); %>
            <%= Html.Paging(new Pager(2, 10, 1000), "", "", new { })%>
            <%= Html.Paging(new Pager(1, 10, 1000), "", "", new { })%>
             <%= Html.Paging(new Pager(98, 10, 1000), "", "", new { })%>
             <%= Html.Paging(new Pager(100, 10, 1000), "", "", new { })%>
        </div>
    </div>
    <div id="rightwrap">
        <div class="rightbox">
            <% Html.RenderAction("CategoryList", "Category"); %>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
