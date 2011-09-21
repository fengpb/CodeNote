<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Account/Account.Master" Inherits="System.Web.Mvc.ViewPage<VwArticle>" %>

<%@ Import Namespace="CodeNote.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    修改文字
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TopContent" runat="server">
    <link href="/Content/Article.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/CodeNote.Article.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("AddOrEditArticle", Model); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            GetCategory("0", "selcategory", SelDefaultValue);
        });
    </script>
</asp:Content>
