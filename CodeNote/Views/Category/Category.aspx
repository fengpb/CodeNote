<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Category>" %>

<%@ Import Namespace="CodeNote.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Category
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/Categroy.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Navigation" runat="server">
    <% Html.RenderAction("Navigation", "Control",new { categoryID = Model.CategoryID }); %>
</asp:Content>
<asp:Content ID="Conten4" ContentPlaceHolderID="MainContent" runat="server">
    <div id="leftwrap">
        <div class="leftbox">
            <% Html.RenderAction("ArticleList", "Article", new { categoryID = Model.CategoryID }); %>
        </div>
    </div>
    <div id="rightwrap">
        <div class="rightbox">
            <% Html.RenderAction("CategoryList", "Category", new { categoryID = Model.CategoryID }); %>
            <div>
                <h4>
                    <label>
                        最近更新</label></h4>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
